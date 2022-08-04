using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class choose2 : MonoBehaviour
{
    public GameObject queren;
    public List<GameObject> buttons = new List<GameObject>();
    public Sprite normal;
    public Sprite highlight;
   
    public List<GameObject> actObjs = new List<GameObject>();
    public UnityEvent lessThan3;
    public UnityEvent finish;
    public List<Transform> locations = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<buttons.Count; i++)
        {
            if(CustomContains(actObjs, buttons[i]))
            {
                buttons[i].GetComponent<choose2Button>().buttonAct(true);
            }
            else
            {
                buttons[i].GetComponent<choose2Button>().buttonAct(false);
            }
        }
    }
    public void buttonPressed(GameObject obj)
    {
        int index = 0;
        for(int i=0; i<buttons.Count; i++)
        {
            if(buttons[i] == obj)
            {
                index = i;
                break;
            }
        }
        if (!actObjs.Contains(obj))
        {
            actObjs[0] = actObjs[1];
            actObjs[1] = actObjs[2];
            actObjs[2] = obj;
        }
        //obj.GetComponent<Image>().sprite = normal[index];
    }
    public void finishQueren()
    {
        foreach(GameObject obj in buttons)
        {
            obj.GetComponent<Button>().enabled = false;
            obj.transform.GetChild(0).gameObject.GetComponent<Image>().DOFade(0, 2);
            queren.GetComponent<Button>().enabled = false;
            obj.GetComponent<Image>().DOFade(0, 2).OnComplete(() =>
            {
                obj.SetActive(false);
                for(int i=0; i<actObjs.Count; i++)
                {
                    //actObjs[i].Rect = locations[i].transform;
                }
            });
        }
    }
    public bool CustomContains(List<GameObject> list, GameObject t)
    {
        foreach (var item in list)
        {
            if (item == t)
            {
                return true;
            }
        }
        return false; 
    }
}
