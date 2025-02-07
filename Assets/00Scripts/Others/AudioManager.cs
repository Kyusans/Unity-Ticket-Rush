using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource[] audioSource;

    void Start()
    {
        audioSource = GetComponents<AudioSource>();
    }

    public void PlayCoinAudioBridge()
    {
        audioSource[0].Play();
    }

    public void PlayTrapAudioPHRoom()
    {
        audioSource[1].Play();
    }
    
}
