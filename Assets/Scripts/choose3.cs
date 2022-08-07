using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class choose3 : MonoBehaviour
{
    public UnityEvent afterEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void choose3Appear()
    {
        this.gameObject.SetActive(true);
        this.transform.GetChild(0).gameObject.GetComponent<Image>().DOFade(1, 2).OnComplete(() => {
            this.transform.GetChild(0).gameObject.GetComponent<Button>().enabled = true;
        });
        this.transform.GetChild(1).gameObject.GetComponent<Image>().DOFade(1, 2).OnComplete(() => {
            this.transform.GetChild(1).gameObject.GetComponent<Button>().enabled = true;
        });
        this.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().DOFade(1, 2);
        this.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Text>().DOFade(1, 2);
    }
    public void choose3Disappear()
    {
        DialogSys.Instance.dialogDisappear();
        this.transform.GetChild(0).gameObject.GetComponent<Button>().enabled = false;
        this.transform.GetChild(0).gameObject.GetComponent<Button>().enabled = false;
        this.transform.GetChild(0).gameObject.GetComponent<Image>().DOFade(0, 2).OnComplete(() => {
            this.gameObject.SetActive(false);
            afterEvent.Invoke();
        });
        this.transform.GetChild(1).gameObject.GetComponent<Image>().DOFade(0, 2).OnComplete(() => {
           
        });
        this.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().DOFade(0, 2);
        this.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Text>().DOFade(0, 2);
    }
}
