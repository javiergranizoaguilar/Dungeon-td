using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mejorasbasicas : MonoBehaviour
{
    public Control_mejoras control;
    public ControlJuego controlJuego;

    private const string Firerer = "Firerer(Clone)";
    private const string Frosti = "Frosti(Clone)";
    private const string Venom = "Venom(Clone)";
    private const string Granja = "Granja(Clone)";
    private const string Psycokiller = "Psycokiller(Clone)";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ButtonD()
    {
        if (control.psycoKiller != null)
        {
            if (control.psycoKiller.ApuntadoDisparo > 3)
            {
                control.psycoKiller.ApuntadoDisparo = 0;
            }
            else
            {
                control.psycoKiller.ApuntadoDisparo++;
            }
        }
        else
        {
            if (control.db.ApuntadoDisparo > 3)
            {
                control.db.ApuntadoDisparo = 0;
            }
            else
            {
                control.db.ApuntadoDisparo++;
            }

        }
        control.controlcanvas();
    }
    public void ButtonI()
    {
        if (control.psycoKiller != null)
        {
            if (control.psycoKiller.ApuntadoDisparo < 0)
            {
                control.psycoKiller.ApuntadoDisparo = 3;
            }
            else
            {
                control.psycoKiller.ApuntadoDisparo--;
            }
        }
        else
        {
            if (control.db.ApuntadoDisparo < 0)
            {
                control.db.ApuntadoDisparo = 3;
            }
            else
            {
                control.db.ApuntadoDisparo--;
            }

        }
        control.controlcanvas();
    }
    public bool valido(int n, bool pathA)
    {
        int MejoraA = 0;
        int MejoraB = 0;
        int[] DmejoraA;
        int[] DmejoraB;
        switch (control.torre.gameObject.name)
        {
            case Granja:
                MejoraA = control.granja.mejoraA;
                MejoraB = control.granja.mejoraB;
                DmejoraA = control.granja.DmejoraA;
                DmejoraB = control.granja.DmejoraB;
                break;
            case Psycokiller:
                MejoraA = control.psycoKiller.mejoraA;
                MejoraB = control.psycoKiller.mejoraB;
                DmejoraA = control.psycoKiller.DmejoraA;
                DmejoraB = control.psycoKiller.DmejoraB;
                break;
            default:
                MejoraA = control.db.mejoraA;
                MejoraB = control.db.mejoraB;
                DmejoraA = control.db.DmejoraA;
                DmejoraB = control.db.DmejoraB;
                break;
        }
        if (pathA)
        {
            if (DmejoraA[n] <= controlJuego.dinero)
            {
                return true;
            }
            else { return false; }
        }
        else
        {
            if (DmejoraB[n] <= controlJuego.dinero)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
    public void ButonA1()
    {
        if (valido(0, true))
        {
            switch (control.torre.name)
            {
                case Firerer:
                    control.db.fireDistance *= 2;
                    control.db.speedB += 1;
                    control.db.fireRate -= 1;
                    break;
                case Frosti:
                    control.db.fireDistance *= 2;
                    control.db.fireRate -= 1;
                    control.db.projectilePrefab.GetComponent<Movimien_Bala>().ralentiza -= 0.3f;
                    break;
                case Granja:
                    Granja g = control.torre.GetComponent<Granja>();
                    g.Dinero *= 2;
                    break;
                case Venom:
                    control.db.danio++;
                    break;
                case Psycokiller:
                    PsycoKiller p = control.torre.GetComponent<PsycoKiller>();
                    p.danio += 2;
                    break;
            }
            if (control.torre.GetComponent<Disparo_base>() != null)
            {
                controlJuego.dinero -= control.db.DmejoraA[0];
                control.db.mejoraA += 1;
            }
            if (control.torre.GetComponent<Granja>() != null)
            {
                controlJuego.dinero -= control.granja.DmejoraA[0];
                control.granja.mejoraA += 1;
            }
            if (control.torre.GetComponent<PsycoKiller>() != null)
            {
                controlJuego.dinero -= control.psycoKiller.DmejoraA[0];
                control.psycoKiller.mejoraA += 1;
            }
            control.controlcanvas();
        }
    }
    public void ButonA2()
    {
        if (valido(1, true))
        {
            switch (control.torre.name)
            {
                case Firerer:
                    control.db.speedB += 1;
                    control.db.fireRate -= 1;
                    control.db.fireDistance += 1.5f;
                    control.db.verIn = true;
                    break;
                case Frosti:
                    control.db.fireDistance *= 1.5f;
                    control.db.fireRate -= 1;
                    control.db.projectilePrefab.GetComponent<Movimien_Bala>().ralentiza -= 0.3f;
                    break;
                case Granja:
                    Granja g = control.torre.GetComponent<Granja>();
                    g.Dinero *= 2;
                    break;
                case Venom:
                    control.db.danio++;
                    break;
                case Psycokiller:
                    PsycoKiller p = control.torre.GetComponent<PsycoKiller>();
                    p.danio += 2;
                    break;
            }
            if (control.torre.GetComponent<Disparo_base>() != null)
            {
                controlJuego.dinero -= control.db.DmejoraA[1];
                control.db.mejoraA += 1;
            }
            if (control.torre.GetComponent<Granja>() != null)
            {
                controlJuego.dinero -= control.granja.DmejoraA[1];
                control.granja.mejoraA += 1;
            }
            if (control.torre.GetComponent<PsycoKiller>() != null)
            {
                controlJuego.dinero -= control.psycoKiller.DmejoraA[1];
                control.psycoKiller.mejoraA += 1;
            }
            control.controlcanvas();
        }
    }
    public void ButonA3()
    {
        if (valido(2, true))
        {
            switch (control.torre.name)
            {
                case Firerer:
                    control.db.speedB += 1;
                    control.db.fireRate -= 1;
                    control.db.fireDistance += 2.5f;
                    break;
                case Frosti:
                    control.db.fireDistance *= 1.5f;
                    control.db.fireRate -= 1;
                    control.db.projectilePrefab.GetComponent<Movimien_Bala>().ralentiza -= 0.3f;
                    break;
                case Granja:
                    Granja g = control.torre.GetComponent<Granja>();
                    g.Dinero *= 10;
                    break;
                case Venom:
                    control.db.danio += 3;
                    break;
                case Psycokiller:
                    PsycoKiller p = control.torre.GetComponent<PsycoKiller>();
                    p.danio += 3;
                    break;

            }
            if (control.torre.GetComponent<Disparo_base>() != null)
            {
                controlJuego.dinero -= control.db.DmejoraA[2];
                control.db.mejoraA += 1;
            }
            if (control.torre.GetComponent<Granja>() != null)
            {
                controlJuego.dinero -= control.granja.DmejoraA[2];
                control.granja.mejoraA += 1;
            }
            if (control.torre.GetComponent<PsycoKiller>() != null)
            {
                controlJuego.dinero -= control.psycoKiller.DmejoraA[2];
                control.psycoKiller.mejoraA += 1;
            }
            control.controlcanvas();
        }
    }
    public void ButonB1()
    {
        if (valido(0, false))
        {
            switch (control.torre.name)
            {
                case Firerer:

                    control.db.fireRate += 2;
                    control.db.fireDistance += 1;
                    control.db.danio = 3;

                    break;
                case Frosti:

                    control.db.fireDistance += 2;
                    control.db.danio = 2;
                    control.db.projectilePrefab.GetComponent<Movimien_Bala>().TiempoR += 2;

                    break;
                case Granja:
                    Granja g = control.torre.GetComponent<Granja>();
                    g.Tiempo -= 5;
                    break;
                case Venom:
                    control.db.projectilePrefab.GetComponent<Movimien_Bala>().TiempoPoison++;
                    control.db.projectilePrefab.GetComponent<Movimien_Bala>().TiempoEntrePoison--;
                    break;
                case Psycokiller:
                    PsycoKiller p = control.torre.GetComponent<PsycoKiller>();
                    p.fireRate /= 1.25f;
                    break;
            }
            if (control.torre.GetComponent<Disparo_base>() != null)
            {
                controlJuego.dinero -= control.db.DmejoraB[0];
                control.db.mejoraB += 1;
            }
            if (control.torre.GetComponent<Granja>() != null)
            {
                controlJuego.dinero -= control.granja.DmejoraB[0];
                control.granja.mejoraB += 1;
            }
            if (control.torre.GetComponent<PsycoKiller>() != null)
            {
                controlJuego.dinero -= control.psycoKiller.DmejoraB[0];
                control.psycoKiller.mejoraB += 1;
            }
            control.controlcanvas();
        }
    }
    public void ButonB2()
    {
        if (valido(1, false))
        {
            switch (control.torre.name)
            {
                case Firerer:
                    control.db.fireDistance += 1;
                    control.db.danio = 4;
                    control.db.antiA = true;
                    break;
                case Frosti:
                    control.db.fireDistance += 2;
                    control.db.danio = 3;
                    control.db.projectilePrefab.GetComponent<Movimien_Bala>().TiempoR += 3;
                    break;
                case Granja:
                    Granja g = control.torre.GetComponent<Granja>();
                    g.Tiempo -= -5;
                    break;
                case Venom:
                    control.db.projectilePrefab.GetComponent<Movimien_Bala>().TiempoPoison++;
                    control.db.projectilePrefab.GetComponent<Movimien_Bala>().TiempoEntrePoison--;
                    break;
                case Psycokiller:
                    PsycoKiller p = control.torre.GetComponent<PsycoKiller>();
                    p.fireRate /= 1.5f;
                    break;
            }
            if (control.torre.GetComponent<Disparo_base>() != null)
            {
                controlJuego.dinero -= control.db.DmejoraB[1];
                control.db.mejoraB += 1;
            }
            if (control.torre.GetComponent<Granja>() != null)
            {
                controlJuego.dinero -= control.granja.DmejoraB[1];
                control.granja.mejoraB += 1;
            }
            if (control.torre.GetComponent<PsycoKiller>() != null)
            {
                controlJuego.dinero -= control.psycoKiller.DmejoraB[1];
                control.psycoKiller.mejoraB += 1;
            }
            control.controlcanvas();
        }
    }
    public void ButonB3()
    {
        if (valido(2, false))
        {
            switch (control.torre.name)
            {
                case Firerer:
                    control.db.fireRate -= 3;
                    control.db.fireDistance += 1;
                    control.db.danio = 5;
                    break;
                case Frosti:
                    control.db.fireDistance += 2;
                    control.db.danio = 4;
                    control.db.projectilePrefab.GetComponent<Movimien_Bala>().TiempoR += 2;
                    break;
                case Granja:
                    Granja g = control.torre.GetComponent<Granja>();
                    g.Tiempo /= 2;
                    break;
                case Venom:
                    control.db.projectilePrefab.GetComponent<Movimien_Bala>().TiempoPoison += 40;
                    control.db.projectilePrefab.GetComponent<Movimien_Bala>().TiempoEntrePoison--;
                    break;
                case Psycokiller:
                    PsycoKiller p = control.torre.GetComponent<PsycoKiller>();
                    p.fireRate /= 2;
                    break;
            }
            if (control.torre.GetComponent<Disparo_base>() != null)
            {
                controlJuego.dinero -= control.db.DmejoraB[2];
                control.db.mejoraB += 1;
            }
            if (control.torre.GetComponent<Granja>() != null)
            {
                controlJuego.dinero -= control.granja.DmejoraB[2];
                control.granja.mejoraB += 1;
            }
            if (control.torre.GetComponent<PsycoKiller>() != null)
            {
                controlJuego.dinero -= control.psycoKiller.DmejoraB[2];
                control.psycoKiller.mejoraB += 1;
            }
            control.controlcanvas();
        }
    }
}
