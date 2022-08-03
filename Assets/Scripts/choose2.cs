using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class choose2 : MonoBehaviour
{
    public GameObject queren;
    public List<GameObject> buttons = new List<GameObject>();
    public List<Sprite> normal = new List<Sprite>();
    public List<Sprite> highlight = new List<Sprite>();
    public List<GameObject> actObjs = new List<GameObject>(); 
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
                buttons[i].GetComponent<Image>().sprite = highlight[i];
            }
            else
            {
                buttons[i].GetComponent<Image>().sprite = normal[i];
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
        actObjs[0] = actObjs[1];
        actObjs[1] = actObjs[2];
        actObjs[2] = obj;
        //obj.GetComponent<Image>().sprite = normal[index];
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
