using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class TagSlider : MonoBehaviour
{
    public GameObject tiezhi;
    public Animator anim;
    public Slider slider;
    public UnityEvent afterEvent;
    public bool actived = false;
    public int SFX1;
    public int SFX2;
    public bool soundPlayed1 = false;
    public bool soundPlayed2 = false;
    //public GameObject animAbove;
    // Start is called before the first frame update
    void Start()
    {
        //slider = this.GetComponent<Slider>();
        anim.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        anim.Play("open", -1, slider.value);
        if(slider.value >= 0.99f)
        {
            if (!actived) afterAnim();
        }
        if(slider.value >= 0.2f && !soundPlayed1)
        {
            soundPlayed1 = true;
            SoundManager.Instance.playSFX(SFX1);
        }
    }
    void afterAnim()
    {
        slider.gameObject.SetActive(false);
        anim.enabled = false;
        actived = true;

        SoundManager.Instance.playSFX(SFX2);
        if (afterEvent != null)
        {
            afterEvent.Invoke();
        }
        anim.gameObject.GetComponent<Image>().DOFade(0, 2).OnComplete(() =>
        {
            tiezhi.GetComponent<tiezhi>().tagOpen++;
            
            //animAbove.SetActive(true);
            //animAbove.GetComponent<Image>().DOFade(1, 2);
        }
        );
    }
    void OnMouseEnter()
    {
        //slider.OnPointerDown.Invoke();
    }
}
