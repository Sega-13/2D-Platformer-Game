using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }
    public SoundType[] SoundList;
    public AudioSource soundEffect;
    public AudioSource soundMusic;
    public bool isMute = false;
    public float volume = 1f;
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
        PlayMusic(Sounds.Music);
    }
    public void Mute(bool status)
    {
        isMute = status;
    }
    public void SetVolume(float volume)
    {
        this.volume = volume;
        soundEffect.volume = volume;
        soundMusic.volume = volume;
    }
    public void PlayMusic(Sounds sound)
    {
        if (isMute)
            return;
        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
        }
        else
        {
            Debug.Log("No Audio clip found for this sound type");
        }

    }
    public void Play(Sounds sound)
    {
        if (isMute)
            return;
        AudioClip clip = GetSoundClip(sound);
        if(clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("No Audio clip found for this sound type");
        }
    }
    private AudioClip GetSoundClip(Sounds sound)
    {
        SoundType type =  Array.Find(SoundList, item => item.soundType == sound);
        if (type != null)
            return type.soundClip;
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
    ButtonClick,
    Music,
    PlayerMove,
    PlayerDeath,
    EnemyDeath,
    LevelStart,
    LevelFinish,
    LevelOver,
    
}
