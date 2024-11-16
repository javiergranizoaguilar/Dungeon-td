using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stoper : MonoBehaviour
{
    public bool stoped = false;
    public GameObject[] enemies;
    public GameObject[] balas;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy 1");
        balas = GameObject.FindGameObjectsWithTag("Bala");


    }
    public void Stop()
    {
        stoped = true;
        foreach (GameObject enemy in enemies) { enemy.GetComponent<Movement>().speed = 0; }
        foreach (GameObject bala in balas){bala.GetComponent<Movimien_Bala>().speed=0;}
        canvas.SetActive(true);
    }
    public void unStop(){
        stoped=false;
        foreach (GameObject enemy in enemies) { enemy.GetComponent<Movement>().putSpeeds(); }
        foreach (GameObject bala in balas){bala.GetComponent<Movimien_Bala>().putSpeeds();}
        canvas.SetActive(false);
    }
}
