using System.Collections;
using UnityEngine;

public class oleadas : MonoBehaviour
{
    public GameObject prefabToSpawn;   // Referencia al prefab que quieres instanciar
    public Transform spawnPoint;        // Punto de origen donde se instanciará el prefab
    public ControlJuego controlJuego;
    public Transform[] spawnPointToGO;
    public string enemyTag = "Enemy1";
    public int spawnDelay=5;

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
                    Debug.Log("Iniciando Ronda 2...");
                    break;
            }

            // Esperar hasta que todos los enemigos sean destruidos
            yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag(enemyTag).Length == 0);

            // Incrementar la ronda o agregar lógica para iniciar la siguiente
            controlJuego.rondas++;
        }
    }
    void intanciarEnemi()
    {
        // Instancia el prefab en la posición del spawnPoint y sin rotación (identidad)
        GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
        spawnedObject.GetComponent<Movimiento>().waypoints = spawnPointToGO;
    }
    IEnumerator ronda1()
    {
        // Instanciar 5 enemigos con un retraso de spawnDelay entre ellos
        for (int i = 0; i < 10; i++)
        {
            intanciarEnemi(); // Instancia un enemigo
            yield return new WaitForSeconds(spawnDelay); // Espera spawnDelay segundos antes de instanciar el siguiente enemigo
        }
    }

}
