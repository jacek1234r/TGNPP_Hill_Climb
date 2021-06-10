using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radio : MonoBehaviour
{

    public GameObject soundGameObject;
    public AudioSource audioSource;
    public AudioSource audioSource1;

    public float volume = 0.7f;
    public static Radio obj;
    public bool radioMuteFlag = true;
    public float startSongTime;
    public SoundManager.RadioStations aktualnaStacja = SoundManager.RadioStations.Stacja1;

    public SoundAudioClip[] soundAudioClipArray;
    public RadioClipArray[] RadioArray;

    [System.Serializable]
    public class SoundAudioClip {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }

    [System.Serializable]
    public class RadioClipArray {
        public SoundManager.RadioStations sound;
        public AudioClip audioClip;
    }

    public void Awake() {
        if (obj == null) {
            obj = this;
            DontDestroyOnLoad(obj);
        }
    }

    void Start() {
        soundGameObject = new GameObject("Radio");
        audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource1 = soundGameObject.AddComponent<AudioSource>();
        //setVolume(0.5f);
        PlayNexStation();
        startSongTime = Time.time;
        //radioMute();////////////////////////////////////////
    }

    public void radioMute() {
        SoundManager.muteRadio();
    }

    public void setVolume(float vol) {
        volume = vol;
        if(radioMuteFlag == false) {
            startSongTime = SoundManager.restart(Time.time - startSongTime - 2, vol);
            startSongTime = Time.time;
        }
    }

    public void PlayNexStation() {
        //Radio.StartPlaying();
        if (this.radioMuteFlag == false) {
            SoundManager.NextStation( volume );
            startSongTime = Time.time;
        }
    }
}

public static class SoundManager {

    public enum Sound {
        ReachCheckpoint,
        Crash,
        fillTank
    }

    public enum RadioStations {
        Stacja1,
        Stacja2,
        Stacja3,
    }
    //static int ileStacji = 3; //doto: oblicz na podstawie d�ujgosci RadioArray

    public static void muteRadio() {
        if (Radio.obj.radioMuteFlag) {
            Radio.obj.radioMuteFlag = false;
            Radio.obj.audioSource.volume = Radio.obj.volume;
            Radio.obj.audioSource.Play();
        } else {
            Radio.obj.radioMuteFlag = true;
            Radio.obj.audioSource.Pause();
        }
    }

    public static void NextStation(float volume = -1) {
        Radio.obj.audioSource.clip = GetRadioStation();
        float size = Radio.obj.audioSource.clip.length;
        //Debug.Log(size);

        if (volume == -1) {
            Radio.obj.audioSource.volume = Radio.obj.volume;
        } else {
            Radio.obj.audioSource.volume = volume;
        }
        Radio.obj.audioSource.time = Random.Range(4f, size - 5f);
        Radio.obj.audioSource.loop = true;
        Radio.obj.audioSource.Play();
    }

    public static float restart( float lastClick, float newVol ) {
        //float newTime = audioSource.time;
        Radio.obj.audioSource.volume = newVol;
        Radio.obj.audioSource.time = Radio.obj.audioSource.time;// + lastClick;
        Radio.obj.audioSource.Play();
        return Radio.obj.audioSource.time;
    }

    public static void PlaySound(Sound sound) {
        //audioSource = soundGameObject.AddComponent<AudioSource>();
        Radio.obj.audioSource1.PlayOneShot(GetAudioClip(sound));
    }

    private static AudioClip GetAudioClip(Sound sound) {
        foreach (Radio.SoundAudioClip soundAudioClip in Radio.obj.soundAudioClipArray) {
            if (soundAudioClip.sound == sound) {
                return soundAudioClip.audioClip;
            }
        }
        return null;
    }

    private static AudioClip GetRadioStation() {
        bool flaga = false;
        foreach (Radio.RadioClipArray soundAudioClip in Radio.obj.RadioArray) {
            if (flaga == true) {
                Radio.obj.aktualnaStacja = soundAudioClip.sound;
                return soundAudioClip.audioClip;
            }

            if (soundAudioClip.sound == Radio.obj.aktualnaStacja) {
                flaga = true;
            }
        }

        if (flaga == true) {
            Radio.obj.aktualnaStacja = Radio.obj.RadioArray[0].sound;
            return Radio.obj.RadioArray[0].audioClip;
        }
        return null;
    }

    public static void RadioPlay() {
        SoundManager.NextStation();
    }
}
//SoundManager.PlaySound(SoundManager.Sound.Crash);
