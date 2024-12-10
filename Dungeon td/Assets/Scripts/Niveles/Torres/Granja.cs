using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granja : MonoBehaviour
{
    public SoundPlayOnes soundPlayOnes;
    public TowerDragHandler towerDragHandler;
    public ControlJuego controlJuego;
    public int mejoraA = 0;
    public int mejoraB = 0;
    public int[] DmejoraA;
    public int[] DmejoraB;
    public string[] InfoA;
    public string[] InfoB;
    public string[] NombreMA;
    public string[] NombreMB;
    public bool pausa = false;
    public int Dinero = 100;
    public int Tiempo = 30;
    public string informacion;
    private Coroutine Granjear;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (towerDragHandler != null)
        {
            if (!towerDragHandler.isDragging && Granjear == null)
            {
                Granjear = StartCoroutine(Granjeo());
            }
        }
        else
        {
            GameObject buttonObject = GameObject.Find("Granja");
            if (buttonObject != null)
            {
                towerDragHandler = (TowerDragHandler)buttonObject.GetComponent("TowerDragHandler");
                GameObject gameObject = GameObject.Find("GameManager");
                controlJuego = (ControlJuego)gameObject.GetComponent("ControlJuego");

            }
        }


    }
    IEnumerator Granjeo()
    {
        while (true)
        {
            yield return StartCoroutine(ProcesoConEspera(30));
            soundPlayOnes.PlaySound();
            controlJuego.dinero += Dinero;
            controlJuego.dineroF += Dinero;
        }
    }
    //Proceso que guarda el tiempo de espera apesar de que se pare
    IEnumerator ProcesoConEspera(float duracion)
    {
        float tiempoTranscurrido = 0f;
        float tiempoRestante = duracion;
        while (tiempoTranscurrido < duracion)
        {
            // Si la pausa es verdadera, guarda el tiempo restante y espera hasta que la pausa se termine 
            if (pausa)
            {
                tiempoRestante = duracion - tiempoTranscurrido;
                yield return new WaitUntil(() => !pausa);
                tiempoTranscurrido = duracion - tiempoRestante;
                // Recalcula el tiempo transcurrido después de la pausa 
            }
            // Incrementa el tiempo transcurrido 
            tiempoTranscurrido += Time.deltaTime;
            yield return null;
        }
    }
}
