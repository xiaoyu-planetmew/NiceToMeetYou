using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class choose1Button : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if(this.GetComponent<Button>())
        {
            if(this.GetComponent<Button>().enabled)
            {

                SoundManager.Instance.playSFX(2);
            }
        }
        else
        {

            SoundManager.Instance.playSFX(2);
        }
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        
    }
    public void onClick()
    {
        SoundManager.Instance.playSFX(3);
    }
}
