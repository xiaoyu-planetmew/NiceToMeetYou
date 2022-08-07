using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class magic : MonoBehaviour
{
    public GameObject point;
    public GameObject mofatuan;
    public GameObject mofazhouyu;
    public bool mofatuanSelected = false;
    public bool mofazhouyuSelected = false;
    public GameObject countDown;
    public UnityEvent afterEvent;
    public GameObject button;
    public GameObject zhishi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void magicAppear()
    {
        this.gameObject.SetActive(true);
        DialogSys.Instance.dialogStart(27);
        DialogSys.Instance.nextButtonAct(false);
        point.SetActive(true);
        point.GetComponent<Image>().DOFade(1, 2).OnComplete(() => {
            StartCoroutine(magicAppearDelay1());
        });
    }
    IEnumerator magicAppearDelay1()
    {
        yield return new WaitForSeconds(2.5f);
        DialogSys.Instance.dialogNext();
        StartCoroutine(magicAppearDelay());
    }
    IEnumerator magicAppearDelay()
    {
        yield return new WaitForSeconds(3f);
        //DialogSys.Instance.dialogNext();
        zhishi.SetActive(true);
        zhishi.GetComponent<Animator>().SetTrigger("appear");
        button.SetActive(true);
        button.GetComponent<Image>().DOFade(1, 2).OnComplete(() => {
            button.GetComponent<Button>().enabled = true;
        });
        button.transform.GetChild(0).GetComponent<Text>().DOFade(1, 2);
    }
    public void magicAppear2()
    {
        DialogSys.Instance.dialogDisappear();
        button.GetComponent<Button>().enabled = false;
        zhishi.GetComponent<Animator>().speed = 0;
        zhishi.GetComponent<Animator>().enabled = false;
        zhishi.GetComponent<Image>().DOFade(0, 2).OnComplete(() => {
            zhishi.SetActive(false);
            //StartCoroutine(mufatuanAppearDelay());
        });
        button.GetComponent<Image>().DOFade(0, 2).OnComplete(() => {
            button.SetActive(false);
            mofatuanAppear();
            //StartCoroutine(mufatuanAppearDelay());
        });
        button.transform.GetChild(0).GetComponent<Text>().DOFade(0, 2);
        
        

    }
    public void mofatuanAppear()
    {
        DialogSys.Instance.dialogStart(28);
        mofatuan.SetActive(true);
        for(int i=0; i<3; i++)
        {
            GameObject obj = mofatuan.transform.GetChild(i).gameObject;
            obj.gameObject.GetComponent<Image>().DOFade(1, 2).OnComplete(() => {
                obj.GetComponent<Button>().enabled = true;
            });
        }
    }
    IEnumerator mufatuanAppearDelay()
    {
        yield return new WaitForSeconds(2f);
        mofatuanAppear();
    }
    public void mofatuanSelect()
    {
        mofatuanSelected = true;
    }
    public void mofatuanQueren()
    {
        if(mofatuanSelected)
        {
            DialogSys.Instance.dialogDisappear();
            for (int i = 0; i < 2; i++)
            {
                GameObject obj = mofatuan.transform.GetChild(i).gameObject;
                obj.gameObject.GetComponent<Image>().DOFade(0, 2).OnComplete(() => {
                    obj.GetComponent<Button>().enabled = false;
                });
            }
            mofatuan.transform.GetChild(2).gameObject.GetComponent<Image>().DOFade(0, 2).OnComplete(() => {
                mofatuan.transform.GetChild(2).GetComponent<Button>().enabled = false;
                point.GetComponent<Animator>().SetTrigger("react1Appear");
                setToReact1();
                mofatuan.SetActive(false);
                StartCoroutine(mofazhouyuAppearDelay());
            });
        }
    }
    IEnumerator mofazhouyuAppearDelay()
    {
        yield return new WaitForSeconds(2f);
        mofazhouyuAppear();
    }
    public void mofazhouyuAppear()
    {
        DialogSys.Instance.dialogStart(29);
        mofazhouyu.SetActive(true);
        for (int i = 0; i < 3; i++)
        {
            GameObject obj = mofazhouyu.transform.GetChild(i).gameObject;
            if (obj.GetComponentsInChildren<Transform>(true).Length > 1)
            {
                obj.transform.GetChild(0).gameObject.GetComponent<Text>().DOFade(1, 2);
            }
            obj.gameObject.GetComponent<Image>().DOFade(1, 2).OnComplete(() => {
                obj.GetComponent<Button>().enabled = true;
            });
        }
    }
    public void mofazhouyuSelect()
    {
        mofazhouyuSelected = true;
    }
    public void mofazhouyuQueren()
    {
        if (mofazhouyuSelected)
        {
            DialogSys.Instance.dialogDisappear();
            for (int i = 0; i < 2; i++)
            {
                GameObject obj = mofazhouyu.transform.GetChild(i).gameObject;
                if (obj.GetComponentsInChildren<Transform>(true).Length > 1)
                {
                    obj.transform.GetChild(0).gameObject.GetComponent<Text>().DOFade(0, 2);
                }
                obj.gameObject.GetComponent<Image>().DOFade(0, 2).OnComplete(() => {
                    obj.GetComponent<Button>().enabled = false;
                });
            }
            mofazhouyu.transform.GetChild(2).gameObject.GetComponent<Image>().DOFade(0, 2).OnComplete(() => {
                mofazhouyu.transform.GetChild(2).GetComponent<Button>().enabled = false;
                point.GetComponent<Animator>().SetTrigger("react1Disappear");
                StartCoroutine(react2AppearDelay());
                mofazhouyu.SetActive(false);
                StartCoroutine(react3AppearDelay());
            });
        }
    }
    IEnumerator react2AppearDelay()
    {
        yield return new WaitForSeconds(0.5f);
        setToReact2();
        point.GetComponent<Animator>().SetTrigger("react2Appear");
        DialogSys.Instance.dialogStart(30);
    }
    IEnumerator react3AppearDelay()
    {
        yield return new WaitForSeconds(4.5f);
        react3Appear();
    }
    public void react3Appear()
    {
        setToReact3();
        point.GetComponent<Animator>().SetTrigger("react3Appear");
        StartCoroutine(dialog31Delay());
    }
    IEnumerator dialog31Delay()
    {
        yield return new WaitForSeconds(4f);
        DialogSys.Instance.dialogStart(31);
        DialogSys.Instance.nextButtonAct(true);
        //StartCoroutine(countDownAppearDelay());
    }
    IEnumerator countDownDelay()
    {
        yield return new WaitForSeconds(2f);
        countDown.GetComponent<Animator>().enabled = true;
    }
    public void countDownAppear()
    {
        countDown.SetActive(true);

        StartCoroutine(countDownDelay());
        DialogSys.Instance.dialogDisappear();
        StartCoroutine(countDownFinishDelay());
    }
    IEnumerator countDownFinishDelay()
    {
        yield return new WaitForSeconds(5.25f);
        countDown.SetActive(false);
        setToFlower();
        point.GetComponent<Animator>().SetTrigger("flower");
        StartCoroutine(flowerDelay());
    }
    IEnumerator flowerDelay()
    {
        yield return new WaitForSeconds(2f);
        DialogSys.Instance.dialogStart(32);
        DialogSys.Instance.nextButtonAct(true);
    }
    public void magicDisappear()
    {
        DialogSys.Instance.dialogDisappear();
        point.GetComponent<Image>().DOFade(0, 2).OnComplete(() => {
            afterEvent.Invoke();
        });
    }
    public void setToReact1()
    {
        point.GetComponent<RectTransform>().sizeDelta = new Vector2(354, 358);
    }
    public void setToReact2()
    {
        point.GetComponent<RectTransform>().sizeDelta = new Vector2(699, 654);
    }
    public void setToReact3()
    {
        point.GetComponent<RectTransform>().sizeDelta = new Vector2(432, 387);
    }
    public void setToFlower()
    {
        point.GetComponent<RectTransform>().sizeDelta = new Vector2(1074.6f, 972);
    }
}
