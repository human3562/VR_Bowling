using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioClip pinClick;
    [Range(0, 1)]
    public float pinClickVolume;

    public AudioClip strike;
    [Range(0, 1)]
    public float strikeVolume;

    public AudioClip music;
    [Range(0, 1)]
    public float musicVolume;

    private AudioSource source;
    private AudioSource musicSource;
    private void Start()
    {
        source = GetComponent<AudioSource>();

        musicSource = gameObject.AddComponent<AudioSource>();
        //musicSource.clip = music;
        //musicSource.volume = musicVolume;
        //musicSource.Play();
    }


    private void Update()
    {
        musicSource.volume = musicVolume;
    }

    public void playStrike()
    {
        source.clip = strike;
        source.volume = strikeVolume;
        source.Play();
    }
}
