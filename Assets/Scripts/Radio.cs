using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Radio : MonoBehaviour
{
    public float volume = 1;
    public static Radio obj;
    public bool radioMuteFlag = true;
    public float startSongTime;
    public SoundManager.RadioStations aktualnaStacja = SoundManager.RadioStations.Stacja1;

    public SoundAudioClip[] soundAudioClipArray;
    public RadioClipArray[] RadioArray;

    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }

    [System.Serializable]
    public class RadioClipArray
    {
        public SoundManager.RadioStations sound;
        public AudioClip audioClip;
    }

    public void Awake()
    {
        if (obj == null) {
            obj = this;
            DontDestroyOnLoad(obj);
        }
    }
    void Start()
    {
        PlayNexStation();
        startSongTime = Time.time;
        radioMute();////////////////////////////////////////

    }
    public void radioMute()
    {
        SoundManager.muteRadio();
    }
    public void setVolume(float vol)
    {
        volume = vol;
        if(radioMuteFlag == false)
        {
            startSongTime = SoundManager.restart(Time.time - startSongTime - 2, vol);
            startSongTime = Time.time;
        }
        
    }
    public void PlayNexStation()
    {
        //Radio.StartPlaying();
        if (this.radioMuteFlag == false)
        {
            SoundManager.NextStation( volume );
            startSongTime = Time.time;
        }
    }
}



public static class SoundManager
{
    static public GameObject soundGameObject = new GameObject("Radio");
    static public AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
    static public AudioSource audioSource1 = soundGameObject.AddComponent<AudioSource>();


    public enum Sound
    {
        ReachCheckpoint,
        Crash,
        fillTank
    }
    public enum RadioStations
    {
        Stacja1,
        Stacja2,
        Stacja3,
    }
    //static int ileStacji = 3; //doto: oblicz na podstawie d�ujgosci RadioArray

    public static void muteRadio()
    {
        if (Radio.obj.radioMuteFlag)
        {
            Radio.obj.radioMuteFlag = false;
            //audioSource.volume = Radio.obj.volume;
            audioSource.Play();
        }
        else
        {
            Radio.obj.radioMuteFlag = true;
            audioSource.Pause();
        }
    }

    public static void NextStation(float volume = -1)
    {
        audioSource.clip = GetRadioStation();
        float size = audioSource.clip.length;
        //Debug.Log(size);

        if (volume == -1)
        {
            audioSource.volume = Radio.obj.volume;

        }
        else
        {
            audioSource.volume = volume;
        }
        audioSource.time = Random.Range(4f, size - 5f);
        audioSource.loop = true;
        audioSource.Play();
    }
    public static float restart( float lastClick, float newVol )
    {
        //float newTime = audioSource.time;
        audioSource.volume = newVol;
        audioSource.time = audioSource.time;// + lastClick;
        audioSource.Play();
        return audioSource.time;
    }

    public static void PlaySound(Sound sound)
    {
        //audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource1.PlayOneShot(GetAudioClip(sound));
    }
    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (Radio.SoundAudioClip soundAudioClip in Radio.obj.soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        return null;
    }
    private static AudioClip GetRadioStation()
    {
        bool flaga = false;
        foreach (Radio.RadioClipArray soundAudioClip in Radio.obj.RadioArray)
        {
            if (flaga == true)
            {
                Radio.obj.aktualnaStacja = soundAudioClip.sound;
                return soundAudioClip.audioClip;

            }
            if (soundAudioClip.sound == Radio.obj.aktualnaStacja)
            {
                flaga = true;
            }

        }
        if (flaga == true)
        {
            Radio.obj.aktualnaStacja = Radio.obj.RadioArray[0].sound;
            return Radio.obj.RadioArray[0].audioClip;
        }
        return null;
    }
    public static void RadioPlay()
    {
        SoundManager.NextStation();
    }
}
//SoundManager.PlaySound(SoundManager.Sound.Crash);