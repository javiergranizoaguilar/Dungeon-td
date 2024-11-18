using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mejorasbasicas : MonoBehaviour
{
    public Control_mejoras control;
    public ControlJuego controlJuego;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ButonA1()
    {
        if (control.db.DmejoraA[0] <= controlJuego.dinero && control.db.mejoraA >= 0)
        {

            controlJuego.dinero -= control.db.DmejoraA[0];
            control.db.mejoraA += 1;
            control.db.fireDistance = 5;
            control.db.speedB = 6;
            control.db.fireRate = 3;
            control.controlcanvas();

        }

    }
    public void ButonA2()
    {
        if (control.db.DmejoraA[1] <= controlJuego.dinero)
        {

            control.db.speedB = 7;
            control.db.fireRate = 2;
            control.db.mejoraA += 1;
            control.db.fireDistance = 7.5f;
            controlJuego.dinero -= control.db.DmejoraA[1];
            control.db.verIn = true;
            control.controlcanvas();
        }
    }
    public void ButonA3()
    {
        if (control.db.DmejoraA[2] <= controlJuego.dinero)
        {

            control.db.speedB = 8;
            control.db.fireRate = 1;
            control.db.mejoraA += 1;
            controlJuego.dinero -= control.db.DmejoraA[2];
            control.db.fireDistance = 10;
            control.controlcanvas();
        }
    }
    public void ButonB1()
    {
        if (control.db.DmejoraB[0] <= controlJuego.dinero && control.db.mejoraB == 0)
        {

            control.db.fireRate = 4;
            control.db.mejoraB += 1;
            controlJuego.dinero -= control.db.DmejoraB[0];
            control.db.fireDistance = 4;
            control.db.danio = 3;
            control.controlcanvas();
        }
    }
    public void ButonB2()
    {
        if (control.db.DmejoraB[1] <= controlJuego.dinero)
        {

            control.db.mejoraB += 1;
            control.db.fireDistance = 5;
            controlJuego.dinero -= control.db.DmejoraB[1];
            control.db.danio = 4;
            control.db.antiA = true;
            control.controlcanvas();
        }
    }
    public void ButonB3()
    {
        if (control.db.DmejoraB[2] <= controlJuego.dinero)
        {

            control.db.fireRate = 3;
            control.db.mejoraB += 1;
            control.db.fireDistance = 6;
            control.db.danio = 5;
            controlJuego.dinero -= control.db.DmejoraB[2];
            control.controlcanvas();
        }
    }
}
