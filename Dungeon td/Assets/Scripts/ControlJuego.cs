using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlJuego : MonoBehaviour
{

    public int dinero = 100;
    public int dineroF = 0;
    public int vidas = 100;
    public int Puntos = 0;
    public Control_mejoras control;
    private int rondas = 1;
    public TextMeshProUGUI dinerot;
    public TextMeshProUGUI vidast;
    public TextMeshProUGUI rondast;
    public TextMeshProUGUI infot;
    public TextMeshProUGUI DineroA;
    public TextMeshProUGUI DineroB;
    public TextMeshProUGUI infoA;
    public TextMeshProUGUI infoB;
    public bool Medio = false;
    public bool Dificil = false;
    public bool Facil = false;
    public bool Guardar = false;
    private const string Granja = "Granja(Clone)";
    private const string Psycokiller = "Psycokiller(Clone)";
    public Stoper stoper;
    public GameObject ButtonSeguir;
    public TextMeshProUGUI TextoFin;
    public oleadas oleadas;
    public GameObject[] prefab;
    // Start is called before the first frame update
    void Awake()
    {
        // Recupera un valor int desde PlayerPrefs usando la clave "MiBooleano". 
        // Si la clave no existe, se devuelve el valor predeterminado 0.
        Medio = PlayerPrefs.GetInt("Medio", 0) == 1;
        Dificil = PlayerPrefs.GetInt("Dificil", 0) == 1;
        Facil = PlayerPrefs.GetInt("Facil", 0) == 1;
        Guardar = PlayerPrefs.GetInt("Guardado", 0) == 1;
        PlayerPrefs.SetInt("Guardado", 0);
        PlayerPrefs.SetInt("Facil", 0);
        PlayerPrefs.SetInt("Medio", 0);
        PlayerPrefs.SetInt("Dificil", 0);
    }
    void Start()
    {
        int resolucionIndex = PlayerPrefs.GetInt("ResolucionIndex", 0); 
        Resolution resolucion = Screen.resolutions[resolucionIndex]; 
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
        if (Guardar)
        {
            dinero = oleadas.baseDatos.ObtenerPrimerNivelPorUsuarioNivelDificultad(oleadas.Dificultad).Dinero;
            vidas = oleadas.baseDatos.ObtenerPrimerNivelPorUsuarioNivelDificultad(oleadas.Dificultad).Vidas;
            rondas = oleadas.baseDatos.ObtenerPrimerNivelPorUsuarioNivelDificultad(oleadas.Dificultad).Ronda;
        }
        else
        {
            dineroF = dinero;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (vidas <= 0)
        {

            oleadas.Puntos();
            final(false);
        }
        vidast.text = "Vidas:" + vidas;
        dinerot.text = "Dinero:" + dinero;
        rondast.text = "Rondas:" + rondas;

        if (control.canvas.activeSelf)
        {
            int MejoraA = 0;
            int MejoraB = 0;
            string[] mejoraA = new string[3];
            string[] mejoraB = new string[3];
            int[] DmejoraA = new int[3];
            int[] DmejoraB = new int[3];
            if (control.granja != null)
            {
                MejoraA = control.granja.mejoraA;
                MejoraB = control.granja.mejoraB;
                mejoraA = control.granja.InfoA;
                mejoraB = control.granja.InfoB;
                DmejoraA = control.granja.DmejoraA;
                DmejoraB = control.granja.DmejoraB;
            }
            if (control.psycoKiller != null)
            {
                MejoraA = control.psycoKiller.mejoraA;
                MejoraB = control.psycoKiller.mejoraB;
                mejoraA = control.psycoKiller.InfoA;
                mejoraB = control.psycoKiller.InfoB;
                DmejoraA = control.psycoKiller.DmejoraA;
                DmejoraB = control.psycoKiller.DmejoraB;
            }
            if (control.db != null)
            {
                MejoraA = control.db.mejoraA;
                MejoraB = control.db.mejoraB;
                mejoraA = control.db.InfoA;
                mejoraB = control.db.InfoB;
                DmejoraA = control.db.DmejoraA;
                DmejoraB = control.db.DmejoraB;
            }

            if (MejoraA < 3)
            {
                DineroA.text = "Precio" + DmejoraA[MejoraA];
                infoA.text = mejoraA[MejoraA];
            }
            else
            {
                DineroA.text = "No mejorable";
                infoA.text = mejoraA[2];
            }
            if (MejoraB < 3)
            {
                DineroB.text = "Precio" + DmejoraB[MejoraB];
                infoB.text = mejoraB[MejoraB];

            }
            else
            {
                DineroA.text = "No mejorable";
                infoB.text = mejoraB[2]; ;
            }
        }
    }
    public int getRonda()
    {
        return rondas;
    }
    public void MasRonda()
    {
        rondas++;
    }
    public void instanciarTorres(List<BaseDatos.Torres> torre)
    {
        foreach (var t in torre)
        {
            string resultado = t.Nombre.Substring(0, t.Nombre.Length - 7);

            Vector3 posicion = new Vector3(t.PosX, t.PosY, 0.0f);
            switch (resultado)
            {
                case "Firerer":
                    GameObject torreInstanciadaFirerer = Instantiate(prefab[0], posicion, Quaternion.identity);
                    // Acceder al componente Torre del objeto instanciado y asignar la información específica 
                    Disparo_base torreComponenteFirerer = torreInstanciadaFirerer.GetComponent<Disparo_base>();
                    if (torreComponenteFirerer != null)
                    {
                        torreComponenteFirerer.mejoraA = t.MejoraA;
                        torreComponenteFirerer.mejoraB = t.MejoraB;
                    }
                    break;
                case "Frosti":
                    GameObject torreInstanciadaFrosti = Instantiate(prefab[1], posicion, Quaternion.identity);
                    // Acceder al componente Torre del objeto instanciado y asignar la información específica 
                    Disparo_base torreComponenteFrosti = torreInstanciadaFrosti.GetComponent<Disparo_base>();
                    if (torreComponenteFrosti != null)
                    {
                        torreComponenteFrosti.mejoraA = t.MejoraA;
                        torreComponenteFrosti.mejoraB = t.MejoraB;
                    }
                    break;
                case "Granja":
                    GameObject torreInstanciadaGranja = Instantiate(prefab[2], posicion, Quaternion.identity);
                    // Acceder al componente Torre del objeto instanciado y asignar la información específica 
                    Granja torreComponenteGranja = torreInstanciadaGranja.GetComponent<Granja>();
                    if (torreComponenteGranja != null)
                    {
                        torreComponenteGranja.mejoraA = t.MejoraA;
                        torreComponenteGranja.mejoraB = t.MejoraB;
                    }
                    break;
                case "Venom":
                    GameObject torreInstanciadaVenom = Instantiate(prefab[3], posicion, Quaternion.identity);
                    // Acceder al componente Torre del objeto instanciado y asignar la información específica 
                    Disparo_base torreComponenteVenom = torreInstanciadaVenom.GetComponent<Disparo_base>();
                    if (torreComponenteVenom != null)
                    {
                        torreComponenteVenom.mejoraA = t.MejoraA;
                        torreComponenteVenom.mejoraB = t.MejoraB;
                    }
                    break;
                case "Trampa":
                    GameObject torreInstanciadaTrampa = Instantiate(prefab[4], posicion, Quaternion.identity);
                    // Acceder al componente Torre del objeto instanciado y asignar la información específica 
                    break;
                case "Psycokiller":
                    GameObject torreInstanciadaPsycokiller = Instantiate(prefab[5], posicion, Quaternion.identity);
                    // Acceder al componente Torre del objeto instanciado y asignar la información específica 
                    PsycoKiller torreComponentePsycokiller = torreInstanciadaPsycokiller.GetComponent<PsycoKiller>();
                    if (torreComponentePsycokiller != null)
                    {
                        torreComponentePsycokiller.mejoraA = t.MejoraA;
                        torreComponentePsycokiller.mejoraB = t.MejoraB;
                    }
                    break;
            }
        }
    }
    public void final(bool g)
    {
        oleadas.baseDatos.EliminarTorresYGuardadosPorNivelYDificultad(oleadas.Dificultad);
        stoper.Stop();
        ButtonSeguir.SetActive(false);
        if (g)
        {
            TextoFin.text = "Ganaste /n Puntos:" + Puntos;
        }
        else
        {
            TextoFin.text = "Perdiste /n Puntos:" + Puntos;
        }
    }
    public void SalirNivel()
    {
        SceneManager.LoadScene("Menu_niveles");
    }
}