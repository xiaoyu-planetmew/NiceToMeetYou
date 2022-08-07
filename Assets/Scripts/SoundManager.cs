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
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
    public void playBGM(int i)
    {
        BGM.GetComponent<AudioSource>().clip = BGMs[i];
        BGM.GetComponent<AudioSource>().Play();
    }
}
