using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;

public class tiezhi2 : MonoBehaviour
{
    public GameObject dikuang;
    public GameObject tag1;
    public GameObject tag2;
    public GameObject tag3;
    public GameObject tag4;
    public int tagOpen = 0;
    //bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void appear()
    {
        //this.GetComponent<Image>().enabled = true;
        //this.GetComponent<Animator>().SetTrigger("appear");
        //start = true;
        tagShow();
    }
    public void tagShow()
    {
        dikuang.SetActive(true);
        
            tag1.SetActive(true);
            tag2.SetActive(true);
            tag3.SetActive(true);
            tag4.SetActive(true);
            buttonShow();
        
    }
    public void buttonShow()
    {
        tag1.transform.Find("Button").gameObject.SetActive(true);
        tag2.transform.Find("Button").gameObject.SetActive(true);
        tag3.transform.Find("Button").gameObject.SetActive(true);
        tag4.transform.Find("Button").gameObject.SetActive(true);
    }
    public void buttonAct(GameObject obj)
    {
        obj.GetComponent<Animator>().SetTrigger("loop");
        tagOpen++;
    }
}
