using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class choose2 : MonoBehaviour
{
    public GameObject queren;

    public List<GameObject> anis = new List<GameObject>();
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
    public void choose2Act()
    {
        
        this.gameObject.SetActive(true);
        foreach(var ani in anis)
        {
            ani.gameObject.GetComponent<Image>().DOFade(1, 2);
        }
        foreach(var b in buttons)
        {
            b.gameObject.GetComponent<Image>().DOFade(1, 2);
        }
        queren.gameObject.GetComponent<Image>().DOFade(1, 3).OnComplete(() => {
            Debug.Log("1");
            DialogSys.Instance.dialogNext();
            queren.gameObject.GetComponent<Button>().enabled = true;
        });
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
        foreach(var act in actObjs)
        {
            if (act == null)
            {
                DialogSys.Instance.dialogStart(21);
                return;
            }
        }
            foreach (GameObject obj in buttons)
            {
                obj.GetComponent<Button>().enabled = false;
                foreach (var ani in anis)
                {
                    ani.GetComponent<Image>().DOFade(0, 2);
                }
                queren.GetComponent<Button>().enabled = false;
                queren.GetComponent<Image>().DOFade(0, 2);
                obj.GetComponent<Image>().DOFade(0, 2).OnComplete(() =>
                {
                    DialogSys.Instance.dialogStart(22);
                    queren.SetActive(false);
                    obj.SetActive(false);
                    for (int i = 0; i < actObjs.Count; i++)
                    {
                        actObjs[i].SetActive(true);
                        actObjs[i].transform.position = locations[i].transform.position;
                        actObjs[i].GetComponent<choose2Button>().ani.transform.position = locations[i].transform.position;
                        actObjs[i].GetComponent<choose2Button>().enabled = false;
                        actObjs[i].GetComponent<Image>().sprite = normal;
                        actObjs[i].GetComponent<Image>().DOFade(1, 2);
                        actObjs[i].GetComponent<choose2Button>().ani.GetComponent<Image>().DOFade(1, 2).OnComplete(() =>
                        {
                            //Debug.Log("1");
                            foreach (var obj in actObjs)
                            {
                                //obj.GetComponent<Animator>().SetTrigger("trans");
                                obj.GetComponent<Button>().enabled = true;
                            }
                        });
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
