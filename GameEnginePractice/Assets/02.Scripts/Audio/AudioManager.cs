using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{ 
    [SerializeField] private AudioClip[] audioClip = new AudioClip[10];

    private AudioSource audioSource;

    protected override void Awake()
    {
        base.Awake();
        if (!IsSingletonInstance())
            return;

        audioSource = GetComponent<AudioSource>();
        SetAudioClip("MainBGM");
    }

    public AudioClip ReturnAudioClip(string name)
    {
        AudioClip clip = GetComponent<AudioClip>();
        switch(name)
        {
            case "ButtonClick":
                clip = audioClip[0];
                break;
            case "Clock":
                clip = audioClip[1];
                break;
            case "GameOverBGM":
                clip = audioClip[2];
                break;
            case "GetCandy":
                clip = audioClip[3];
                break;
            case "Hit":
                clip = audioClip[4];
                break;
            case "MainBGM":
                clip = audioClip[5];
                break;
            case "PuzzleClick":
                clip = audioClip[6];
                break;
            case "Fail":
                clip = audioClip[7];
                break;
            case "Success":
                clip = audioClip[8];
                break;
            case "Run":
                clip = audioClip[9];
                break;
            default:
                clip = null;
                break;
        }
        return clip;
    }

    public void SetAudioClip(string name)
    {
        audioSource.clip = ReturnAudioClip(name);
        audioSource.Play();
    }
}
