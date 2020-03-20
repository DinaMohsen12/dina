using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour
{
    public static SoundManger instance;
    private void Start()
    {
        if (instance == null)
            instance = this;
    }
    [SerializeField]
    AudioSource source;
    [SerializeField]
    AudioClip death, Jump;
    public void dethSoubd() {
        source.clip = null;
        source.clip = death;
        source.Play();
    
    }
    public void StairSoubd()
    {
        source.clip = null;
        source.clip = Jump;
        source.Play();

    }
}
