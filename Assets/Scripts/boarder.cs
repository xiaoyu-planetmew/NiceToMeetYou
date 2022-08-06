using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boarder : MonoBehaviour
{
    public GameObject allAni;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void boarderAppearFinish()
    {
        this.transform.parent.gameObject.GetComponent<finalShow>().bigTagAppear();
    }
    public void boarderFinish()
    {
        //DialogSys.Instance.dialogNext();
        this.gameObject.SetActive(false);
        //allAni.GetComponent<allAni>().allAniAppear();
    }
    public void boarderDisappear()
    {
        this.GetComponent<Animator>().SetTrigger("disappear");
        DialogSys.Instance.dialogStart(35);
        allAni.transform.parent.gameObject.SetActive(true);
        allAni.SetActive(true);

        allAni.GetComponent<allAni>().allAniDelay();
    }
    IEnumerator dialog35Delay()
    {
        yield return new WaitForSeconds(5f);
        DialogSys.Instance.dialogDisappear();
        StartCoroutine(after35());
    }
    IEnumerator after35()
    {
        yield return new WaitForSeconds(2f);
        DialogSys.Instance.afterDialogEvents[35].Invoke();
    }
}
