using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class Nivel1_movement : MonoBehaviour
{

    public Transform[] waypoints;  // Array de waypoints que definen el camino
    public float speed = 5.0f;     // Velocidad de movimiento del objeto
    private int currentWaypoint = 0;
    private string bala = "Bala";
    public int dar=20;
    public ControlJuego controlJuego;
    // Start is called before the first frame update
    void Start()
    {
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
            // Si alcanza el final del camino (fuera de los waypoints)
            Destroy(gameObject); // Destruye el GameObject actual
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(bala))
        {
            // Destroy both the object that this script is attached to and the object that it triggered
            controlJuego.dinero += dar;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
