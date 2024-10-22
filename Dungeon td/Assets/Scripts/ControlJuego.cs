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

    public int rondas = 1;
    public TextMeshProUGUI dinerot;
    public TextMeshProUGUI vidast;
    public TextMeshProUGUI rondast;
    public TextMeshProUGUI infot;
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
    }
}
