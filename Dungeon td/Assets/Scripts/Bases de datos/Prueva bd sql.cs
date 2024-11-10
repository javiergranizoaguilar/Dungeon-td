using UnityEngine;
using System.Data;
using SQLite; // Necesitas importar esta librería
using System.IO;

public class Pruevabdsql : MonoBehaviour
{
    private SQLiteConnection db;

    void Start()
    {
        // Define la ruta de la base de datos
        string dbPath = Path.Combine(Application.persistentDataPath, "jugadores.db");

        // Verifica si el archivo de base de datos ya existe
        bool dbExists = File.Exists(dbPath);

        // Crea la conexión a la base de datos
        db = new SQLiteConnection(dbPath);

        // Si la base de datos no existía, crea la tabla
        if (!dbExists)
        {
            Debug.Log("La base de datos no existe. Creando nueva base de datos y tabla 'Jugador'...");
            db.CreateTable<Jugador>();

            // Inserta un jugador inicial como ejemplo
            Jugador nuevoJugador = new Jugador { Nombre = "Juan", Puntos = 100 };
            db.Insert(nuevoJugador);
        }
        else
        {
            Debug.Log("La base de datos ya existe. Cargando datos existentes.");
        }

        // Consulta todos los jugadores
        var jugadores = db.Table<Jugador>().ToList();
        foreach (var jugador in jugadores)
        {
            Debug.Log($"Jugador: {jugador.Nombre}, Puntos: {jugador.Puntos}, Id: {jugador.Id}");
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
