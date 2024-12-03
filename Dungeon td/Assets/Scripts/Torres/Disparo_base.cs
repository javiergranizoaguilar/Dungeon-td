using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
[RequireComponent(typeof(LineRenderer))]
public class Disparo_base : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform firePoint; // Punto de origen del disparo
    public GameObject[] enemies;
    public GameObject stop;
    public GameObject targetEnemy; // Referencia al objeto enemigo actualmente en la mira 
    public List<GameObject> listado;
    public TowerDragHandler towerDragHandler;
    private Coroutine shootingCoroutine;
    private Color circleColor = Color.red; // Color de la línea
    private LineRenderer lineRenderer;
    public string enemyTag = "Enemy 1"; // Etiqueta del enemigo a apuntar
    public string mono;
    public float distance;
    public float fireRate = 4f;
    public float speedB = 5;
    public float fireDistance = 3;
    float distanciacirculo;
    public int danio = 1;
    private int segments = 50;          // Número de segmentos (cuanto más alto, más suave será el círculo)
    private bool isCircleVisible = false;
    public bool verIn = false;
    public bool antiA = false;
    public bool animd=false;
    // Start is called before the first frame update
    public int mejoraA = 0;
    public int mejoraB = 0;
    public int ApuntadoDisparo = 0;
    public int[] DmejoraA;
    public int[] DmejoraB;
    public string[] InfoA;
    public string[] InfoB;
    public string[] NombreMA;
    public string[] NombreMB;
    public string informacion;

    private List<GameObject> listadores = new List<GameObject>();
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
        switch (ApuntadoDisparo)
        {
            case 0:
                listado = ordenaMayorMenor(listado);
                break;
            case 1:
                listado = ordenaMenorMayor(listado);
                break;
                case 2:
                listado = MasVida(listado);
                break;
                case 3:
                listado = MenosVida(listado);
                break;
            default:
                listado = ordenaMayorMenor(listado);
                break;
        }

        if (listado.Count > 0)
        {
            targetEnemy = listado[0]; // Seleccionar el primer objeto enemigo encontrado
            distance = Vector2.Distance(firePoint.transform.position, targetEnemy.transform.position);
            listado.Clear();
        }
    }//Mas Vida
    public List<GameObject> MasVida(List<GameObject> listador)
    {
        listador = listador.OrderByDescending(e => e.GetComponent<Movement>().vida).ToList();

        foreach (GameObject e in listador)
        {
            if (listador[0].GetComponent<Movement>().vida == e.GetComponent<Movement>().vida)
            {
                listadores.Add(e);
            }
        }
        if (listadores.Count > 1)
        {
            listadores = ordenaMayorMenor(listadores);
        }
        return listadores;

    }
    //Menos Vida
    public List<GameObject> MenosVida(List<GameObject> listador)
    {
        listador = listador.OrderBy(e => e.GetComponent<Movement>().vida).ToList();

        foreach (GameObject e in listador)
        {
            if (listador[0].GetComponent<Movement>().vida == e.GetComponent<Movement>().vida)
            {
                listadores.Add(e);
            }
        }
        if (listadores.Count > 1)
        {
            listadores = ordenaMenorMayor(listadores);
        }
        return listadores;

    }
    //Mas Cerca Del Final
    public List<GameObject> ordenaMayorMenor(List<GameObject> listador)
    {
        listador = listador.OrderByDescending(e => e.GetComponent<Movement>().currentWaypoint).ToList();

        foreach (GameObject e in listador)
        {
            if (listador[0].GetComponent<Movement>().currentWaypoint == e.GetComponent<Movement>().currentWaypoint)
            {
                listadores.Add(e);
            }
        }
        if (listadores.Count > 1)
        {
            listadores = listadores.OrderByDescending(e => e.GetComponent<Movement>().puntoC).ToList();
        }
        return listadores;

    }
    //Mas Cerca Del Inicio
    public List<GameObject> ordenaMenorMayor(List<GameObject> listador)
    {
        listador = listador.OrderBy(e => e.GetComponent<Movement>().currentWaypoint).ToList();

        foreach (GameObject e in listador)
        {
            if (listador[0].GetComponent<Movement>().currentWaypoint == e.GetComponent<Movement>().currentWaypoint)
            {
                listadores.Add(e);
            }
        }
        if (listadores.Count > 1)
        {
            listadores = listadores.OrderBy(e => e.GetComponent<Movement>().puntoC).ToList();
        }
        return listadores;

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
        stop = GameObject.Find("Stop");
        while (true)
        {
            if (!stop.GetComponent<Stoper>().stoped)
            {

                // busca si hay enemigos en pantalla
                if (targetEnemy != null)
                {
                    //si los hay busca la distancia si es menor a la indicada dispara si es mallor no 

                    if (distance <= fireDistance)
                    {
                        animd=true;
                        yield return new WaitForSeconds(1);
                        // Instanciar un proyectil
                        animd=false;
                        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                        Movimien_Bala movimien_Bala = projectile.GetComponent<Movimien_Bala>();
                        if (movimien_Bala != null)
                        {
                            movimien_Bala.target = targetEnemy.transform;
                            movimien_Bala.speeds = speedB;
                            movimien_Bala.danio = danio;
                            movimien_Bala.antiA = antiA;
                            movimien_Bala.verIn = verIn;
                        }

                        // Espera un tiempo definido por fireRate antes de disparar el siguiente proyectil 
                        //yield return new proboca una espera dependiendo de cietos parametros ya sa una condicion se cunpla o pase un tiempo
                        yield return new WaitForSeconds(fireRate-1);
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
            else
            {
                yield return new WaitUntil(() => (stop.GetComponent<Stoper>().stoped == false));
            }
        }
    }
    void DrawCircle()
    {
        distanciacirculo=fireDistance/6;
        lineRenderer.positionCount = segments + 1;
        // Dibujar los puntos del círculo alrededor del objeto
        float angle = 0f;
        for (int i = 0; i < segments + 1; i++) // +1 para cerrar el círculo
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * distanciacirculo;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * distanciacirculo;
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


