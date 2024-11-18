using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenderTorres : MonoBehaviour
{
    public Mejorasbasicas mejorasbasicas;
    public Control_mejoras control_Mejoras;
    public int Dineros = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Vender()
    {
        Debug.Log("Nombre de la torre: " + mejorasbasicas.control.torre.name);
        Dineros = 0;
        switch (mejorasbasicas.control.torre.name)
        {
            case "Triangle(Clone)":
                VenderTorreBasica();
                break;
        }
        control_Mejoras.Sal();
        mejorasbasicas.controlJuego.dinero += Dineros;

    }
    public void VenderTorreBasica()
    {
        int[] a = mejorasbasicas.control.db.DmejoraA;
        int[] b = mejorasbasicas.control.db.DmejoraA;
        switch (mejorasbasicas.control.db.mejoraA)
        {
            case 0:
                Dineros += 40;
                break;
            case 1:
                Dineros += (a[0] * 80) / 100;
                break;
            case 2:
                Dineros += (a[1] * 80) / 100;
                break;
            default:
                Dineros += (a[2] * 80) / 100;
                break;
        }
        switch (mejorasbasicas.control.db.mejoraB)
        {
            case 0:
                Dineros += 40;
                break;
            case 1:
                Dineros += (b[0] * 80) / 100;
                break;
            case 2:
                Dineros += (b[1] * 80) / 100;
                break;
            default:
                Dineros += (b[2] * 80) / 100;
                break;

        }
        Destroy(mejorasbasicas.control.torre);
    }
}
