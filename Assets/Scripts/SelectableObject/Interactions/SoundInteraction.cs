using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundInteraction : MonoBehaviour, iInteraction
{
    public AudioSource audioSource;
    
    public bool IsActive()
    {
        return audioSource.isPlaying;
    }
    public void OnActivate()
    {
        audioSource.Play();
    }

    

}
