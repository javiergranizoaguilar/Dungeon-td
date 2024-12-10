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
    public int rondas = 1;
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
        // Recupera un valor int desde PlayerPrefs 
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
        //Pone la Resolucion indicada anteriormente o la predeterminada de tu pc
        int resolucionIndex = PlayerPrefs.GetInt("ResolucionIndex", 0);
        Resolution resolucion = Screen.resolutions[resolucionIndex];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);

        //Instancia en caso de tener guardado una partida esos datos
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
        vidast.text = vidas.ToString();
        dinerot.text = dinero.ToString();
        rondast.text = "Ronda: "+rondas;

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
    //Devuelve la ronda
    public int getRonda()
    {
        return rondas;
    }
    //Incrementa la ronda
    public void MasRonda()
    {
        rondas++;
    }
    //Instancia las torres si se tenian guardadas y asin lo desea el jugador
    public void instanciarTorres(List<BaseDatos.Torres> torre)
    {
        foreach (var t in torre)
        {
            string resultado = t.Nombre.Substring(0, t.Nombre.Length - 7);
            //Consigue la posicion del objeto
            Vector3 posicion = new Vector3(t.PosX, t.PosY, 0.0f);
            //Mira cual es y le asocia sus cosas
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
    //Se activa cuando se acaba una partida tanto gnada como perdida 
    // g== Ganada ease que si g =true as ganado la partida
    public void final(bool g)
    {
        oleadas.baseDatos.EliminarTorresYGuardadosPorNivelYDificultad(oleadas.Dificultad);
        stoper.Stop();
        ButtonSeguir.SetActive(false);
        
        if (g)
        {
            Puntos=vidas*dinero;
            TextoFin.text = "Ganaste Puntos:" + Puntos;
        }
        else
        {
            Puntos=1*dinero;
            TextoFin.text = "Perdiste Puntos:" + Puntos;
        }
    }
    //Te devuelve a el Menu de niveles
    public void SalirNivel()
    {
        SceneManager.LoadScene("Menu_niveles");
    }
}