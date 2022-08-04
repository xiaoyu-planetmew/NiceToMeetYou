using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

public class sill : MonoBehaviour
{
    public Button button;
    public GameObject weather;
    public GameObject meditation;
    // Start is called before the first frame update
    void Start()
    {
        //this.GetComponent<BoxCollider2D>().enabled = false;
        button.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateinfo = this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);

        if ((stateinfo.IsName("appear1") && (stateinfo.normalizedTime >= 1.0f)) || (stateinfo.IsName("loop1")))
        {
            //this.GetComponent<BoxCollider2D>().enabled = true;
            button.enabled = true;
        }
        if (stateinfo.IsName("disappear") && (stateinfo.normalizedTime >= 1.0f))
        {
            //this.GetComponent<BoxCollider2D>().enabled = true;
            this.gameObject.SetActive(false);
            weather.SetActive(true);
            weather.GetComponent<WeatherChoose>().appear();
        }
    }
    public void meditationDisappear()
    {
        meditation.GetComponent<Image>().DOFade(0, 2).OnComplete(() => {
            meditation.SetActive(false);
        });
    }
    public void appear2()
    {
        
        AnimatorStateInfo stateinfo = this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);

        if (stateinfo.IsName("loop1"))
        {
            this.GetComponent<Animator>().SetTrigger("appear2");
        }
        
    }
    public void Disappear()
    {
        this.GetComponent<Animator>().SetTrigger("disappear");
    }
}
