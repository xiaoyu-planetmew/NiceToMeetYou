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
    bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tagOpen >= 4 && !finished)
        {
            finished = true;
            disappear();
        }
    }
    public void appear()
    {
        //this.GetComponent<Image>().enabled = true;
        //this.GetComponent<Animator>().SetTrigger("appear");
        //start = true;
        this.gameObject.SetActive(true);
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
    public void disappear()
    {
        StartCoroutine(disappearDelay());
    }
    IEnumerator disappearDelay()
    {
        yield return new WaitForSeconds(2.5f);
        DialogSys.Instance.dialogFinish();
        dikuang.GetComponent<Image>().DOFade(0, 2).OnComplete(() => {
            DialogSys.Instance.meditationAppear();
            DialogSys.Instance.dialogStart(18);
            DialogSys.Instance.nextButton.SetActive(true);
            DialogSys.Instance.nextButtonAct(true);
            this.gameObject.SetActive(false);
        }
        );
        tag1.GetComponent<Image>().DOFade(0, 2);
        tag2.GetComponent<Image>().DOFade(0, 2);
        tag3.GetComponent<Image>().DOFade(0, 2);
        tag4.GetComponent<Image>().DOFade(0, 2);
    }
}
