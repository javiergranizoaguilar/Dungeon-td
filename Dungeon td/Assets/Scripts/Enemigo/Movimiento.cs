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
    private bool miraderecha = true;
    public bool pausa = false;
    public float puntoC = 0;
    private ControlJuego controlJuego;
    // Start is called before the first frame update
    public void Awake()
    {
        GameObject objetoEncontradoF = GameObject.Find("GameManager");
        controlJuego = objetoEncontradoF.GetComponent<ControlJuego>();
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
        Flip();
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
    void Flip()
    {
        if (waypoints[currentWaypoint] != null)
        {
            if (gameObject.transform.position.x - waypoints[currentWaypoint].transform.position.x < 0)
            {
                if (!miraderecha)
                {
                    miraderecha = !miraderecha;
                    Vector3 theScale = transform.localScale;
                    theScale.x *= -1;
                    // Invertir la escala en el eje x 
                    transform.localScale = theScale;
                }
            }
            if (gameObject.transform.position.x - waypoints[currentWaypoint].transform.position.x > 0)
            {
                if (miraderecha)
                {
                    miraderecha = !miraderecha;
                    Vector3 theScale = transform.localScale;
                    theScale.x *= -1;
                    // Invertir la escala en el eje x 
                    transform.localScale = theScale;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Trampa(Clone)")
        {
            vida -= other.GetComponent<Trampa>().danio;
            Trampa trampa = (Trampa)other.gameObject.GetComponent("Trampa");
            trampa.vida -= vidb;
            if (trampa.vida <= 0)
            {
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.CompareTag(bala))
        {
            vida -= other.GetComponent<Movimien_Bala>().danio;
            Movimien_Bala movement_bala = (Movimien_Bala)other.gameObject.GetComponent("Movimien_Bala");
            movement_bala.vida -= vidb;
            if (movement_bala.vida <= 0)
            {
                Destroy(other.gameObject);
            }
            speed -= other.GetComponent<Movimien_Bala>().danio * iSpeed;


        }
        if (vida <= 0)
        {
            // Destroy both the object that this script is attached to and the object that it triggered
            controlJuego.dinero += (int)dar;
            controlJuego.dineroF += (int)dar;
            Destroy(gameObject);
        }
    }
    public void putSpeeds()
    {
        speed = iSpeed * vida;
    }
    public void stop()
    {
        pausa = true;
        speed = 0;
    }
    public void unStop()
    {
        pausa = false;
        putSpeeds();
    }
    public IEnumerator speedfreze(float ralentiza, int tiempo)
    {
        speed *= ralentiza;
        yield return StartCoroutine(ProcesoConEspera(tiempo));
        putSpeeds();
    }
    public IEnumerator Veneno(int Danio, int tiempo, int tiempoentrepoison)
    {
        for (int i = 0; i <= tiempo; i++)
            yield return StartCoroutine(ProcesoConEspera(tiempoentrepoison));
        vida -= Danio;
    }

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
