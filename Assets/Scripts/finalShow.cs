using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class finalShow : MonoBehaviour
{
    public GameObject bigTag;
    public GameObject boarder;
    public int dialogNum = 0;
    public bool finished = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void finalShowAppear()
    {
        this.gameObject.SetActive(true);
        boarder.SetActive(true);
        boarder.GetComponent<Animator>().SetTrigger("appear");
    }
    public void bigTagAppear()
    {
        bigTag.SetActive(true);
        bigTag.GetComponent<finalBigTag>().tagAnisSet();
        DialogSys.Instance.dialogStart(33);
    }
    public void bigTagDisappear()
    {
        boarder.GetComponent<Animator>().SetTrigger("fold");
        DialogSys.Instance.nextButtonAct(false);
        DialogSys.Instance.dialogFinish();
        DialogSys.Instance.dialogStart(34);
        StartCoroutine(dialogRepeat());
    }
    IEnumerator dialogRepeat()
    {
        while (dialogNum < 7 && !finished)
        {
            yield return new WaitForSeconds(3.0f); // first
            DialogSys.Instance.dialogNext();
            dialogNum++;
            //Specific functions put here 
            //Debug.Log(Time.time);   // then
            // Note the order of codes above.  Different order shows different outcome.
        }
    }
}
