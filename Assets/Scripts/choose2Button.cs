using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class choose2Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Sprite normal;
    public Sprite highlight;
    public bool acted;
    public bool inButton;
    public GameObject ani;
    public int num;
    // Start is called before the first frame update
    void Start()
    {
        normal = this.transform.parent.gameObject.GetComponent<choose2>().normal;
        highlight = this.transform.parent.gameObject.GetComponent<choose2>().highlight;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.parent.gameObject.GetComponent<choose2>().actObjs.Contains(this.gameObject))
        {
            this.GetComponent<Image>().sprite = highlight;
        }
        else
        {
            if(inButton)
            {
                this.GetComponent<Image>().sprite = highlight;
            }
            else
            {
                this.GetComponent<Image>().sprite = normal;
            }
        }
    }
    public void buttonAct(bool b)
    {
        acted = b;
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        inButton = true;
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        inButton = false;
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        this.transform.parent.gameObject.GetComponent<choose2>().buttonPressed(this.gameObject);
    }
}
