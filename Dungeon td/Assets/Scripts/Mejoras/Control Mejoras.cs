using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class Control_mejoras : MonoBehaviour
{
    public GameObject canvas;
    public GameObject torre;
    public Disparo_base db;
    public Granja granja;
    public PsycoKiller psycoKiller;
    public GameObject[] butons;
    private Color colorOriginal = Color.white;
    public GameObject Apuntar;
    public TextMeshProUGUI Modo;

    // Start is called before the first frame update
    void Awake()
    {
    }
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {

        MejoraShow();
    }
    public void MejoraShow()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            foreach (GameObject e in GameObject.FindGameObjectsWithTag("Personaje"))
            {
                // Si se hizo clic en este objeto
                if (hit.collider != null && hit.collider.gameObject == e)
                {
                    torre = hit.collider.gameObject;
                    db = torre.GetComponent<Disparo_base>();
                    granja = torre.GetComponent<Granja>();
                    psycoKiller = torre.GetComponent<PsycoKiller>();
                    if (torre.name != "Trampa(Clone)")
                    {
                        canvas.SetActive(true);
                        Vaciar();
                        controlcanvas();
                    }
                }
            }
        }
    }
    public void Sal()
    {
        canvas.SetActive(false);
    }
    public void textos()
    {
        string[] NombreMA = new string[3];
        string[] NombreMB = new string[3];
        switch (torre.gameObject.name)
        {
            case "Granja(Clone)":
                NombreMA = granja.NombreMA;
                NombreMB = granja.NombreMB;
                Apuntar.SetActive(false);
                break;
            case "Psycokiller(Clone)":
                NombreMA = psycoKiller.NombreMA;
                NombreMB = psycoKiller.NombreMB;
                Apuntar.SetActive(true);
                break;
            default:
                NombreMA = db.NombreMA;
                NombreMB = db.NombreMB;
                Apuntar.SetActive(true);
                switch (db.ApuntadoDisparo)
                {
                    case 0:
                        Modo.text = "Primero";
                        break;
                    case 1:
                        Modo.text = "Ultimo";
                        break;
                    case 2:
                        Modo.text = "Fuerte";
                        break;
                    case 3:
                        Modo.text = "Debil";
                        break;
                    default:
                        Modo.text = "Primero";
                        break;
                }
                break;

        }
        int v = 0;
        for (int e = 0; e < 6; e++)
        {
            if (e < 3)
            {
                butons[e].GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = NombreMA[e];
            }
            else
            {
                butons[e].GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = NombreMB[v];
                v++;
            }
        }
    }
    public void controlcanvas()
    {
        int MejoraA = 0;
        int MejoraB = 0;
        switch (torre.gameObject.name)
        {
            case "Granja(Clone)":
                MejoraA = granja.mejoraA;
                MejoraB = granja.mejoraB;
                break;
            case "Trampa(Clone)":
                break;
            case "Psycokiller(Clone)":
                MejoraA = psycoKiller.mejoraA;
                MejoraB = psycoKiller.mejoraB;
                break;
            default:
                MejoraA = db.mejoraA;
                MejoraB = db.mejoraB;

                break;
        }
        textos();
        if (MejoraB >= 2)
        {
            switch (MejoraA)
            {
                case 0:
                    butons[0].SetActive(true);

                    break;
                default:
                    butons[1].SetActive(true);
                    butons[1].GetComponent<Button>().interactable = false;
                    CambioColor(butons[1].GetComponent<Button>());
                    break;
            }
        }
        else
        {
            switch (MejoraA)
            {
                case 0:
                    butons[0].SetActive(true);
                    break;
                case 1:
                    butons[1].SetActive(true);
                    break;
                case 2:
                    butons[2].SetActive(true);
                    break;
                default:
                    butons[2].SetActive(true);
                    butons[2].GetComponent<Button>().interactable = false;
                    CambioColor(butons[2].GetComponent<Button>());
                    break;
            }
        }
        if (MejoraA >= 2)
        {

            switch (MejoraB)
            {
                case 0:
                    butons[3].SetActive(true);
                    break;
                default:
                    butons[4].SetActive(true);
                    butons[4].GetComponent<Button>().interactable = false;
                    CambioColor(butons[4].GetComponent<Button>());
                    break;
            }
        }
        else
        {
            switch (MejoraB)
            {
                case 0:
                    butons[3].SetActive(true);
                    break;
                case 1:
                    butons[4].SetActive(true);
                    break;
                case 2:
                    butons[5].SetActive(true);
                    break;
                default:
                    butons[5].SetActive(true);
                    butons[5].GetComponent<Button>().interactable = false;
                    CambioColor(butons[5].GetComponent<Button>());
                    break;
            }
        }
    }
    public void Vaciar()
    {
        Apuntar.SetActive(false);
        foreach (GameObject b in butons)
        {
            b.SetActive(false);
            b.GetComponent<Button>().interactable = true;
            ResetColor(b.GetComponent<Button>());
        }
    }
    public void CambioColor(Button button)
    {
        ColorBlock cb = button.colors;
        cb.normalColor = Color.red;
        cb.highlightedColor = Color.red;
        cb.pressedColor = Color.red;
        cb.selectedColor = Color.red;
        cb.disabledColor = Color.gray;
        // Por ejemplo, gris cuando está deshabilitado 
        // Asigna el ColorBlock al botón 
        button.colors = cb;
    }
    public void ResetColor(Button button)
    {
        ColorBlock cb = button.colors;

        // Estos son los valores predeterminados del ColorBlock
        cb.normalColor = Color.white; // o cualquier otro color por defecto
        cb.highlightedColor = new Color(0.882f, 0.882f, 0.882f); // Gris claro por defecto
        cb.pressedColor = new Color(0.698f, 0.698f, 0.698f); // Gris más oscuro por defecto
        cb.selectedColor = Color.white; // o cualquier otro color por defecto
        cb.disabledColor = new Color(0.784f, 0.784f, 0.784f); // Gris claro por defecto para deshabilitado

        // Asigna el ColorBlock actualizado al botón
        button.colors = cb;
    }

}
