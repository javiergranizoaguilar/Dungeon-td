using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
[RequireComponent(typeof(LineRenderer))]
public class Disparo_base : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform firePoint; // Punto de origen del disparo
    public GameObject[] enemies;
    public List<GameObject> listado;
    public GameObject targetEnemy; // Referencia al objeto enemigo actualmente en la mira
    public TowerDragHandler towerDragHandler;
    private Coroutine shootingCoroutine;
    public Color circleColor = Color.red; // Color de la línea
    private LineRenderer lineRenderer;
    public string enemyTag = "Enemy 1"; // Etiqueta del enemigo a apuntar
    public string mono;
    public float rotationSpeed = 2000f; // Velocidad de rotación hacia el objetivo
    public float distance;
    public float fireRate = 1f;
    public float fireDistance = 10.0f;
    public int segments = 50;          // Número de segmentos (cuanto más alto, más suave será el círculo)
    private bool isCircleVisible = false;
    public bool verIn = false;
    // Start is called before the first frame update
    void Start()
    {
        firePoint = gameObject.transform;
        // Obtener el LineRenderer
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = false; // Para que el círculo siga al objeto
        lineRenderer.positionCount = segments + 1; // Para cerrar el círculo

        // Configurar el grosor de la línea y el color
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.startColor = circleColor;
        lineRenderer.endColor = circleColor;

        DrawCircle();

    }

    // Update is called once per frame
    void Update()
    {

        if (towerDragHandler != null)
        {
            Controlcrilcle();
            enemigos();
            StartShooting();
        }
        else
        {
            GameObject buttonObject = GameObject.Find(mono);
            if (buttonObject != null)
            {
                towerDragHandler = (TowerDragHandler)buttonObject.GetComponent("TowerDragHandler");

            }
        }
    }
    public void enemigos()
    {
        // Buscar el objeto enemigo con la etiqueta especificada
        enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        foreach (GameObject e in enemies)
        {
            float distances = Vector2.Distance(firePoint.transform.position, e.transform.position);
            if (distances <= fireDistance)
            {
                if (!(e.GetComponent<Movement>().invisible && !verIn))
                {
                    listado.Add(e);
                }
            }
        }

        if (listado.Count > 0)
        {
            targetEnemy = listado[0]; // Seleccionar el primer objeto enemigo encontrado
            distance = Vector2.Distance(firePoint.transform.position, targetEnemy.transform.position);
            listado.Clear();
        }
    }

    public void StartShooting()
    {
        // Si la torre no está siendo arrastrada (isDragging es false) y no hay una corutina de disparo activa
        if (!towerDragHandler.isDragging && shootingCoroutine == null)
        {
            HideCircle();
            isCircleVisible = false;
            // Iniciar la corutina de disparo cuando la torre es colocada en la escena o activada
            shootingCoroutine = StartCoroutine(Shoot());
        }
    }

    public void StopShooting()
    {
        // Detener el disparo cuando la torre es desactivada o eliminada
        if (shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
        }
    }

    //el IEnumerator define una corrutina 
    IEnumerator Shoot()
    {
        while (true)
        {

            // busca si hay enemigos en pantalla
            if (targetEnemy != null)
            {
                //si los hay busca la distancia si es menor a la indicada dispara si es mallor no 

                if (distance <= fireDistance)
                {

                    // Instanciar un proyectil
                    GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                    Movimien_Bala movimien_Bala = projectile.GetComponent<Movimien_Bala>();
                    if (movimien_Bala != null)
                    {
                        movimien_Bala.target = targetEnemy.transform;

                    }

                    // Espera un tiempo definido por fireRate antes de disparar el siguiente proyectil 
                    //yield return new proboca una espera dependiendo de cietos parametros ya sa una condicion se cunpla o pase un tiempo
                    yield return new WaitForSeconds(fireRate);
                }
                else
                {
                    yield return new WaitUntil(() => (distance <= fireDistance));
                }
            }
            else
            {
                yield return new WaitUntil(() => (targetEnemy != null));
            }
        }
    }
    void DrawCircle()
    {
        lineRenderer.positionCount = segments + 1;
        // Dibujar los puntos del círculo alrededor del objeto
        float angle = 0f;
        for (int i = 0; i < segments + 1; i++) // +1 para cerrar el círculo
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * fireDistance;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * fireDistance;
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
            angle += (360f / segments);
        }
    }
    // Función para ocultar el círculo
    void HideCircle()
    {
        lineRenderer.positionCount = 0;  // Quitar todos los puntos del LineRenderer
    }
    void Controlcrilcle()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            // Si se hizo clic en este objeto
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                DrawCircle();
                isCircleVisible = true;
            }
            // Si se hizo clic fuera del objeto, ocultar el círculo
            else if (isCircleVisible)
            {
                HideCircle();
                isCircleVisible = false;
            }
        }
    }


}
