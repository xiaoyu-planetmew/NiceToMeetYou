using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class choose1Button : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public bool soundActive = true;
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
            if (this.GetComponent<Button>().enabled)
            {
                if (soundActive)
                SoundManager.Instance.playSFX(2);
            }
        }
        else
        {
            if (soundActive)
                SoundManager.Instance.playSFX(2);
        }
        MouseSet.Instance.mouseChange(true);
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (soundActive)
            MouseSet.Instance.mouseChange(false);
    }
    public void onClick()
    {
        MouseSet.Instance.mouseChange(false);
        if (soundActive)
            SoundManager.Instance.playSFX(3);
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        MouseSet.Instance.mouseChange(false);
    }
}
