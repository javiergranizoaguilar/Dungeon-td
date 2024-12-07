using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlResolution : MonoBehaviour
{
    // Start is called before the first frame update
    private Resolution[] resoluciones;
    void Start()
    {
        // Obtener todas las resoluciones disponibles 
        resoluciones = Screen.resolutions;
        // Obtener la resolución guardada o establecer la mejor resolución por defecto 
        int resolucionIndex = PlayerPrefs.GetInt("ResolucionIndex", resoluciones.Length - 1);
        // Asegurarse de que el índice está dentro del rango de resoluciones disponibles 
        if (resolucionIndex >= 0 && resolucionIndex < resoluciones.Length)
        {
            CambiarResolucion(resolucionIndex);
        }
    }
    public void CambiarResolucion(int resolucionIndex)
    {
        // Verificar si el índice de resolución es válido 
        if (resolucionIndex >= 0 && resolucionIndex < resoluciones.Length)
        {
            Resolution resolucion = resoluciones[resolucionIndex];
            Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
            PlayerPrefs.SetInt("ResolucionIndex", resolucionIndex);
        }
        else
        {
            Debug.LogError("Índice de resolución inválido.");
        }
    }
}