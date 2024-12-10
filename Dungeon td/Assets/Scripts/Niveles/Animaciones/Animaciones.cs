using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animaciones : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer spriteRenderer;
    // Referencia al SpriteRenderer 
    public Sprite[] newSprite;
    // El nuevo sprite que quieres usar 
    public Disparo_base disparo_Base;
    public PsycoKiller psycoKiller;
    public Animator animator;
    public bool animfin = true;
    float x;
    float y;
    public bool izquierda = false;
    void Start()
    {
        // Asignar el spriteRenderer si no está asignado 
        if (spriteRenderer == null) { spriteRenderer = GetComponent<SpriteRenderer>(); }
        if (animator == null) { animator = GetComponent<Animator>(); }

    }
    void Update()
    {
        if (disparo_Base != null
        || psycoKiller != null)
        {
            ChangeAnimation();
        }
    }
    public void changeFinani()
    {
        animfin = !animfin;
    }
    //Controla la direccion de la animacion
    public void ChangeAnimation()
    {


        if (animator != null && animfin)
        {
            animator.SetBool("Delante", false);
            animator.SetBool("Atras", false);
            animator.SetBool("Derecha", false);
            animator.SetBool("Izquierda", false);
            if (disparo_Base != null && disparo_Base.animd && disparo_Base.targetEnemy!=null)
            {
                x = disparo_Base.gameObject.transform.position.x - disparo_Base.targetEnemy.gameObject.transform.position.x;
                y = disparo_Base.gameObject.transform.position.y - disparo_Base.targetEnemy.gameObject.transform.position.y;
                seter(x, y);
            }
            if (psycoKiller != null && psycoKiller.animd && psycoKiller.targetEnemy != null)
            {
                x = psycoKiller.gameObject.transform.position.x - psycoKiller.targetEnemy.gameObject.transform.position.x;
                y = psycoKiller.gameObject.transform.position.y - psycoKiller.targetEnemy.gameObject.transform.position.y;
                seter(x, y);
            }

        }

    }
    //Canvia la direccion de la animacion
    public void flipo()
    {
        if (izquierda)
        {
            izquierda = false;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            // Invertir la escala en el eje x 
            transform.localScale = theScale;
        }
    }
    //Canvia la direccion de la animacion
    public void flipoI()
    {
        if (!izquierda)
        {
            izquierda = true;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            // Invertir la escala en el eje x 
            transform.localScale = theScale;
        }
    }
    //Dependiendo de x e y indica a la animacion que hacer
    public void seter(float x, float y)
    {
        if (y < 0)
        {

            if (Math.Abs(x) < Math.Abs(y))
            {
                flipo();
                animator.SetBool("Atras", true);
            }
            if (Math.Abs(x) >= Math.Abs(y))
            {
                if (x >= 0)
                {
                    flipoI();
                    animator.SetBool("Izquierda", true);
                }
                if (x < 0)
                {
                    flipo();
                    spriteRenderer.flipX = true;
                    animator.SetBool("Derecha", true);
                }

            }
        }
        if (y >= 0)
        {
            if (Math.Abs(x) <= Math.Abs(y))
            {
                flipo();
                animator.SetBool("Delante", true);
            }
            if (Math.Abs(x) > Math.Abs(y))
            {
                if (x >= 0)
                {
                    flipoI();
                    animator.SetBool("Izquierda", true);
                    izquierda = true;
                }
                if (x < 0)
                {
                    flipo();
                    animator.SetBool("Derecha", true);
                }
            }

        }
    }
}