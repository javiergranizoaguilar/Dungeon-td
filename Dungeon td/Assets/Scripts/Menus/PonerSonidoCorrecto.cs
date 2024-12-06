using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonerSonidoCorrecto : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource[] audioSourcesA;
    void Start()
    {
        audioSourcesA = FindObjectsOfType<AudioSource>();
        SetVolume();
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource[] audioSourcesP = FindObjectsOfType<AudioSource>();
        if (audioSourcesA.Length>audioSourcesP.Length)
        {
            SetVolume();
            audioSourcesA=audioSourcesP;
        }
    }
    void SetVolume()
    {
        float volume = PlayerPrefs.GetFloat("Volume", 1.0f);

        // Obtener todos los AudioSource en la escena 
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>(); // Ajustar el volumen de todos los AudioSource 
        foreach (AudioSource audioSource in audioSources) { audioSource.volume = volume; } // Guardar el nuevo volumen 
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
