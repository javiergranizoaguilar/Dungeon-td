using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimien_Bala : MonoBehaviour
{
    public float speeds;
    public float speed;
    public Transform target;
    private Vector3 direction;
    public int dar = 20;
    public int danio=1;
    public int vida;
    public bool antiA = false;
    public bool verIn= false;
    public ControlJuego controlJuego;
    // Start is called before the first frame update
    public void putSpeeds()
    {
        speed = speeds;
    }
    void Start()
    {
        putSpeeds();
        // Calculate the direction to the enemy
        direction = (target.position - transform.position).normalized;
        GameObject gameObject = GameObject.Find("GameManager");

        controlJuego = (ControlJuego)gameObject.GetComponent("ControlJuego");
        vida = danio;
        
    }

    // Update is called once per frame


    void Update()
    {

        // Move towards the enemy
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.x <= -2 || transform.position.x >= 40 || transform.position.y <= -2 || transform.position.y >= 24)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy 1"))
        {
            Movement movement = (Movement)other.gameObject.GetComponent("Movement");
            vida -= movement.vida;
            if (antiA && movement.acorazado)
            {
                movement.vida -= danio * 8;
            }


            if (vida <= 0)
            {
                Destroy(gameObject);
            }
            if (movement.vida <= 0)
            {
                controlJuego.dinero += dar;
                Destroy(other.gameObject);
            }
        }
    }
}
