using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class allAni : MonoBehaviour
{
    public int nowAni = 0;
    public List<RuntimeAnimatorController> anis = new List<RuntimeAnimatorController>();
    public List<Sprite> lastFrames = new List<Sprite>();
    public List<Sprite> firstFrames = new List<Sprite>();
    public GameObject staff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void allAniAppear()
    {
        
        this.GetComponent<Image>().sprite = firstFrames[nowAni];
        this.GetComponent<Image>().DOFade(1, 2f).OnComplete(() => {

            this.GetComponent<Animator>().speed = 1;
            Ani();
        });
    }
    public void Ani()
    {
        
        this.GetComponent<Animator>().runtimeAnimatorController = anis[nowAni];
        this.GetComponent<Animator>().SetTrigger("start");
    }
    public void nextAni()
    {
        if(nowAni == 9)
        {
            aniFinish();
            return;
        }
        this.GetComponent<Animator>().runtimeAnimatorController = null;
        this.GetComponent<Image>().sprite = lastFrames[nowAni];
        this.GetComponent<Animator>().speed = 0;
        Sequence quence = DOTween.Sequence();
        quence.Append(this.GetComponent<Image>().DOFade(0, 1).OnComplete(() => {
            nowAni++;
            Ani();
            this.GetComponent<Image>().sprite = firstFrames[nowAni];
        }));
        quence.Append(this.GetComponent<Image>().DOFade(1, 0.5f).OnComplete(() => {
            this.GetComponent<Animator>().speed = 1;
        }));
    }
    public void aniFinish()
    {
        this.GetComponent<Animator>().runtimeAnimatorController = null;
        this.GetComponent<Image>().sprite = lastFrames[nowAni];
        this.GetComponent<Animator>().speed = 0;
        for(int i=0; i<=5; i++)
        {
            var obj = staff.transform.GetChild(i);
            obj.GetComponent<Image>().DOFade(0, 2).OnComplete(() => {
                obj.gameObject.SetActive(false);
            });
        }
        //this.transform.parent.GetChild(6).gameObject.SetActive(true);
        //this.transform.parent.GetChild(6).gameObject.GetComponent<Image>().DOFade(1, 2f).OnComplete(() => {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //});
    }
    public void allAniStart()
    {
        this.transform.parent.gameObject.SetActive(true);
        this.gameObject.SetActive(true);
        //this.GetComponent<Animator>().speed = 0;
        for (int i = 0; i < 4; i++)
        {
            this.transform.parent.GetChild(i).gameObject.GetComponent<Image>().DOFade(1, 2f);
        }
        this.transform.parent.GetChild(5).gameObject.GetComponent<Image>().DOFade(1, 2f);
        allAniAppear();
    }
    public void allAniDelay()
    {
        DialogSys.Instance.nextButtonAct(false);
        StartCoroutine(dialog35Delay());
    }
    IEnumerator dialog35Delay()
    {
        yield return new WaitForSeconds(2f);
        DialogSys.Instance.dialogDisappear();
        StartCoroutine(after35());
    }
    IEnumerator after35()
    {
        yield return new WaitForSeconds(2f);
        allAniStart();
    }
}
