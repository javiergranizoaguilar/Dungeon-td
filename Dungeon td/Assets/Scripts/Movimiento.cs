using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Transform[] waypoints;  // Array de waypoints que definen el camino
    public int vida;
    static float iSpeed=1;
    public float speed =iSpeed;     // Velocidad de movimiento del objeto
    private int currentWaypoint = 0;
    private string bala = "Bala";
    public double dar = 16;
    
    public ControlJuego controlJuego;
    // Start is called before the first frame update
    void Start()
    {
        speed*=vida;
        dar*= vida*1.25;
        GameObject gameObject = GameObject.Find("GameManager");

        controlJuego = (ControlJuego)gameObject.GetComponent("ControlJuego");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWaypoint < waypoints.Length)
        {
            // Mueve el objeto hacia el siguiente waypoint
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);

            // Si el objeto alcanza el waypoint actual, pasa al siguiente
            if (Vector2.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
            {
                currentWaypoint++;
            }
        }
        else
        {
            controlJuego.vidas-=vida;
            // Si alcanza el final del camino (fuera de los waypoints)
            Destroy(gameObject); // Destruye el GameObject actual
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(bala))
        {
            vida -= other.GetComponent<Movimien_Bala>().danio;
            Movimien_Bala movement_bala = (Movimien_Bala)other.gameObject.GetComponent("Movimien_Bala");
            movement_bala.vida-=vida;
            speed-= other.GetComponent<Movimien_Bala>().danio*iSpeed;
            if (movement_bala.vida <= 0)
            {
                Destroy(other.gameObject);
            }
            if (vida <= 0)
            {
                // Destroy both the object that this script is attached to and the object that it triggered
                controlJuego.dinero += (int)dar;
                Destroy(gameObject);
            }
        }
    }
}
