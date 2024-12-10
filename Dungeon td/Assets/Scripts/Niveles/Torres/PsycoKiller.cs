using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PsycoKiller : MonoBehaviour
{
    // Start is called before the first frame update
    public SoundPlayOnes soundPlayOnes;
    public SoundPlayOnes soundPlayOnes2;
    public Transform firePoint; // Punto de origen del disparo
    public GameObject[] enemies;
    public GameObject stop;
    public GameObject targetEnemy; // Referencia al objeto enemigo actualmente en la mira 
    public List<GameObject> listado;
    public TowerDragHandler towerDragHandler;
    public ControlJuego controlJuego;
    private Coroutine shootingCoroutine;
    public string enemyTag = "Enemy 1"; // Etiqueta del enemigo a apuntar
    public string mono;
    public float fireRate = 8f;
    public int danio = 1;
    // Número de segmentos (cuanto más alto, más suave será el círculo)
    public bool verIn = true;
    public bool antiA = false;
    public bool animd = false;
    // Start is called before the first frame update
    public int dar = 20;
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

    public List<GameObject> listadores = new List<GameObject>();
    void Awake()
    {
        soundPlayOnes = GameObject.Find("DeathEnemiesSoundManager").GetComponent<SoundPlayOnes>();
        soundPlayOnes2 = GameObject.Find("HitEnemiesSoundManager").GetComponent<SoundPlayOnes>();
    }
    void Start()
    {
        firePoint = gameObject.transform;
    }
    // Update is called once per frame
    void Update()
    {

        if (towerDragHandler != null)
        {
            enemigos();
            StartShooting();
        }
        else
        {
            GameObject gameObject = GameObject.Find("GameManager");

            controlJuego = (ControlJuego)gameObject.GetComponent("ControlJuego");
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
            if (!(e.GetComponent<Movement>().invisible && !verIn))
            {
                listado.Add(e);

            }
        }
        //Indica que tipo de apuntado se desea
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
            listado.Clear();
        }
    }
    //Mas Vida
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
            listadores = listadores.OrderBy(e => e.GetComponent<Movement>().puntoC).ToList();
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
            listadores = listadores.OrderByDescending(e => e.GetComponent<Movement>().puntoC).ToList();
        }
        return listadores;

    }
    public void StartShooting()
    {
        // Si la torre no está siendo arrastrada (isDragging es false) y no hay una corutina de disparo activa
        if (!towerDragHandler.isDragging && shootingCoroutine == null)
        {
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

                    yield return new WaitForSeconds(fireRate - 1);
                    animd = true;
                    yield return new WaitForSeconds(1);
                    // Instanciar un proyectil
                    animd = false;
                    if (targetEnemy == null)
                    {
                        yield return new WaitUntil(() => (targetEnemy != null));
                    }
                    Movement movement = targetEnemy.GetComponent<Movement>();
                    movement.vida -= danio;
                    if (antiA && movement.acorazado)
                    {
                        movement.vida -= danio * 8;
                    }
                    if (movement.vida <= 0)
                    {
                        soundPlayOnes.PlaySound();
                        controlJuego.dinero += dar;
                        controlJuego.dineroF += dar;
                        Destroy(targetEnemy);
                    }
                    else
                    {
                        soundPlayOnes2.PlaySound();
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
}