using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public AudioSource SoundMusic;
    public AudioSource SoundEffect;

    public bool isMute=false;
    public float Volume = 1f;

    public SoundType[] Sound;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        setVolume(0.5f);
        BgMusic(global::Sounds.Backgrund);
    }
    public void setVolume(float volume)
    {
        Volume = volume;
        SoundMusic.volume = Volume;
        SoundEffect.volume = Volume;
    }
    public void BgMusic(Sounds sound)
    {
        if (isMute)
        {
            return;
        }
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            SoundMusic.clip = clip;
            SoundMusic.Play();
        }
    }
    public void Mute(bool status)
    {
        isMute = status;
    }
    public void Play(Sounds sound)
    {
        /*if (isMute)
        {
            return;
        }*/
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            SoundEffect.clip = clip;
            SoundEffect.Play();
        }
        else
        {
            Debug.LogError("Clip Not Found");
        }
    }

    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(Sound, item => item.soundType == sound);
        if (item != null)
        {
            return item.soundClip;
        }
        return null;
    }
}
[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;
}

public enum Sounds
{
    Backgrund,
    ButtonClicked,
    PlayerRun,
    PlayerWalk,
    PlayerJump,
    PlayerDeath,
    EnemyDeath
}
