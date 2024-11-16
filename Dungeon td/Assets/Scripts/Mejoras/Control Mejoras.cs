using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control_mejoras : MonoBehaviour
{
    public GameObject canvas;
    public GameObject torre;
    public Disparo_base db;
    public GameObject[] butons;
    private Color colorOriginal = Color.white;
    // Start is called before the first frame update
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
        try
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
                        canvas.SetActive(true);
                        Vaciar();
                        controlcanvas();
                    }
                }
            }
        }
        catch (Exception e) { Debug.Log(e.Message); }

    }
    public void Sal()
    {
        canvas.SetActive(false);
    }
    public void controlcanvas()
    {
        if (db.mejoraB >= 2)
        {
            switch (db.mejoraA)
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
            switch (db.mejoraA)
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
        if (db.mejoraA >= 2)
        {

            switch (db.mejoraB)
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
            switch (db.mejoraB)
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
