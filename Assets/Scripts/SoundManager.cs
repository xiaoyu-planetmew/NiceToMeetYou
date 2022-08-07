using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public List<AudioClip> SFXs = new List<AudioClip>();
    public List<float> SFXVolume = new List<float>();
    public GameObject SFX;
    public List<AudioClip> BGMs = new List<AudioClip>();
    public List<float> BGMVolume = new List<float>();
    public GameObject BGM;
    public GameObject BGM1;
    public float BGM1Volume;
    public GameObject BGM2;
    public float BGM2Volume;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playSFX(int i, bool loop = false)
    {
        SFX.GetComponent<AudioSource>().Stop();
        SFX.GetComponent<AudioSource>().loop = loop;
        if (loop)
        {
            SFX.GetComponent<AudioSource>().clip = SFXs[i];
            SFX.GetComponent<AudioSource>().Play();
        }
        else
        SFX.GetComponent<AudioSource>().PlayOneShot(SFXs[i]);
        SFX.GetComponent<AudioSource>().volume = SFXVolume[i];
    }
    public void rainEnd()
    {
        SFX.GetComponent<MusicFade>().FadeMusic(0, 2);
    }
    public void playBGM(int i)
    {
        StartCoroutine(playBGMDelay(i));        
    }
    IEnumerator playBGMDelay(int i)
    {
        BGM2.GetComponent<MusicFade>().FadeMusic(0, 1);
        BGM.GetComponent<MusicFade>().FadeMusic(0, 1);
        yield return new WaitForSeconds(1);
        BGM1.GetComponent<AudioSource>().Stop();
        BGM2.GetComponent<AudioSource>().Stop();
        BGM.GetComponent<AudioSource>().Stop();
        if(i == 0)
        {
            BGM.GetComponent<AudioSource>().loop = true;
        }
        if(i == 1)
        {
            BGM.GetComponent<AudioSource>().loop = false;
        }
        BGM.GetComponent<AudioSource>().clip = BGMs[i];
        BGM.GetComponent<AudioSource>().Play();
        BGM.GetComponent<MusicFade>().FadeMusic(BGMVolume[i], 1);
    }
    public void doubleBGMStart()
    {
        BGM1.GetComponent<AudioSource>().Play();
        BGM1.GetComponent<AudioSource>().volume = BGM1Volume;
        BGM2.GetComponent<AudioSource>().Play();
        BGM2.GetComponent<AudioSource>().volume = 0;
    }
    public void BGMEnd()
    {
        BGM.GetComponent<MusicFade>().FadeMusic(0, 5);
    }
    public void doubleBGMEnd()
    {
        //BGM1.GetComponent<MusicFade>().FadeMusic(0, 1);
        BGM2.GetComponent<MusicFade>().FadeMusic(0, 5);
    }
    public void BGMChange()
    {
        BGM1.GetComponent<MusicFade>().FadeMusic(0, 1);
        BGM2.GetComponent<MusicFade>().FadeMusic(BGM2Volume, 1);
    }
}
