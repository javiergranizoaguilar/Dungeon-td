using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlNiveles : MonoBehaviour
{
    public BaseDatos baseDatos;
    public GameObject[] Buttons;
    public GameObject[] ButtonsG;
    private long Nivel;

    // Start is called before the first frame update
    void Start()
    {
        ControlNivelesDisponibles();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ControlNivelesDisponibles()
    {
        BaseDatos.Nivel[] l = baseDatos.ObtenerNivelesPorUsuario().ToArray();
        int n = 0;
        for (int i = 0; i < l.Length; i++)
        {
            if (i % 3 == 0)
            {
                if (l[i].Desbloqueado == false)
                {

                    CambioColor(ButtonsG[l[i].nivel - 1].GetComponent<Button>());
                    DesactivarBoton(ButtonsG[l[i].nivel - 1].GetComponent<Button>());


                }
                else
                {
                    ResetColor(ButtonsG[l[i].nivel - 1].GetComponent<Button>());
                    ActivarBoton(ButtonsG[l[i].nivel - 1].GetComponent<Button>());
                }
                n += 3;
            }
        }
    }
    public void ControlNivelesDisponiblesDificultad(long i)
    {
        Nivel = i;
        long n = (i - 1) * 3;
        BaseDatos.Nivel[] l = baseDatos.ObtenerNivelesPorUsuario().ToArray();
        for (long a = n; a < i * 3; a++)
        {
            if (l[a].Desbloqueado == false)
            {
                CambioColor(Buttons[a - n].GetComponent<Button>());
                DesactivarBoton(Buttons[a - n].GetComponent<Button>());
            }
            else
            {
                ActivarBoton(Buttons[a - n].GetComponent<Button>());
            }
        }
    }
    public void CambioColor(Button button)
    {
        ColorBlock cb = button.colors;
        cb.normalColor = Color.red;
        cb.highlightedColor = Color.red;
        cb.pressedColor = Color.red;
        cb.selectedColor = Color.red;
        cb.disabledColor = Color.gray;
        // Por ejemplo, gris cuando está deshabilitado 
        // Asigna el ColorBlock al botón 
        button.colors = cb;
    }
    public void ResetColor(Button button)
    {
        ColorBlock cb = button.colors;

        // Estos son los valores predeterminados del ColorBlock
        cb.normalColor = Color.white; // o cualquier otro color por defecto
        cb.highlightedColor = new Color(0.882f, 0.882f, 0.882f); // Gris claro por defecto
        cb.pressedColor = new Color(0.698f, 0.698f, 0.698f); // Gris más oscuro por defecto
        cb.selectedColor = Color.white; // o cualquier otro color por defecto
        cb.disabledColor = new Color(0.784f, 0.784f, 0.784f); // Gris claro por defecto para deshabilitado

        // Asigna el ColorBlock actualizado al botón
        button.colors = cb;
    }
    public void NivelEleccionF()
    {
        SceneManager.LoadScene("Nivel_" + Nivel);
        bool Facil = true;
        //es un if else mas corto si miBooleano es true pilla asta " : " si no pilla lo de detras
        PlayerPrefs.SetInt("Facil", Facil ? 1 : 0);
        SceneManager.LoadScene("Nivel_" + Nivel);
    }
    public void NivelEleccionM()
    {
        bool medio = true;
        //es un if else mas corto si miBooleano es true pilla asta " : " si no pilla lo de detras
        PlayerPrefs.SetInt("Medio", medio ? 1 : 0);
        SceneManager.LoadScene("Nivel_" + Nivel);
    }

    public void NivelEleccionD()
    {
        bool dificil = true;
        //es un if else mas corto si miBooleano es true pilla asta " : " si no pilla lo de detras
        PlayerPrefs.SetInt("Dificil", dificil ? 1 : 0);
        SceneManager.LoadScene("Nivel_" + Nivel);
    }

    public void DesactivarBoton(Button miBoton)
    {
        // Desactiva la capacidad de clic del botón 
        if (miBoton != null) { miBoton.interactable = false; }
    }
    public void ActivarBoton(Button miBoton)
    {
        // Activa la capacidad de clic del botón 
        if (miBoton != null) { miBoton.interactable = true; }
    }
}
