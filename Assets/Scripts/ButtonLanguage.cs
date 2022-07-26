using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLanguage : MonoBehaviour
{
    public string strCN;
    public Font FontCN;
    public string strJP;
    public Font FontJP;
    // Start is called before the first frame update
    void Start()
    {
        if (LanguageManager.Instance.LanguageNum == 0)
        {
            this.GetComponent<Text>().text = strCN;
            this.GetComponent<Text>().font = FontCN;
            this.transform.parent.GetChild(1).GetComponent<Text>().font = FontCN;
            this.GetComponent<Text>().fontSize = 56;
        }
        ;
        if (LanguageManager.Instance.LanguageNum == 2)
        {
            this.GetComponent<Text>().text = strJP;
            this.GetComponent<Text>().font = FontJP;
            this.transform.parent.GetChild(1).GetComponent<Text>().font = FontJP;
            this.GetComponent<Text>().fontSize = 50;
        };
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.parent.GetChild(1).GetComponent<Text>().color = this.GetComponent<Text>().color;
    }
}