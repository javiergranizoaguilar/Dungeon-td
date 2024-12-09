using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AjustesSonido : MonoBehaviour
{
    public Slider volumeSlider; 
    void Start()
    {
        // Obtener el componente Slider 
        volumeSlider = gameObject.GetComponent<Slider>();
        // Cargar el volumen guardado y ajustar el slider 
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1.0f);
        volumeSlider.value = savedVolume;
        // Ajustar el volumen de todos los AudioSource actuales 
        SetVolume(savedVolume);
        // Suscribir el método SetVolume al evento onValueChanged del slider 
        volumeSlider.onValueChanged.AddListener(delegate { SetVolume(volumeSlider.value); });
    }
    void SetVolume(float volume)
    { // Obtener todos los AudioSource en la escena 
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>(); // Ajustar el volumen de todos los AudioSource 
        foreach (AudioSource audioSource in audioSources) { audioSource.volume = volume; } // Guardar el nuevo volumen 
        PlayerPrefs.SetFloat("Volume", volume);
    }
}