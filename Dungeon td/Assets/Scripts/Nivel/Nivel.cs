using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nivel : MonoBehaviour
{

    public BaseDatos baseDatos;
    public GameObject CanvasD;
    protected List<BaseDatos.Nivel> niveles;

    private Button button; 
    private int nivel;
    

    // Start is called before the first frame update
    void Start()
    {
        niveles = baseDatos.ObtenerNivelesPorUsuario();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void NivelI()
    {
        button = GetComponent<Button>();
        // Extrae el número del nivel del nombre del botón 
        string buttonName = button.name;
        if (buttonName.StartsWith("Nivel"))
        {
            if (int.TryParse(buttonName.Substring(6), out int result))
            {
                nivel = result;
                CanvasD.SetActive(true);
                Debug.Log("Nivel." + nivel);
            }
            else { Debug.LogError("El nombre del botón no contiene un número válido de nivel."); }
        }
        else { Debug.LogError("El nombre del botón no empieza con 'Nivel'."); }
    }
    public void back(){
        CanvasD.SetActive(false);
    }
}
