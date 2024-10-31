using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oleadas : MonoBehaviour
{
    public GameObject[] prefabToSpawn;   // Referencia al prefab que quieres instanciar
    public Transform spawnPoint;        // Punto de origen donde se instanciará el prefab

    public Transform[] spawnPointToSpawn;
    public ControlJuego controlJuego;
    public string enemyTag = "Enemy 1";
    private float spawnDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OleadaControl());
    }

    // Update is called once per frame
    IEnumerator OleadaControl()
    {
        while (true)
        {
            switch (controlJuego.rondas)
            {
                case 1:
                    // Ejecutar la oleada 1
                    yield return StartCoroutine(ronda1());
                    break;
                case 2:
                    // Puedes agregar más rondas si es necesario
                    yield return StartCoroutine(ronda2());
                    break;
                case 3:
                    // Ejecutar la oleada 1
                    yield return StartCoroutine(ronda3());
                    break;
                case 4:
                    // Puedes agregar más rondas si es necesario
                    yield return StartCoroutine(ronda4());
                    break;
                case 5:
                    // Ejecutar la oleada 1
                    yield return StartCoroutine(ronda5());
                    break;
                case 6:
                    // Puedes agregar más rondas si es necesario
                    yield return StartCoroutine(ronda6());
                    break;
                case 7:
                    // Ejecutar la oleada 1
                    yield return StartCoroutine(ronda7());
                    break;
                case 8:
                    // Puedes agregar más rondas si es necesario
                    yield return StartCoroutine(ronda8());
                    break;
                case 9:
                    // Ejecutar la oleada 1
                    yield return StartCoroutine(ronda9());
                    break;
                case 10:
                    // Puedes agregar más rondas si es necesario
                    yield return StartCoroutine(ronda10());
                    break;
            }

            // Esperar hasta que todos los enemigos sean destruidos
            yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag(enemyTag).Length == 0);

            // Incrementar la ronda o agregar lógica para iniciar la siguiente
            controlJuego.rondas++;
        }
    }
    IEnumerator ronda1()
    {
        yield return StartCoroutine(Ronda(5, 0)); // Instancia un enemigo

    }
    IEnumerator ronda2()
    {
        yield return StartCoroutine(Ronda(7, 0)); // Instancia un enemigo

    }
    IEnumerator ronda3()
    {
        yield return StartCoroutine(Ronda(10, 0)); // Instancia un enemigo

    }
    IEnumerator ronda4()
    {
        yield return StartCoroutine(Ronda(5, 0)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 1)); // Instancia un enemigo
    }
    IEnumerator ronda5()
    {
        yield return StartCoroutine(Ronda(7, 0)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
    }
    IEnumerator ronda6()
    {
        yield return StartCoroutine(Ronda(10, 0)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 1)); // Instancia un enemigo
    }
    IEnumerator ronda7()
    {
        yield return StartCoroutine(Ronda(3, 0)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 1)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 2)); // Instancia un enemigo
    }
    IEnumerator ronda8()
    {
        yield return StartCoroutine(Ronda(3, 0)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 1)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 2)); // Instancia un enemigo
    }
    IEnumerator ronda9()
    {
        yield return StartCoroutine(Ronda(5, 0)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 1)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 2)); // Instancia un enemigo
    }
    IEnumerator ronda10()
    {
        yield return StartCoroutine(Ronda(7, 0)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 1)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 2)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 3)); // Instancia un enemigo
    }


    IEnumerator Ronda(int cantidadEnemigos, int tipoEnemigo)
    {
        // Instanciar enemigos con un retraso entre ellos
        for (int i = 0; i < cantidadEnemigos; i++)
        {
            InstanciarEnemigo(tipoEnemigo); // Instancia un enemigo del tipo especificado
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void InstanciarEnemigo(int tipoEnemigo)
    {
        if (tipoEnemigo >= 0 && tipoEnemigo < prefabToSpawn.Length)
        {
            // Instanciar el prefab en el punto de spawn y asignar waypoints
            GameObject spawnedObject = Instantiate(prefabToSpawn[tipoEnemigo], spawnPoint.position, Quaternion.identity);
            spawnedObject.GetComponent<Movement>().waypoints = spawnPointToSpawn;
        }
        else
        {
            Debug.LogWarning("Índice de tipo de enemigo fuera de rango: " + tipoEnemigo);
        }
    }
}
