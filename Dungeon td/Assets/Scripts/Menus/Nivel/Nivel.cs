using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Nivel : MonoBehaviour
{
    public List<BaseDatos.Nivel> niveles;
    private BaseDatos baseDatos;
    private GameObject CanvasD;
    private TextMeshProUGUI textoN;
    private TextMeshProUGUI textoF;
    private TextMeshProUGUI textoM;
    private TextMeshProUGUI textoD;

    private ControlNiveles controlNiveles;
    private Button button;
    private int nivel;


    // Start is called before the first frame update
    public void Awake()
    {

        inicializarV();
    }
    private void inicializarV()
    {
        GameObject objetoEncontradoF = GameObject.Find("FacilT");
        GameObject objetoEncontradoM = GameObject.Find("MedioT");
        GameObject objetoEncontradoD = GameObject.Find("DificilT");
        GameObject objetoEncontradoN = GameObject.Find("NivelesE");
        GameObject objetoEncontradoGameManager = GameObject.Find("GameManager");
        CanvasD = GameObject.Find("Dificultad");

        // Obtén el componente TextMeshProUGUI del objeto encontrado 
        textoF = objetoEncontradoF.GetComponent<TextMeshProUGUI>();
        textoM = objetoEncontradoM.GetComponent<TextMeshProUGUI>();
        textoD = objetoEncontradoD.GetComponent<TextMeshProUGUI>();
        textoN = objetoEncontradoN.GetComponent<TextMeshProUGUI>();
        baseDatos = objetoEncontradoGameManager.GetComponent<BaseDatos>();
        controlNiveles = objetoEncontradoGameManager.GetComponent<ControlNiveles>();
        back();
    }
    void Start()
    {
        baseDatos.CrearDB();
        niveles = baseDatos.ObtenerNivelesPorUsuario();
        int resolucionIndex = PlayerPrefs.GetInt("ResolucionIndex", 0); 
        Resolution resolucion = Screen.resolutions[resolucionIndex]; 
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);

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
                controlNiveles.ControlNivelesDisponiblesDificultad(result);
                nivel = result;
                CanvasD.GetComponent<Canvas>().enabled = true;
                textoN.text = "Nivel : " + nivel;
                textoF.text = "Puntos : " + Puntos(2);
                textoM.text = "Puntos : " + Puntos(1);
                textoD.text = "Puntos : " + Puntos(0);

            }
            else { Debug.LogError("El nombre del botón no contiene un número válido de nivel."); }
        }
        else { Debug.LogError("El nombre del botón no empieza con 'Nivel'."); }
    }
    
    public void back()
    {
        CanvasD.GetComponent<Canvas>().enabled = false;
    }
    public int Puntos(int i)
    {
        int index = (nivel * 3) - i;

        // Verificar que textoF no es nulo y que el índice está dentro del rango válido de la lista
        if (index <= niveles.Count)
        {
            return niveles[index - 1].Puntos;
        }
        else
        {
            Debug.LogError("IndexMAl");
            return 0;
        }
    }

    public void volverStart() { 
        SceneManager.LoadScene("Menu_Inicial");
    }
}
