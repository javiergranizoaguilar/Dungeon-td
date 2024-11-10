using UnityEngine;
using System.Data;
using SQLite; // Necesitas importar esta librería
using System.IO;
using System;
using UnityEngine.UI;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class User_Password : MonoBehaviour
{
    private SQLiteConnection db;
    public InputField User;
    public InputField Password;
    public GameObject BotonVerificar;
    public GameObject BotonCrear;
    public GameObject TextNoUser;

    void Start()
    {
        CrearDB();
    }
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique]
        public string Nombre { get; set; }

        public string Contrasena { get; set; }
    }
    public class Nivel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int Dificultad { get; set; }
        public bool Desbloqueado { get; set; }
        public int Puntos { get; set; }
    }
    public class Acceso
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int UsuarioId { get; set; } // Foreign Key a Usuario
        public int NivelId { get; set; }   // Foreign Key a Nivel
    }
    // Función para verificar las credenciales
    private bool VerificarCredenciales(string nombreUsuario, string contrasena)
    {
        var usuario = db.Table<Usuario>().FirstOrDefault(u => u.Nombre == nombreUsuario && u.Contrasena == contrasena);
        return usuario != null;
    }
    public void VerifyUser()
    {
        string nombreUsuario = User.text;
        string contrasena = Password.text;
        bool loginExitoso = VerificarCredenciales(nombreUsuario, contrasena);

        if (loginExitoso)
        {
            SceneManager.LoadScene("Menu_Inicial");
        }
    }
    public void CrearDB()
    {
        // Define la ruta de la base de datos
        string dbPath = Path.Combine(Application.persistentDataPath, "juego.db");

        // Verifica si el archivo de base de datos ya existe
        bool dbExists = File.Exists(dbPath);

        // Crea la conexión a la base de datos
        db = new SQLiteConnection(dbPath);

        // Si la base de datos no existía, crea las tablas
        if (!dbExists)
        {
            Debug.Log("La base de datos no existe. Creando nueva base de datos y tablas...");

            // Crear tablas
            db.CreateTable<Usuario>();
            db.CreateTable<Nivel>();
            db.CreateTable<Acceso>();

            // Datos de ejemplo
            Usuario usuarioEjemplo = new Usuario { Nombre = "Juan", Contrasena = "1234" };
            Nivel nivelEjemplo = new Nivel { Dificultad = 1, Desbloqueado = true, Puntos = 0 };

            // Inserta ejemplos en las tablas
            db.Insert(usuarioEjemplo);
            db.Insert(nivelEjemplo);

            // Inserta la relación de acceso
            Acceso accesoEjemplo = new Acceso { UsuarioId = usuarioEjemplo.Id, NivelId = nivelEjemplo.Id };
            db.Insert(accesoEjemplo);

            Debug.Log("Datos de ejemplo creados.");
        }
        else
        {
            Debug.Log("La base de datos ya existe. Cargando datos existentes.");
        }
    }
    public void CrearUser()
    {
        Usuario usuarioEjemplo = new Usuario { Nombre = User.text, Contrasena = Password.text};
        Nivel nivelEjemplo = new Nivel { Dificultad = 1, Desbloqueado = true, Puntos = 0 };

        // Inserta ejemplos en las tablas
        db.Insert(usuarioEjemplo);
        db.Insert(nivelEjemplo);

        // Inserta la relación de acceso
        Acceso accesoEjemplo = new Acceso { UsuarioId = usuarioEjemplo.Id, NivelId = nivelEjemplo.Id };
        db.Insert(accesoEjemplo);

        CambiarVerificar();
    }
    public void CambiarCrear()
    {
        BotonCrear.SetActive(true);
        BotonVerificar.SetActive(false);
        TextNoUser.SetActive(false);
    }
    public void CambiarVerificar()
    {
        BotonCrear.SetActive(false);
        BotonVerificar.SetActive(true);
        TextNoUser.SetActive(true);
    }
}