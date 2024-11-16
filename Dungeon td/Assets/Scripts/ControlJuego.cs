using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ControlJuego : MonoBehaviour
{

    public int dinero = 100;
    public int dineroF;
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
    public Stoper stoper;
    public GameObject ButtonSeguir;
    public TextMeshProUGUI TextoFin;


    // Start is called before the first frame update
    void Awake()
    {
        // Recupera un valor int desde PlayerPrefs usando la clave "MiBooleano". 
        // Si la clave no existe, se devuelve el valor predeterminado 0.
        Medio = PlayerPrefs.GetInt("Medio", 0) == 1;
        Dificil = PlayerPrefs.GetInt("Dificil", 0) == 1;
        Facil = PlayerPrefs.GetInt("Facil", 0) == 1;
        PlayerPrefs.SetInt("Facil", 0);
        PlayerPrefs.SetInt("Medio", 0);
        PlayerPrefs.SetInt("Dificil", 0);
    }
    void Start()
    {
        dineroF = dinero;

    }

    // Update is called once per frame
    void Update()
    {
        if (vidas<=0){
            final(false);
        }
        vidast.text = "Vidas:" + vidas;
        dinerot.text = "Dinero:" + dinero;
        rondast.text = "Rondas:" + rondas;

        if (control.canvas.activeSelf)
        {
            if (control.db.mejoraA < 3)
            {
                DineroA.text = "Precio" + control.db.DmejoraA[control.db.mejoraA];
                infoA.text = control.db.InfoA[control.db.mejoraA];
            }
            else
            {
                DineroA.text = "No mejorable";
                infoA.text = control.db.InfoA[2];
            }
            if (control.db.mejoraB < 3)
            {
                DineroB.text = "Precio" + control.db.DmejoraB[control.db.mejoraB];
                infoB.text = control.db.InfoB[control.db.mejoraB];

            }
            else
            {
                DineroA.text = "No mejorable";
                infoB.text = control.db.InfoB[2];
            }
        }
    }
    public void final(bool g)
    {
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
}