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
    public static int IdNombre;
    private SQLiteConnection db;


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
        public int nivel { get; set; }
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
    public void VerifyUser(string User, string Password)
    {
        string nombreUsuario = User;
        string contrasena = Password;
        bool loginExitoso = VerificarCredenciales(nombreUsuario, contrasena);
        if (loginExitoso)
        {
            IdNombre = ObtenerUsuarioPorNombre(nombreUsuario).Id;
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
    public void CrearUser(string user, string Password)
    {
        Usuario usuarioEjemplo = new Usuario { Nombre = user, Contrasena = Password };
        Nivel nivelEjemplo = new Nivel { nivel=1,Dificultad = 1, Desbloqueado = true, Puntos = 0 };

        // Inserta ejemplos en las tablas
        db.Insert(usuarioEjemplo);
        db.Insert(nivelEjemplo);

        // Inserta la relación de acceso
        Acceso accesoEjemplo = new Acceso { UsuarioId = usuarioEjemplo.Id, NivelId = nivelEjemplo.Id };
        db.Insert(accesoEjemplo);
    }
    public Usuario ObtenerUsuarioPorNombre(string nombre)
    {
        // Hacer una consulta para obtener el usuario con el nombre especificado
        return db.Table<Usuario>().FirstOrDefault(u => u.Nombre == nombre);
    }
    public Usuario ObtenerUsuarioPorId(int id)
    {
        // Busca el usuario en la base de datos usando el Id
        return db.Table<Usuario>().FirstOrDefault(u => u.Id == id);
    }
    public bool ChangePassword(String OldPassword, String NewPassword, String RepeatPassword)
    {
        Usuario usuarioEncontrado = ObtenerUsuarioPorId(IdNombre);
        return (usuarioEncontrado.Contrasena.Equals(OldPassword)) && (NewPassword.Equals(RepeatPassword));
    }
    public void CambiarContrasenia(string nuevaContrasena)
    {
        // Busca el usuario por Id
        Usuario usuario = ObtenerUsuarioPorId(IdNombre);
        if (usuario != null)
        {
            // Si el usuario existe, actualiza la contraseña
            usuario.Contrasena = nuevaContrasena;
            db.Update(usuario); // Guarda los cambios en la base de datos
        }
    }
    public void CambiarName(string nuevoNombre)
    {
        // Busca el usuario por Id
        Usuario usuario = ObtenerUsuarioPorId(IdNombre);
        if (usuario != null)
        {
            // Si el usuario existe, actualiza la contraseña
            usuario.Nombre = nuevoNombre;
            db.Update(usuario); // Guarda los cambios en la base de datos
        }
    }
    public bool ChangeName(String NewPassword, String RepeatPassword)
    {
        Usuario usuarioEncontrado = ObtenerUsuarioPorId(IdNombre);
        return NewPassword.Equals(RepeatPassword);
    }
}
