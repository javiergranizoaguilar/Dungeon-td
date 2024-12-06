using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{
    public int vida;
    public int danio;
    public int dar = 16;
    public string informacion;
    public ControlJuego controlJuego;
    public TowerDragHandler towerDragHandler;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = GameObject.Find("GameManager");

        controlJuego = (ControlJuego)gameObject.GetComponent("ControlJuego");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (towerDragHandler == null)
        {
            GameObject buttonObject = GameObject.Find("Trampa");
            if (buttonObject != null)
            {
                towerDragHandler = (TowerDragHandler)buttonObject.GetComponent("TowerDragHandler");

            }
        }
        else
        {
            if (animator != null)
            {
                if (towerDragHandler.isDragging)
                {
                    animator.SetBool("Isdraging", true); ;
                }
                else
                {
                    animator.SetBool("Isdraging", false);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!towerDragHandler.isDragging)
        {
            if (other.gameObject.CompareTag("Enemy 1"))
            {
                Movement movement = (Movement)other.gameObject.GetComponent("Movement");
                vida -= movement.vidb;
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
                Debug.Log("a");
            }
        }
    }
}
