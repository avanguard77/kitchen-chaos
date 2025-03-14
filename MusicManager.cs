using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    
    public static MusicManager Instance{get; private set;}
    
    private float volume;
    private const string Player_PrefsKey_Music = "MusicManager";
    private AudioSource audioSource;

    private void Awake()
    {
        
        Instance = this;
        audioSource = GetComponent<AudioSource>();
        volume=PlayerPrefs.GetFloat(Player_PrefsKey_Music,3f);
        audioSource.volume = volume;
    }

    public void ChangeVolume()
    {
        volume+=0.01f;
        if (volume>1f)
        {
            volume = 0;
        }
        audioSource.volume = volume;
        PlayerPrefs.SetFloat(Player_PrefsKey_Music, volume);
        PlayerPrefs.Save();
    }

    public float GetVolume()
    {
        return volume;
    }
}
