using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class startButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject logo;
    public Sprite start2;
    // Start is called before the first frame update
    void Start()
    {
        //this.GetComponent<Animator>().SetTrigger("start");
        startSequence();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateinfo = this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);

        if (stateinfo.IsName("startbuttonidle"))
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    public void OnMouseEnter()
    {
        this.GetComponent<Animator>().enabled = false;
        this.GetComponent<SpriteRenderer>().sprite = start2;
    }
    public void OnMouseExit()

    {
        this.GetComponent<Animator>().enabled = true;
        this.GetComponent<Animator>().SetTrigger("idle");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Sequence quence = DOTween.Sequence();
        this.GetComponent<Animator>().enabled = false;
        this.GetComponent<SpriteRenderer>().sprite = start2;
        quence.Append(logo.GetComponent<SpriteRenderer>().DOFade(0, 5).OnComplete(() =>
        {
            logo.SetActive(false);
        }));
        quence.Join(this.GetComponent<SpriteRenderer>().DOFade(0, 5).OnComplete(() => 
        {
            DialogSys.Instance.dialogStart(0);
            this.gameObject.SetActive(false);
        }));
        this.GetComponent<startButton>().enabled = false;
    }
    void startSequence()
    {
        logo.GetComponent<SpriteRenderer>().DOFade(1, 5).OnComplete(() => {
            this.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<Animator>().SetTrigger("start");
        });
    }
    
}
