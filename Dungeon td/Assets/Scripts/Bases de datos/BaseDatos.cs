using UnityEngine;
using SQLite; // Necesitas importar esta librería
using System.IO;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class BaseDatos : MonoBehaviour
{
    public static int IdNombre;
    public static int Nivel_Juego;
    private SQLiteConnection db;

    void Awake()
    {
        CrearDB();
    }
    void Start()
    {

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
            db.CreateTable<Guardados>();
            db.CreateTable<Torres>();

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

        public float PosX { get; set; }
        public float PosY { get; set; }
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
        public int PuntosM { get; set; }
        public int Dinero { get; set; }
        public int Vidas { get; set; }
        public int Ronda { get; set; }
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
                if ((n == 1 && d == 1) || usuarioEjemplo.Nombre=="Juan")
                {
                    Nivel nivelEjemplo = new Nivel
                    {
                        nivel = n,
                        Dificultad = d,
                        Desbloqueado = true,
                        Puntos = 0,
                        PuntosM = 0,
                        Dinero = 0,
                        Vidas = 0,
                        Ronda = 0
                    };
                    db.Insert(nivelEjemplo);
                    Acceso accesoEjemplo = new Acceso { UsuarioId = usuarioEjemplo.Id, NivelId = nivelEjemplo.Id };
                    db.Insert(accesoEjemplo);
                }
                else
                {
                    Nivel nivelEjemplo1 = new Nivel
                    {
                        nivel = n,
                        Dificultad = d,
                        Desbloqueado = false,
                        Puntos = 0,
                        PuntosM = 0,
                        Dinero = 0,
                        Vidas = 0,
                        Ronda = 0
                    };
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
            Nivel nivel = db.Table<Nivel>().FirstOrDefault(n => (n.Id == acceso.NivelId) && (n.nivel == Nivel_Juego));
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
            Nivel nivel = db.Table<Nivel>().FirstOrDefault(n => (n.Id == acceso.NivelId) && (n.nivel == Nivel_Juego + 1));
            if (nivel != null)
            {
                todosLosNiveles.Add(nivel);
            }
        }

        return todosLosNiveles;
    }
    public void setNivel(int n)
    {
        Nivel_Juego = n;
    }
    public int getIdNombre()
    {
        return IdNombre;
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
    public Nivel ObtenerPrimerNivelPorUsuarioNivelDificultad(int Dificultad)
    {
        int idNombre = IdNombre;
        List<Acceso> Acceso = db.Table<Acceso>().Where(a => a.UsuarioId == idNombre).ToList();
        if (Acceso == null)
        {
            Debug.LogError("No se encontró ningún acceso para el usuario especificado.");
            return null;
        }
        Nivel primerNivel = null;
        foreach (Acceso primerAcceso in Acceso)
        {
            Nivel saver = db.Table<Nivel>().FirstOrDefault(n => (n.Id == primerAcceso.NivelId) && (n.Dificultad == Dificultad) && (n.nivel == Nivel_Juego));
            if (saver != null)
            {
                primerNivel = saver;
            }

        }
        if (primerNivel != null)
        {
            return primerNivel;
        }
        else
        {
            Debug.LogError("No se encontró ningún nivel para el usuario especificado y la dificultad");
            return null;
        }
    }
    public void EliminarTorresYGuardadosPorNivelYDificultad(int dificultad)
    {
        // Verificar que la conexión a la base de datos está inicializada
        if (db == null)
        {
            Debug.LogError("La conexión a la base de datos no está inicializada.");
            return;
        }

        // Obtener el nivel correspondiente por nivelJuego y dificultad
        Nivel nivel = db.Table<Nivel>().FirstOrDefault(n => n.nivel == Nivel_Juego && n.Dificultad == dificultad);
        if (nivel == null)
        {
            Debug.LogError("No se encontró ningún nivel con el nivel de juego y la dificultad especificada.");
            return;
        }

        int nivelId = nivel.Id;

        // Obtener todos los registros de Guardados para el nivel especificado
        List<Guardados> guardados = db.Table<Guardados>().Where(g => g.NivelId == nivelId).ToList();
        if (guardados == null || guardados.Count == 0)
        {
            Debug.LogWarning("No se encontraron registros en Guardados para el nivel especificado.");
            return;
        }

        // Iterar sobre los registros de Guardados
        foreach (var guardado in guardados)
        {
            // Obtener la torre correspondiente a cada registro de Guardados
            Torres torre = db.Table<Torres>().FirstOrDefault(t => t.Id == guardado.IdTorres);

            // Eliminar la torre si existe
            if (torre != null)
            {
                db.Delete(torre);
            }

            // Eliminar el registro de Guardados
            db.Delete(guardado);
        }

        Debug.Log("Todas las torres y los registros de guardados asociados para el nivel con ID " + nivelId + " han sido eliminados.");
    }
    public void GuardarTorres(GameObject[] personaje, int Dificultad)
    {
        if (personaje == null || personaje.Length == 0)
        {
            Debug.LogError("El array de personajes es null o está vacío."); return;
        }
        // Obtener el ID del nivel correspondiente y verificar que no sea null 
        Nivel nivel = ObtenerPrimerNivelPorUsuarioNivelDificultad(Dificultad);
        if (nivel == null)
        {
            Debug.LogError("No se encontró el nivel para la dificultad especificada.");
            return;
        }
        int id_nivel = nivel.Id;
        foreach (GameObject p in personaje)
        {
            if (p == null)
            {
                Debug.LogError("Uno de los objetos en el array de personajes es null.");
                continue;
            }
            int mejoraA = 0;
            int mejoraB = 0;
            switch (p.name)
            {
                case "Granja(Clone)":
                    mejoraA = p.GetComponent<Granja>().mejoraA;
                    mejoraB = p.GetComponent<Granja>().mejoraB;
                    break;
                case "Trampa(Clone)":
                    mejoraA = 0;
                    mejoraB = 0;
                    break;
                case "Psycokiller(Clone)":
                    mejoraA = p.GetComponent<PsycoKiller>().mejoraA;
                    mejoraB = p.GetComponent<PsycoKiller>().mejoraB;
                    break;
                default:
                    mejoraA = p.GetComponent<Disparo_base>().mejoraA;
                    mejoraA = p.GetComponent<Disparo_base>().mejoraB;
                    break;
            }
            // Crear una nueva instancia de Torres 
            Torres t = new Torres
            {
                PosX = p.transform.position.x,
                PosY = p.transform.position.y,
                MejoraA = mejoraA,
                MejoraB = mejoraB,
                Nombre = p.name
            };
            // Insertar la nueva torre en la base de datos y obtener el ID generado 
            db.Insert(t);
            // Crear una nueva instancia de Guardados con el ID de la torre recién insertada 
            Guardados g = new Guardados { IdTorres = t.Id, NivelId = id_nivel };
            // Insertar el registro de Guardados en la base de datos 
            db.Insert(g);

        }
    }
    public void Poner(int Dificultad, int Puntos, bool fin)
    {
        Nivel i = ObtenerPrimerNivelPorUsuarioNivelDificultad(Dificultad);
        i.Puntos = Puntos;
        if (fin)
        {
            if (i.PuntosM < Puntos)
            {
                i.PuntosM = Puntos;
            }
        }
        db.Update(i);
    }
    public List<Torres> ObtenerTodosLasTorresPorUsuarioNivelDificultad(int Dificultad)
    {
        int idNombre = IdNombre;
        List<Torres> torres = new List<Torres>();


        Nivel nivel = ObtenerPrimerNivelPorUsuarioNivelDificultad(Dificultad);
        if (nivel == null)
        {
            Debug.LogError("No se encontró ningún nivel con la dificultad especificada.");
            return torres; // Retornar lista vacía
        }

        // Obtener los guardados para el nivel especificado
        List<Guardados> guardados = db.Table<Guardados>().Where(g => g.NivelId == nivel.Id).ToList();
        if (guardados == null || guardados.Count == 0)
        {
            Debug.LogError("No se encontraron guardados para el nivel especificado.");
            return torres; // Retornar lista vacía
        }

        // Obtener las torres correspondientes a cada guardado
        foreach (var guardado in guardados)
        {
            Torres torres1 = db.Table<Torres>().FirstOrDefault(t => t.Id == guardado.IdTorres);
            if (torres1 != null)
            {
                torres.Add(torres1);
            }
        }

        return torres;
    }
    public Boolean SaberLasTorresPorUsuarioNivelDificultad(int Dificultad)
    {
        bool a = false;
        Nivel nivel = ObtenerPrimerNivelPorUsuarioNivelDificultad(Dificultad);
        if (nivel != null)
        {
            List<Guardados> guardados = db.Table<Guardados>().Where(g => g.NivelId == nivel.Id).ToList();
            if (guardados.Count != 0)
            {
                a = true;
            }
        }
        return a;
    }
    public void guardarPartida(GameObject[] gameObjects, int Dificultad, int dinero, int vidas, int rondas)
    {
        EliminarTorresYGuardadosPorNivelYDificultad(Dificultad);
        GuardarTorres(gameObjects, Dificultad);
        Poner(Dificultad, dinero, false);
        Nivel n = ObtenerPrimerNivelPorUsuarioNivelDificultad(Dificultad);
        n.Dinero = dinero;
        n.Vidas = vidas;
        n.Ronda = rondas;
        db.Update(n);
    }

    public void Jugable(Nivel nivel){
        nivel.Desbloqueado=true;
        db.Update(nivel);
    }
}