using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

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
    public int tagOpen;
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
}
