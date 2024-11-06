using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Inicial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Niveles(){
        SceneManager.LoadScene("Menu_Niveles");
    }
    public void Salir(){
        Application.Quit();
    }
    public void Ajustes(){
        SceneManager.LoadScene("Menu_Ajustes");
    }
    public void Creditos(){
        SceneManager.LoadScene("Menu_Creditos");
    }
}
