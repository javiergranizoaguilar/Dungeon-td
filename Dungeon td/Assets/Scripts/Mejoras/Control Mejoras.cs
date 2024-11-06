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
    private Color colorOriginal= Color.white;
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

                // Si se hizo clic en este objeto
                if (hit.collider != null && hit.collider.gameObject == GameObject.FindGameObjectWithTag("Personaje"))
                {
                    torre = hit.collider.gameObject;
                    db = torre.GetComponent<Disparo_base>();
                    canvas.SetActive(true);
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
        foreach (GameObject b in butons)
        {
            b.SetActive(false);
            b.GetComponent<Image>().color = colorOriginal;
        }
        if (db.mejoraB >= 2)
        {
            butons[0].SetActive(true);
            butons[0].GetComponent<Image>().color = Color.red;
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
                    break;
            }
        }
        if (db.mejoraA >= 2)
        {
            butons[5].SetActive(true);
            butons[5].GetComponent<Image>().color = Color.red;
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
                    break;
            }
        }
    }
}
