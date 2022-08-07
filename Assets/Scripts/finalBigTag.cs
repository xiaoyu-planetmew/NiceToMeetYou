using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class finalBigTag : MonoBehaviour
{
    public List<GameObject> tagAnis = new List<GameObject>();
    public List<RuntimeAnimatorController> aniControllers = new List<RuntimeAnimatorController>();
    public GameObject choose2;
    public List<GameObject> tagImages = new List<GameObject>();
    public int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextImage()
    {
        if(index == 7)
        {
            this.GetComponent<Button>().enabled = false;
            SoundManager.Instance.playSFX(21);
            for (int i=0; i<6; i++)
            {
                tagImages[i].gameObject.GetComponent<Image>().DOFade(0, 2);
                tagImages[i].transform.GetChild(0).GetComponent<Image>().DOFade(0, 2);
            }
            tagImages[6].gameObject.GetComponent<Image>().DOFade(0, 2).OnComplete(() => {
                this.transform.parent.gameObject.GetComponent<finalShow>().bigTagDisappear();
                this.gameObject.SetActive(false);
            });
            tagImages[6].transform.GetChild(0).GetComponent<Image>().DOFade(0, 2);
            return;
        }
        this.GetComponent<Button>().enabled = false;
        DialogSys.Instance.dialogNext();
        tagImages[index].SetActive(true);
        int r = Random.Range(16, 20);
        SoundManager.Instance.playSFX(r);
        tagImages[index].gameObject.GetComponent<Image>().DOFade(1, 2).OnComplete(() => { 
            if(index == 0 || index == 2 || index == 4)
            {
                tagImages[index].gameObject.GetComponent<Animator>().SetTrigger("start");                
            }
            this.GetComponent<Button>().enabled = true;
            index++;
        });
        tagImages[index].transform.GetChild(0).GetComponent<Image>().DOFade(1, 2).OnComplete(() =>
        {
        });
    }
    public void tagAnisSet()
    {
        for(int i=0; i<tagAnis.Count; i++)
        {
            tagAnis[i].gameObject.GetComponent<Animator>().runtimeAnimatorController = 
                aniControllers[choose2.GetComponent<choose2>().actObjs[i].GetComponent<choose2Button>().num];
        }

        this.GetComponent<Button>().enabled = false;
        StartCoroutine(buttonDelay());
    }
    IEnumerator buttonDelay()
    {
        yield return new WaitForSeconds(2f);
            this.GetComponent<Button>().enabled = true;
    }
}
