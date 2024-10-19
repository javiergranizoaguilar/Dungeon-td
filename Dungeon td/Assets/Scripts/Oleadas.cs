using System.Collections;
using UnityEngine;

public class oleadas : MonoBehaviour
{
    public GameObject prefabToSpawn;   // Referencia al prefab que quieres instanciar
    public Transform spawnPoint;        // Punto de origen donde se instanciará el prefab

    public Transform[] spawnPointToGO;
    public string enemyTag = "Enemy1";
    public int spawnDelay=5;

    // Start is called before the first frame update
    void Start()
    {
        intanciarEnemi();
    }

    // Update is called once per frame
    void intanciarEnemi()
    {
        // Instancia el prefab en la posición del spawnPoint y sin rotación (identidad)
        GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
        spawnedObject.GetComponent<Movimiento>().waypoints = spawnPointToGO;
    }

}
