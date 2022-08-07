using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class tiezhi2Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playSFX(int i)
    {
        SoundManager.Instance.playSFX(i);
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        MouseSet.Instance.mouseChange(true);
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        MouseSet.Instance.mouseChange(false);
    }
    public void onClick()
    {
        MouseSet.Instance.mouseChange(false);
    }
}
