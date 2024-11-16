using UnityEngine;
using System.Data;
using SQLite; // Necesitas importar esta librería
using System.IO;
using System;
using UnityEngine.UI;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class BaseDatos : MonoBehaviour
{
    public static int IdNombre;
    public static int Nivel_Juego;
    private SQLiteConnection db;


    void Start()
    {
        CrearDB();
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
            db.Insert(usuarioEjemplo);
            CrearDatabaseNiveles(usuarioEjemplo);


        }
    }
    public class Acceso
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int UsuarioId { get; set; } // Foreign Key a Usuario
        public int NivelId { get; set; }   // Foreign Key a Nivel
    }
    // Función para verificar las credenciales
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique]
        public string Nombre { get; set; }

        public string Contrasena { get; set; }
    }
    public class Guardados
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int IdTorres { get; set; }
        public int NivelId { get; set; }
    }
    public class Torres
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int PosX { get; set; }
        public int PosY { get; set; }
        public int MejoraA { get; set; }
        public int MejoraB { get; set; }
        public string Nombre { get; set; }

    }
    public class Nivel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int nivel { get; set; }
        public int Dificultad { get; set; }
        public bool Desbloqueado { get; set; }
        public int Puntos { get; set; }
        public int Dinero { get; set; }
        public int Vidas { get; set; }
    }
    private bool VerificarCredenciales(string nombreUsuario, string contrasena)
    {
        var usuario = db.Table<Usuario>().FirstOrDefault(u => u.Nombre == nombreUsuario && u.Contrasena == contrasena);
        return usuario != null;
    }
    public void VerifyUser(string User, string Password, TextMeshProUGUI textoError)
    {
        bool loginExitoso = VerificarCredenciales(User, Password);
        if (loginExitoso)
        {
            IdNombre = ObtenerUsuarioPorNombre(User).Id;
            SceneManager.LoadScene("Menu_Inicial");
        }
        else
        {
            textoError.text = "No se Encontro el usuario /n La Contraseña y/o usuario son incorrectos";
        }
    }
    public void CrearUser(string user, string Password)
    {
        Usuario usuarioEjemplo = new Usuario { Nombre = user, Contrasena = Password };
        db.Insert(usuarioEjemplo);
        CrearDatabaseNiveles(usuarioEjemplo);
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
    public bool ComprobarChangePassword(String OldPassword, String NewPassword, String RepeatPassword)
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
    public bool ComprobarChangeName(String Password, String RepeatPassword)
    {
        Usuario usuarioEncontrado = ObtenerUsuarioPorId(IdNombre);
        return Password.Equals(RepeatPassword);
    }
    public List<Nivel> ObtenerNivelesPorUsuario()
    {
        int idNombre = IdNombre;
        List<Acceso> accesos = db.Table<Acceso>().Where(a => a.UsuarioId == idNombre).ToList();
        List<Nivel> niveles = new List<Nivel>();

        foreach (var acceso in accesos)
        {
            Nivel nivel = db.Table<Nivel>().FirstOrDefault(n => n.Id == acceso.NivelId);
            if (nivel != null)
            {
                niveles.Add(nivel);
            }
        }

        return niveles;
    }
    public void CrearDatabaseNiveles(Usuario usuarioEjemplo)
    {
        for (int n = 1; n <= 6; n++)
        {
            for (int d = 1; d <= 3; d++)
            {
                if (n == 1 && d == 1)
                {
                    Nivel nivelEjemplo = new Nivel { nivel = n, Dificultad = d, Desbloqueado = true, Puntos = 0 };
                    db.Insert(nivelEjemplo);
                    Acceso accesoEjemplo = new Acceso { UsuarioId = usuarioEjemplo.Id, NivelId = nivelEjemplo.Id };
                    db.Insert(accesoEjemplo);
                }
                else
                {
                    Nivel nivelEjemplo1 = new Nivel { nivel = n, Dificultad = d, Desbloqueado = false, Puntos = 0 };
                    db.Insert(nivelEjemplo1);
                    Acceso accesoEjemplo1 = new Acceso { UsuarioId = usuarioEjemplo.Id, NivelId = nivelEjemplo1.Id };
                    db.Insert(accesoEjemplo1);
                }

            }
        }
    }
    public List<Nivel> ObtenerTodosLosNivelesPorUsuario()
    {
        int idNombre = IdNombre;
        List<Acceso> accesos = db.Table<Acceso>().Where(a => a.UsuarioId == idNombre).ToList();
        List<Nivel> todosLosNiveles = new List<Nivel>();

        foreach (var acceso in accesos)
        {
            Nivel nivel = db.Table<Nivel>().FirstOrDefault(n => n.Id == acceso.NivelId);
            if (nivel != null)
            {
                todosLosNiveles.Add(nivel);
            }
        }

        return todosLosNiveles;
    }
    public List<Nivel> ObtenerTodosLosNivelesPorUsuarioNivel()
    {
        int idNombre = IdNombre;
        List<Acceso> accesos = db.Table<Acceso>().Where(a => a.UsuarioId == idNombre).ToList();
        List<Nivel> todosLosNiveles = new List<Nivel>();

        foreach (var acceso in accesos)
        {
            Nivel nivel = db.Table<Nivel>().FirstOrDefault(n => (n.Id == acceso.NivelId)&&(n.nivel==Nivel_Juego));
            if (nivel != null)
            {
                todosLosNiveles.Add(nivel);
            }
        }

        return todosLosNiveles;
    }
    public List<Nivel> ObtenerTodosLosNivelesPorUsuarioSigienteNivel()
    {
        int idNombre = IdNombre;
        List<Acceso> accesos = db.Table<Acceso>().Where(a => a.UsuarioId == idNombre).ToList();
        List<Nivel> todosLosNiveles = new List<Nivel>();

        foreach (var acceso in accesos)
        {
            Nivel nivel = db.Table<Nivel>().FirstOrDefault(n => (n.Id == acceso.NivelId)&&(n.nivel==Nivel_Juego+1));
            if (nivel != null)
            {
                todosLosNiveles.Add(nivel);
            }
        }

        return todosLosNiveles;
    }
    public void setNivel(int n){
        Nivel_Juego=n;
    }
    public Nivel ObtenerPrimerNivelPorUsuario()
    {
        int idNombre = IdNombre;
        Acceso primerAcceso = db.Table<Acceso>().Where(a => a.UsuarioId == idNombre).OrderBy(a => a.Id).FirstOrDefault();

        if (primerAcceso != null)
        {
            Nivel primerNivel = db.Table<Nivel>().FirstOrDefault(n => n.Id == primerAcceso.NivelId);
            return primerNivel;
        }

        return null; // Si no se encuentra ningún nivel asociado
    }
    
}