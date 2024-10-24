using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimien_Bala : MonoBehaviour
{
    public float speed = 5f;
    public Transform target;
    private Vector3 direction;
    public int dar = 20;
    public ControlJuego controlJuego;
    // Start is called before the first frame update
    void Start()
    {
        // Calculate the direction to the enemy
        direction = (target.position - transform.position).normalized;
        GameObject gameObject = GameObject.Find("GameManager");

        controlJuego = (ControlJuego)gameObject.GetComponent("ControlJuego");


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
            controlJuego.dinero += dar;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
