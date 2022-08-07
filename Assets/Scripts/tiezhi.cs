using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;

public class tiezhi : MonoBehaviour
{
    public GameObject tag1;
    public GameObject tag2;
    public GameObject tag3;
    public GameObject tag4;
    public GameObject tag1Ani;
    public GameObject tag2Ani;
    public GameObject tag3Ani;
    public GameObject tag4Ani;
    public GameObject tag1Under;
    public GameObject tag2Under;
    public GameObject tag3Under;
    public GameObject tag4Under;
    public int tagOpen = 0;
    public bool finish = false;
    public UnityEvent afterEvent;
    public UnityEvent afterEvent1;
    public UnityEvent afterEvent2;
    public GameObject bigTag;
    public GameObject meditation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tagOpen >= 4 && !finish)
        {
            finish = true;
            tag1.SetActive(false);
            tag2.SetActive(false);
            tag3.SetActive(false);
            tag4.SetActive(false);
            tag1Ani.SetActive(false);
            tag2Ani.SetActive(false);
            tag3Ani.SetActive(false);
            tag4Ani.SetActive(false);
            //tag1Under.SetActive(false);
            //tag2Under.SetActive(false);
            //tag3Under.SetActive(false);
            //tag4Under.SetActive(false);
            //this.gameObject.GetComponent<Image>().enabled = false;
            bigTag.SetActive(true);
            bigTag.GetComponent<Animator>().SetTrigger("appear");
            DialogSys.Instance.dialogNext();
            DialogSys.Instance.isTalking = false;
            afterEvent.Invoke();
            StartCoroutine(autoDialog());
        }
        if (bigTag.activeInHierarchy) { 
        AnimatorStateInfo stateinfo = bigTag.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);

        if (stateinfo.IsName("bigTagLoop"))
        {
            bigTag.transform.Find("Button").gameObject.SetActive(true);
        }
        else
        {
            bigTag.transform.Find("Button").gameObject.SetActive(false);
        }
        if(stateinfo.IsName("bigTagOpen") && stateinfo.normalizedTime >= 1.0f)
        {
            afterEvent1.Invoke();
        }
        }
    }
    IEnumerator autoDialog()
    {
        yield return new WaitForSeconds(3f);
        DialogSys.Instance.dialogNext();
        bigTag.transform.Find("Button").gameObject.SetActive(true);
    }
    public void appear()
    {
        meditation.GetComponent<Image>().DOFade(0, 2).OnComplete(() => {
            meditation.SetActive(false);
        });
        this.gameObject.SetActive(true);
        this.gameObject.GetComponent<Image>().DOFade(1, 2);
        tag1Ani.GetComponent<Image>().DOFade(1, 2).OnComplete(() =>
        {
            tag1Ani.GetComponent<Animator>().enabled = true;
            tag1.transform.GetChild(0).gameObject.SetActive(true);
            tag1Under.gameObject.SetActive(true);
        });
        tag2Ani.GetComponent<Image>().DOFade(1, 2).OnComplete(() =>
        {
            tag2Ani.GetComponent<Animator>().enabled = true;
            tag2.transform.GetChild(0).gameObject.SetActive(true);
            tag2Under.gameObject.SetActive(true);
        });
        tag3Ani.GetComponent<Image>().DOFade(1, 2).OnComplete(() =>
        {
            tag3Ani.GetComponent<Animator>().enabled = true;
            tag3.transform.GetChild(0).gameObject.SetActive(true);
            tag3Under.gameObject.SetActive(true);
        });
        tag4Ani.GetComponent<Image>().DOFade(1, 2).OnComplete(() =>
        {
            tag4Ani.GetComponent<Animator>().enabled = true;
            tag4.transform.GetChild(0).gameObject.SetActive(true);
            tag4Under.gameObject.SetActive(true);
        });
    }
    public void bigTagOpen()
    {
        StartCoroutine(aniDisappear());
    }
    IEnumerator aniDisappear()
    {
        yield return new WaitForSeconds(0.35f);
        tag1Under.SetActive(false);
        tag2Under.SetActive(false);
        tag3Under.SetActive(false);
        tag4Under.SetActive(false);
        this.gameObject.GetComponent<Image>().enabled = false;
        afterEvent2.Invoke();
    }
}
