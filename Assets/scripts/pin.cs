using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class pin : MonoBehaviour
{
    private AudioSource click;
    private audioManager aM;
    public bool fell = false;
    public bool ignoreFalling = false;
    private void Start()
    {
        aM = GameObject.Find("AudioManager").GetComponent<audioManager>();
        click = gameObject.AddComponent<AudioSource>();
        click.clip = aM.pinClick;
        click.volume = aM.pinClickVolume;
        //click.clip();
    }

    public void playSound()
    {
        click.Play();
    }

    
}
