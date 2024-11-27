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
    public int danio = 1;
    public int vida;
    public bool conjelar = false;
    public bool antiA = false;
    public bool verIn = false;
    public bool poison = false;
    public float ralentiza = 0.9f;
    public int TiempoR = 4;
    public int TiempoPoison = 5;
    public int TiempoEntrePoison = 4;
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
        RotateTowardsDirection();
    }
    // Update is called once per frame
    void Update()
    {
        // Move towards the enemy
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        if (transform.position.x <= -2 || transform.position.x >= 33 || transform.position.y <= -2 || transform.position.y >= 23)
        {
            Destroy(gameObject);
        }
    }
    void RotateTowardsDirection()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
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
            if (conjelar)
            {
                movement.speedfreze(ralentiza, TiempoR);
            }
            if (poison)
            {
                movement.Veneno(danio, TiempoPoison, TiempoEntrePoison);
            }
            if (vida <= 0)
            {
                Destroy(gameObject);
            }
            if (movement.vida <= 0)
            {
                controlJuego.dinero += dar;
                controlJuego.dineroF += dar;
                Destroy(other.gameObject);
            }
        }
    }

}
