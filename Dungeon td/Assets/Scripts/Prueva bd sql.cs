using UnityEngine;
using System.Data;
using SQLite; // Necesitas importar esta librería

public class Pruevabdsql : MonoBehaviour
{
    private SQLiteConnection db;

    void Start()
    {
        // Crea la conexión a la base de datos (si no existe, la crea)
        string dbPath = System.IO.Path.Combine(Application.persistentDataPath, "jugadores.db");
        db = new SQLiteConnection(dbPath);

        // Crea una tabla llamada "Jugador"
        db.CreateTable<Jugador>();

        // Inserta un jugador
        Jugador nuevoJugador = new Jugador { Nombre = "Juan", Puntos = 100 };
        db.Insert(nuevoJugador);

        // Consulta todos los jugadores
        var jugadores = db.Table<Jugador>().ToList();
        foreach (var jugador in jugadores)
        {
            Debug.Log($"Jugador: {jugador.Nombre}, Puntos: {jugador.Puntos}");
        }
        Debug.Log("Base de datos guardada en: " + dbPath);

    }

    // Clase que representa la estructura de la tabla en la base de datos
    public class Jugador
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Puntos { get; set; }
    }
}
