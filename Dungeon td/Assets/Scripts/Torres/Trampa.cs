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
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = GameObject.Find("GameManager");

        controlJuego = (ControlJuego)gameObject.GetComponent("ControlJuego");
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
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!towerDragHandler.isDragging)
        {
            if (other.gameObject.CompareTag("Enemy 1"))
            {
                Movement movement = (Movement)other.gameObject.GetComponent("Movement");
                vida -= movement.vida;
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
}
