using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stoper : MonoBehaviour
{
    public bool stoped = false;
    public GameObject[] enemies;
    public GameObject[] balas;
    public GameObject[] GranjasF;
    public List<GameObject> GranjasR;
    public GameObject canvas;
    public GameObject canvasAjustes;

    public oleadas oleadas;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy 1");
        balas = GameObject.FindGameObjectsWithTag("Bala");
        GranjasF = GameObject.FindGameObjectsWithTag("Personaje");
        foreach (GameObject g in GranjasF)
        {
            if (g.name == "Granja(Clone)")
            {
                GranjasR.Add(g);
            }
        }
    }
    public void Stop()
    {

        stoped = true;
        oleadas.parado = false;
        foreach (GameObject enemy in enemies) { enemy.GetComponent<Movement>().stop(); }
        foreach (GameObject bala in balas) { bala.GetComponent<Movimien_Bala>().speed = 0; }
        foreach (GameObject granja in GranjasR) { granja.GetComponent<Granja>().pausa = true; }
        canvas.SetActive(true);
    }
    public void unStop()
    {

        stoped = false;
        oleadas.parado = true;
        foreach (GameObject enemy in enemies) { enemy.GetComponent<Movement>().unStop(); }
        foreach (GameObject bala in balas) { bala.GetComponent<Movimien_Bala>().putSpeeds(); }
        foreach (GameObject granja in GranjasR) { granja.GetComponent<Granja>().pausa = false; }
        canvas.SetActive(false);
    }
    public void ajustes()
    {
        canvasAjustes.SetActive(true);
    }
    public void Salirajustes()
    {
        canvasAjustes.SetActive(false);
    }
}
