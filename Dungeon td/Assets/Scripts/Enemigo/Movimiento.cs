using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.Scripting;

public class Movement : MonoBehaviour
{

    public Transform[] waypoints;  // Array de waypoints que definen el camino
    public int vida;
    public int vidb;
    private static float iSpeed = 2;
    public float speed;     // Velocidad de movimiento del objeto
    public int currentWaypoint = 0;
    private string bala = "Bala";
    public double dar = 16;
    private float TRegener = 5;
    public bool acorazado = false;
    public bool grande = false;
    public bool invisible = false;
    public bool regenerable = false;
    public float puntoC = 0;
    private ControlJuego controlJuego;
    // Start is called before the first frame update
    public void Awake(){
        GameObject objetoEncontradoF = GameObject.Find("GameManager");
        controlJuego=objetoEncontradoF.GetComponent<ControlJuego>();
    }
    public void putSpeeds()
    {
        speed = iSpeed * vida;
    }
    void Start()
    {
        if (controlJuego.Medio) { dar *= vida * 1.1; }
        if (controlJuego.Dificil) { dar *= vida; }
        if (!grande) { putSpeeds(); }
        if (acorazado) { vida *= 8; }
        vidb = vida;
    }
    // Update is called once per frame
    void Update()
    {
        movimiento();
        regenerar();
    }
    public void movimiento()
    {
        if (currentWaypoint < waypoints.Length)
        {
            // Mueve el objeto hacia el siguiente waypoint
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);

            // Si el objeto alcanza el waypoint actual, pasa al siguiente
            if (Vector2.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
            {
                puntoC = Vector2.Distance(transform.position, waypoints[currentWaypoint].position);
                currentWaypoint++;
            }
        }
        else
        {
            controlJuego.vidas -= vida;
            // Si alcanza el final del camino (fuera de los waypoints)
            Destroy(gameObject); // Destruye el GameObject actual
        }
    }
    public void regenerar()
    {
        if (regenerable)
        {
            if (vidb > vida)
            {
                regenerable = false;
                new WaitForSeconds(TRegener);
                vida += 1;
                regenerable = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(bala))
        {
            vida -= other.GetComponent<Movimien_Bala>().danio;
            Movimien_Bala movement_bala = (Movimien_Bala)other.gameObject.GetComponent("Movimien_Bala");
            movement_bala.vida -= vidb;
            speed -= other.GetComponent<Movimien_Bala>().danio * iSpeed;
            if (movement_bala.vida <= 0)
            {
                Destroy(other.gameObject);
            }
            if (vida <= 0)
            {
                // Destroy both the object that this script is attached to and the object that it triggered
                controlJuego.dinero += (int)dar;
                controlJuego.dineroF += (int)dar;
                Destroy(gameObject);
            }
        }
    }
}
