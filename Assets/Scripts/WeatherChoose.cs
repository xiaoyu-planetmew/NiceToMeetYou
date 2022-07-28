using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WeatherChoose : MonoBehaviour
{
    public GameObject baitian;
    public GameObject heiye;
    public GameObject qing;
    public GameObject yin;
    public GameObject yu;
    public GameObject queren;
    public Sprite baitian1;
    public Sprite baitian2;
    public Sprite heiye1;
    public Sprite heiye2;
    public Sprite qing1;
    public Sprite qing2;
    public Sprite yin1;
    public Sprite yin2;
    public Sprite yu1;
    public Sprite yu2;
    public bool day;
    public int weather;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(day)
        {
            baitian.GetComponent<Image>().sprite = baitian2;
            heiye.GetComponent<Image>().sprite = heiye1;
        }
        else
        {
            baitian.GetComponent<Image>().sprite = baitian1;
            heiye.GetComponent<Image>().sprite = heiye2;
        }
        if(weather == 1)
        {
            qing.GetComponent<Image>().sprite = qing2;
            yin.GetComponent<Image>().sprite = yin1;
            yu.GetComponent<Image>().sprite = yu1;
        }
        if (weather == 2)
        {
            qing.GetComponent<Image>().sprite = qing1;
            yin.GetComponent<Image>().sprite = yin2;
            yu.GetComponent<Image>().sprite = yu1;
        }
        if (weather == 3)
        {
            qing.GetComponent<Image>().sprite = qing1;
            yin.GetComponent<Image>().sprite = yin1;
            yu.GetComponent<Image>().sprite = yu2;
        }
    }
    public void dayAndNight(bool d)
    {
        day = d;
    }
    public void weatherChange(int i)
    {
        weather = i;
    }
    public void appear()
    {
        baitian.GetComponent<Image>().DOFade(1, 2).OnComplete(() => {
            baitian.GetComponent<Button>().enabled = true;
        });
        heiye.GetComponent<Image>().DOFade(1, 2).OnComplete(() => {
            heiye.GetComponent<Button>().enabled = true;
        });
        qing.GetComponent<Image>().DOFade(1, 2).OnComplete(() => {
            qing.GetComponent<Button>().enabled = true;
        });
        yin.GetComponent<Image>().DOFade(1, 2).OnComplete(() => {
            yin.GetComponent<Button>().enabled = true;
        });
        yu.GetComponent<Image>().DOFade(1, 2).OnComplete(() => {
            yu.GetComponent<Button>().enabled = true;
        });
        queren.GetComponent<Image>().DOFade(1, 2).OnComplete(() => {
            queren.GetComponent<Button>().enabled = true;
        });
    }
    public void finish()
    {
        baitian.GetComponent<Button>().enabled = false;
        heiye.GetComponent<Button>().enabled = false;
        qing.GetComponent<Button>().enabled = false;
        yin.GetComponent<Button>().enabled = false;
        yu.GetComponent<Button>().enabled = false;
        queren.GetComponent<Button>().enabled = false;
        if (day)
        {
            DialogSys.Instance.dialogStart(5);
        }
        else
        {
            DialogSys.Instance.dialogStart(6);
        }
        baitian.GetComponent<Image>().DOFade(0, 2).OnComplete(() => {
            baitian.GetComponent<Button>().enabled = false;
        });
        heiye.GetComponent<Image>().DOFade(0, 2).OnComplete(() => {
            heiye.GetComponent<Button>().enabled = false;
        });
        qing.GetComponent<Image>().DOFade(0, 2).OnComplete(() => {
            qing.GetComponent<Button>().enabled = false;
        });
        yin.GetComponent<Image>().DOFade(0, 2).OnComplete(() => {
            yin.GetComponent<Button>().enabled = false;
        });
        yu.GetComponent<Image>().DOFade(0, 2).OnComplete(() => {
            yu.GetComponent<Button>().enabled = false;
        });
        queren.GetComponent<Image>().DOFade(0, 2).OnComplete(() => {
            queren.GetComponent<Button>().enabled = false;
            
        });
        this.gameObject.SetActive(false);
    }
}
