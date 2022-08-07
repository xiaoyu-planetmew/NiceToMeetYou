using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;
public class DialogSys : MonoBehaviour
{
    public static DialogSys Instance;
    [Header("eventNum")]
    public int eventNum;
    //public GameObject player;
    //public GameObject npc;
    //public GameObject cam;
    public GameObject textLabel;
    public GameObject textLabelEN;
    public GameObject textBackground;
    //public GameObject startButton;
    public GameObject nextPageButton;
    public List<TextAsset> textfilesCN = new List<TextAsset>();
    public List<TextAsset> textfilesEN = new List<TextAsset>();
    public List<TextAsset> textfilesJP = new List<TextAsset>();
    //public GameObject sceneTransButton;
    public List<TextAsset> textfiles = new List<TextAsset>();
    public List<UnityEvent> afterDialogEvents = new List<UnityEvent>();

    //public List<TextAsset> textfilesE = new List<TextAsset>();
    //public List<TextAsset> textfilesJ = new List<TextAsset>();
    //public bool firstMeet;
    public bool isTalking = false;
    //private bool holdTarget;
    public int index;
    public List<string> textList = new List<string>();
    public List<string> textListEN = new List<string>();
    public List<string> textTalker = new List<string>();
    public float textSpeed;
    public List<AudioClip> leftAudio = new List<AudioClip>();
    public List<AudioClip> rightAudio = new List<AudioClip>();
    [SerializeField]bool textFinished;
    public string output;
    int textNum;
    public GameObject nextButton;
    public GameObject meditation;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        textfiles.Clear();
        if (GameObject.Find("Manager").GetComponent<LanguageManager>())
        {
            for (int i = 0; i < textfilesCN.Count; i++)
            {
                if (LanguageManager.Instance.LanguageNum == 0) textfiles.Add(textfilesCN[i]);
                if (LanguageManager.Instance.LanguageNum == 1) textfiles.Add(textfilesEN[i]);
                if (LanguageManager.Instance.LanguageNum == 2) textfiles.Add(textfilesJP[i]);
            }
        }
        else
        {
            for (int i = 0; i < textfilesCN.Count; i++)
            {
                textfiles.Add(textfilesCN[i]);
            }
        }
        //firstMeet = true;        
    }
    // Update is called once per frame
    void Update()
    {
        if (isTalking && textFinished)
        {
            if (Input.anyKeyDown)
            {
                //DialogSys.Instance.dialogNext();
                //SoundController.Instance.Button_Off.HandleEvent(gameObject);
            }

        }

        /*
        if((Mathf.Abs(npc.transform.position.x - player.transform.position.x) <= 5) && !isTalking)
        {
            startButton.SetActive(true);
        }
        if((Mathf.Abs(npc.transform.position.x - player.transform.position.x) > 5))
        {
            startButton.SetActive(false);
        }
        */
    }
    public void dialogStart(int Num)
    {
        //if (!isTalking)
        //{
            index = 0;
            GetTextFromFile(textfiles[Num]);
            GetTextFromFileEN(textfilesEN[Num]);
            eventNum = Num;
            fileChoose();
        //}
    }
    public void nextButtonAct(bool act)
    {
        if(act)
        {
            nextButton.GetComponent<Button>().enabled = true;
        }
        else
        {
            nextButton.GetComponent<Button>().enabled = false;
        }
    }
    public void dialogNext()
    {
        if (textFinished)
        {
            if (index >= textList.Count)
            {
                index = 0;
                //SoundController.Instance.Talk_Radio_Stop.HandleEvent(gameObject);
                textBackground.gameObject.SetActive(false);
                //nextPageButton.gameObject.SetActive(false);

                //textLabelcn.gameObject.SetActive(false);
                //textLabelen.gameObject.SetActive(false);
                isTalking = false;
                afterDialogEvents[eventNum].Invoke();

                return;
                //TutorialTrackController.Instance.FinishTutorial();
            }
            if (index < textList.Count && isTalking)
            {
                //SoundController.Instance.Talk_Buzz.HandleEvent(gameObject);
                //StartCoroutine(SetText());
                SetText();
                textBackground.gameObject.SetActive(true);
                Debug.Log("next");
            }
        }
    }
    public void dialogFinish()
    {
        textList.Clear();
        textListEN.Clear();
        textTalker.Clear();
        textFinished = true;
        isTalking = false;
        index = 0;
        //SoundController.Instance.Talk_Radio_Stop.HandleEvent(gameObject);
        textBackground.gameObject.SetActive(false);
        //nextPageButton.gameObject.SetActive(false);

        //textLabelcn.gameObject.SetActive(false);
        //textLabelen.gameObject.SetActive(false);
        isTalking = false;
        Debug.Log("finish");
        //afterDialogEvents[eventNum].Invoke();
    }
    public void dialogDisappear()
    {
        textLabel.GetComponent<Text>().DOFade(0, 2);
        textLabelEN.GetComponent<Text>().DOFade(0, 2).OnComplete(() => {
            dialogFinish();
        });
    }
    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        
        textTalker.Clear();
        var lineData = file.text.Split('#');
        foreach (var line in lineData)
        {
            //Debug.Log(line);
            textList.Add(line);
        }
        //Debug.Log(textList.Count);
        textList.RemoveAt(textList.Count - 1);
        //textList.RemoveAt(textList.Count);
        /*
        for(int j = 0; j < textList.Count; j++)
        {
            if(textList[j][0] == '1')
            {
                textList[j] = textList[j].Substring(1);
                textTalker.Add("left");
            }
            if(textList[j][0] == '2')
            {
                textList[j] = textList[j].Substring(1);
                textTalker.Add("right");
            }
        }
        */
    }
    void GetTextFromFileEN(TextAsset file)
    {
        textListEN.Clear();
        //textTalker.Clear();
        var lineData = file.text.Split('#');
        foreach (var line in lineData)
        {
            //Debug.Log(line);
            textListEN.Add(line);
        }
        //Debug.Log(textList.Count);
        textListEN.RemoveAt(textListEN.Count - 1);
        //textList.RemoveAt(textList.Count);
        /*
        for(int j = 0; j < textList.Count; j++)
        {
            if(textList[j][0] == '1')
            {
                textList[j] = textList[j].Substring(1);
                textTalker.Add("left");
            }
            if(textList[j][0] == '2')
            {
                textList[j] = textList[j].Substring(1);
                textTalker.Add("right");
            }
        }
        */
    }
    /*
    public void languageChange()
    {
        textfiles.Clear();
        if(GameManager.instance.languageNum == 0)
        {
            for(int i=0; i<textfilesJ.Count; i++)
            {
                textfiles.Add(textfilesJ[i]);
            }
        }
        if(GameManager.instance.languageNum == 1)
        {
            for(int i=0; i<textfilesE.Count; i++)
            {
                textfiles.Add(textfilesE[i]);
            }
        }
    }
    */
    public void fileChoose()
    {

        /*
        for (int i = 0; i < GameManager.instance.items.Count; i++)
        {
            if(GameManager.instance.items[i] == target)
            {
                GetTextFromFile(textfiles[1]);
                holdTarget = true;
            }
            else
            {
                GetTextFromFile(textfiles[2]);
                holdTarget = false;
            }
        }
        */

        //startButton.gameObject.SetActive(false);
        //nextPageButton.gameObject.SetActive(true);
        //textLabelcn.gameObject.SetActive(true);
        //textLabelen.gameObject.SetActive(true);
        index = 0;
        textBackground.gameObject.SetActive(true);
        //SoundController.Instance.Talk_Radio_Play.HandleEvent(gameObject);
        //textLabelleft.GetComponent<Text>().text = textList[index];
        //nextPageButton.SetActive(false);
        //StartCoroutine(SetText());
        SetText();
        //leftAudioRandom();
        isTalking = true;
        //Time.timeScale = 0.0f;
        //GameManager.instance.isPaused = true;

        //textLabelcn.GetComponent<TMP_Text>().text = textList[index];
        //textLabelen.GetComponent<TMP_Text>().text = textList[index + 1];

        //startButton.SetActive(false);
    }
    void leftAudioRandom()
    {
        this.GetComponent<AudioSource>().enabled = false;
        this.GetComponent<AudioSource>().enabled = true;

        StopCoroutine("audioChangeLeft");
        StopCoroutine("audioChangeRight");
        StartCoroutine(audioStop());

        //Debug.Log(i);
        if (!this.GetComponent<AudioSource>().isPlaying && this.GetComponent<AudioSource>().enabled == true)
        {
            StartCoroutine(audioChangeLeft());
        }

    }
    void rightAudioRandom()
    {

        this.GetComponent<AudioSource>().enabled = false;
        this.GetComponent<AudioSource>().enabled = true;

        StopCoroutine("audioChangeLeft");
        StopCoroutine("audioChangeRight");
        StartCoroutine(audioStop());

        //Debug.Log(i);
        if (!this.GetComponent<AudioSource>().isPlaying && this.GetComponent<AudioSource>().enabled == true)
        {
            StartCoroutine(audioChangeRight());
        }
    }
    void SetText()
    {
        textFinished = false;
        textLabel.GetComponent<Text>().text = textList[index];
        textLabel.GetComponent<Text>().color = new Color32(50, 50, 50, 0);
        textLabelEN.GetComponent<Text>().text = textListEN[index];
        textLabelEN.GetComponent<Text>().color = new Color32(50, 50, 50, 0);
        textLabelEN.GetComponent<Text>().DOFade(1, 2);
        textLabel.GetComponent<Text>().DOFade(1, 2).OnComplete(() =>
        {
            index = index + 1;
            textFinished = true;
            Debug.Log("set");
        });
    }
    /*
    IEnumerator SetText()
    {

        
        
        textLabel.GetComponent<Text>().text = "";
        for (int i = 0; i < textList[index].Length; i++)
        {
            //Debug.Log(i);
            textLabel.GetComponent<Text>().text += textList[index][i];
            yield return new WaitForSeconds(textSpeed);
        }
        
    index = index + 1;
        textFinished = true;
    }*/

    IEnumerator audioStop()
    {
        yield return new WaitForSeconds(((textList[index].Length) * textSpeed));
        this.GetComponent<AudioSource>().Stop();
        this.GetComponent<AudioSource>().enabled = false;
        StopCoroutine("audioChangeLeft");
        StopCoroutine("audioChangeRight");
    }
    IEnumerator audioChangeLeft()
    {
        int i = Random.Range(0, leftAudio.Count);
        while (this.GetComponent<AudioSource>().enabled == true && textTalker[index] == "left")
        {
            i = Random.Range(0, leftAudio.Count);
            this.GetComponent<AudioSource>().clip = leftAudio[i];
            this.GetComponent<AudioSource>().Play();
            //Debug.Log("left");
            yield return new WaitForSeconds(leftAudio[i].length);
        }

        //StartCoroutine(audioChangeLeft());
    }
    IEnumerator audioChangeRight()
    {
        int i = Random.Range(0, rightAudio.Count);
        while (this.GetComponent<AudioSource>().enabled == true && textTalker[index] == "right")
        {
            i = Random.Range(0, rightAudio.Count);
            this.GetComponent<AudioSource>().clip = rightAudio[i];
            this.GetComponent<AudioSource>().Play();
            //Debug.Log("right");
            yield return new WaitForSeconds(rightAudio[i].length);
        }

        //StartCoroutine(audioChangeRight());
    }
    public void meditationAppear()
    {
        meditation.SetActive(true);
        meditation.GetComponent<Image>().DOFade(1, 2);
    }
    public void meditationDisappear()
    {
        meditation.GetComponent<Image>().DOFade(0, 2).OnComplete(() => {
            meditation.SetActive(false);
        });
    }
}
