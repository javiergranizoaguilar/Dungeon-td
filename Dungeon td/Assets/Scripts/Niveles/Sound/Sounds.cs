using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sounds : MonoBehaviour
{

    public AudioSource audioSource;
    private static Sounds instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
            if (audioSource == null)
            {
                audioSource = GetComponent<AudioSource>();
            }
            PlayMusic();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    //Cuando carga la escena hace esto
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.StartsWith("Nivel"))
        {
            Destroy(gameObject);
        }
    }
    //Inicia la musica
    public void PlayMusic()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
    //Para la musica
    public void StopMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}