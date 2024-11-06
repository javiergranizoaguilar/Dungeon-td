using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlJuego : MonoBehaviour
{

    public int dinero = 100;
    public int vidas = 100;
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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        vidast.text = "Vidas:" + vidas;
        dinerot.text = "Dinero:" + dinero;
        rondast.text = "Rondas:" + rondas;
        if (control.canvas.activeSelf)
        {
            DineroA.text = "Precio" + control.db.DmejoraA[control.db.mejoraA];
            DineroB.text = "Precio" + control.db.DmejoraB[control.db.mejoraB];
            infoA.text = control.db.InfoA[control.db.mejoraA];
            infoB.text = control.db.InfoB[control.db.mejoraB];
        }
    }
}