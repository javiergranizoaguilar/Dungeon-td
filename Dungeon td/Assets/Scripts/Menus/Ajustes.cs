using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ajustes : MonoBehaviour
{
    public Dropdown resolucionDropdown;
    private Resolution[] resoluciones;

    void Start()
    {
        resoluciones = Screen.resolutions;
        resolucionDropdown.ClearOptions();

        List<string> opciones = new List<string>();
        int actualResolucionIndex = 0;

        for (int i = 0; i < resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
            opciones.Add(opcion);

            if (resoluciones[i].width == Screen.currentResolution.width &&
                resoluciones[i].height == Screen.currentResolution.height)
            {
                actualResolucionIndex = i;
            }
        }

        resolucionDropdown.AddOptions(opciones);
        resolucionDropdown.value = PlayerPrefs.GetInt("ResolucionIndex",actualResolucionIndex);
        resolucionDropdown.RefreshShownValue();

        resolucionDropdown.onValueChanged.AddListener(delegate { CambiarResolucion(resolucionDropdown.value); });
    }
    public void CambiarResolucion(int resolucionIndex)
    {
        Resolution resolucion = resoluciones[resolucionIndex];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
        PlayerPrefs.SetInt("ResolucionIndex", resolucionIndex);
    }
    public void ElejirUsuario()
    {
        SceneManager.LoadScene("Menu_Inicial");
    }
}
