using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFade : MonoBehaviour
{
    /*
     * ������audiosource���͵�gameobj�ϣ�ʹ��ʱ����objname.fadeMusic(volume,time)
     */
    // Start is called before the first frame update
    [SerializeField] private AudioSource Music;
    [SerializeField] private float volumeDelta;
    [SerializeField] private float targetvolume;

    [SerializeField] private bool volDecrease;
    [SerializeField] private bool isfading;
    void Start()
    {
        Music = GetComponent<AudioSource>();
        volumeDelta = 0;
        volDecrease = false;
        isfading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isfading) return;
        if (Mathf.Abs(Music.volume - targetvolume) >= Mathf.Abs(volumeDelta))
        {
            Music.volume += (float)volumeDelta;
            //Debug.Log("fading...");
        }
        else
        {
            Music.volume = targetvolume;
            isfading = false;
        }
    }

    public void FadeMusic(float targetVolume/*0-1*/, float durtime/*seconds*/)
    {
        Debug.Log("Music fade set target = " + targetVolume);
        targetvolume = targetVolume;
        if (Music == null) Music = GetComponent<AudioSource>();
        float timedelta = durtime / Time.deltaTime;
        if (timedelta > 0)
            volumeDelta = (targetVolume - Music.volume) / timedelta;
        else
        {
            volumeDelta = (targetVolume - Music.volume);
        }

        isfading = true;
    }

    public void FadeOut()
    {
        FadeMusic(0, 1);
    }

    public void FadeIn()
    {
        FadeMusic(0.5f, 1);
    }

}
