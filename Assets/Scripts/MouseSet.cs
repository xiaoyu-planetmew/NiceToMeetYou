using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Texture mouseTexture;

    void OnGUI()
    {
        Cursor.visible = false;//“˛≤ÿ Û±Í÷∏’Î
        GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, 20, 20), mouseTexture);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
