using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundInteraction : MonoBehaviour, IInteraction
{
    public AudioSource audioSource;

    
    public bool IsActive()
    {
        return audioSource.isPlaying;
    }

    public void Activate()
    {
        audioSource.Play();
    }

}
