using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayOnes : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip animationSound;
    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }
    // Este método será llamado por el evento de animación 
    public void PlaySound()
    {
        if (audioSource != null && animationSound != null)
        {
            audioSource.PlayOneShot(animationSound);
        }
    }

}
