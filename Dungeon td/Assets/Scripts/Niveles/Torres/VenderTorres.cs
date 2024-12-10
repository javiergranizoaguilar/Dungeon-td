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
    //Dependiendo del tipo de torre llama a un metodo el cual calcula el dinero que devolvera la torre 
    public void Vender()
    {
        Dineros = 0;
        switch (mejorasbasicas.control.torre.name)
        {
            case "Granja(Clone)":
                Granja g = mejorasbasicas.control.torre.GetComponent<Granja>();
                VenderTorreBasica(g.mejoraA, g.mejoraB, g.DmejoraA, g.DmejoraB);
                break;
            case "Trampa":
                break;
            case "Psycokiller(Clone)":
                PsycoKiller p = mejorasbasicas.control.torre.GetComponent<PsycoKiller>();
                VenderTorreBasica(p.mejoraA, p.mejoraB, p.DmejoraA, p.DmejoraB);
                break;
            default:
                Disparo_base db = mejorasbasicas.control.db;
                VenderTorreBasica(db.mejoraA, db.mejoraB, db.DmejoraA, db.DmejoraB);
                break;

        }
        control_Mejoras.Sal();
        mejorasbasicas.controlJuego.dinero += Dineros;

    }
    //Calcula el dinero a devolver de una torre
    public void VenderTorreBasica(int MejoraA, int MejoraB, int[] a, int[] b)
    {
        switch (MejoraA)
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
        switch (MejoraB)
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
