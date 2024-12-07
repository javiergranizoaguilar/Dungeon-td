using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class oleadas : MonoBehaviour
{
    public GameObject[] prefabToSpawn;   // Referencia al prefab que quieres instanciar
    public Transform spawnPoint;        // Punto de origen donde se instanciará el prefab
    public Stoper stoper;
    public Transform[] spawnPointToSpawn1;
    public Transform[] spawnPointToSpawn2;
    public ControlJuego controlJuego;
    public string enemyTag = "Enemy 1";
    private float spawnDelay = 1f;
    public int Dificultad = 0;
    public bool parado = true;
    public BaseDatos baseDatos;
    public bool todosFuerea = false;
    public bool todosMuertos = false;
    // Start is called before the first frame update
    void Awake()
    {


    }
    void Start()
    {
        if (controlJuego.Facil)
        {
            Dificultad = 1;
        }
        if (controlJuego.Medio)
        {
            Dificultad = 2;
        }
        if (controlJuego.Dificil)
        {
            Dificultad = 3;
        }

        StartCoroutine(OleadaControl());
    }
    public void Puntos()
    {
        baseDatos.Poner(Dificultad, controlJuego.dinero * controlJuego.vidas, true);
    }
    // Update is called once per frame
    IEnumerator OleadaControl()
    {
        if (controlJuego.Guardar)
        {
            Debug.Log(baseDatos.getIdNombre());
            controlJuego.instanciarTorres(baseDatos.ObtenerTodosLasTorresPorUsuarioNivelDificultad(Dificultad));
        }

        while (true)
        {
            todosFuerea = false;
            switch (controlJuego.getRonda())
            {
                case 1:
                    StartCoroutine(ronda1());
                    break;
                case 2:
                    StartCoroutine(ronda2());
                    break;
                case 3:
                    StartCoroutine(ronda3());
                    break;
                case 4:
                    StartCoroutine(ronda4());
                    break;
                case 5:
                    StartCoroutine(ronda5());
                    break;
                case 6:
                    StartCoroutine(ronda6());
                    break;
                case 7:
                    StartCoroutine(ronda7());
                    break;
                case 8:
                    StartCoroutine(ronda8());
                    break;
                case 9:
                    StartCoroutine(ronda9());
                    break;
                case 10:
                    StartCoroutine(ronda10());
                    break;
                case 11:
                    StartCoroutine(ronda11());
                    break;
                case 12:
                    StartCoroutine(ronda12());
                    break;
                case 13:
                    StartCoroutine(ronda13());
                    break;
                case 14:
                    StartCoroutine(ronda14());
                    break;
                case 15:
                    StartCoroutine(ronda15());
                    break;
                case 16:
                    StartCoroutine(ronda16());
                    break;
                case 17:
                    StartCoroutine(ronda17());
                    break;
                case 18:
                    StartCoroutine(ronda18());
                    break;
                case 19:
                    StartCoroutine(ronda19());
                    break;
                case 20:
                    StartCoroutine(ronda20());
                    break;
                case 21:
                    StartCoroutine(ronda21());
                    break;
                case 22:
                    StartCoroutine(ronda22());
                    break;
                case 23:
                    StartCoroutine(ronda23());
                    break;
                case 24:
                    StartCoroutine(ronda24());
                    break;
                case 25:
                    StartCoroutine(ronda25());
                    break;
                case 26:
                    StartCoroutine(ronda26());
                    break;
                case 27:
                    StartCoroutine(ronda27());
                    break;
                case 28:
                    StartCoroutine(ronda28());
                    break;
                case 29:
                    StartCoroutine(ronda29());
                    break;
                case 30:
                    StartCoroutine(ronda30());
                    break;
                case 31:
                    StartCoroutine(ronda31());
                    break;
                case 32:
                    StartCoroutine(ronda32());
                    break;
                case 33:
                    StartCoroutine(ronda33());
                    break;
                case 34:
                    StartCoroutine(ronda34());
                    break;
                case 35:
                    StartCoroutine(ronda35());
                    break;
                case 36:
                    StartCoroutine(ronda36());
                    break;
                case 37:
                    StartCoroutine(ronda37());
                    break;
                case 38:
                    StartCoroutine(ronda38());
                    break;
                case 39:
                    StartCoroutine(ronda39());
                    break;
                case 40:
                    StartCoroutine(ronda40());
                    break;
                case 41:
                    StartCoroutine(ronda41());
                    break;
                case 42:
                    StartCoroutine(ronda42());
                    break;
                case 43:
                    StartCoroutine(ronda43());
                    break;
                case 44:
                    StartCoroutine(ronda44());
                    break;
                case 45:
                    StartCoroutine(ronda45());
                    break;
                case 46:
                    StartCoroutine(ronda46());
                    break;
                case 47:
                    StartCoroutine(ronda47());
                    break;
                case 48:
                    StartCoroutine(ronda48());
                    break;
                case 49:
                    StartCoroutine(ronda49());
                    break;
                case 50:
                    StartCoroutine(ronda50());
                    break;
                case 51:
                    StartCoroutine(ronda51());
                    break;
                case 52:
                    StartCoroutine(ronda52());
                    break;
                case 53:
                    StartCoroutine(ronda53());
                    break;
                case 54:
                    StartCoroutine(ronda54());
                    break;
                case 55:
                    StartCoroutine(ronda55());
                    break;
                case 56:
                    StartCoroutine(ronda56());
                    break;
                case 57:
                    StartCoroutine(ronda57());
                    break;
                case 58:
                    StartCoroutine(ronda58());
                    break;
                case 59:
                    StartCoroutine(ronda59());
                    break;
                case 60:
                    StartCoroutine(ronda60());
                    break;
                case 61:
                    StartCoroutine(ronda61());
                    break;
                case 62:
                    StartCoroutine(ronda62());
                    break;
                case 63:
                    StartCoroutine(ronda63());
                    break;
                case 64:
                    StartCoroutine(ronda64());
                    break;
                case 65:
                    StartCoroutine(ronda65());
                    break;
                case 66:
                    StartCoroutine(ronda66());
                    break;
                case 67:
                    StartCoroutine(ronda67());
                    break;
                case 68:
                    StartCoroutine(ronda68());
                    break;
                case 69:
                    StartCoroutine(ronda69());
                    break;
                case 70:
                    StartCoroutine(ronda70());
                    break;
                case 71:
                    StartCoroutine(ronda71());
                    break;
                case 72:
                    StartCoroutine(ronda72());
                    break;
                case 73:
                    StartCoroutine(ronda73());
                    break;
                case 74:
                    StartCoroutine(ronda74());
                    break;
                case 75:
                    StartCoroutine(ronda75());
                    break;
                case 76:
                    StartCoroutine(ronda76());
                    break;
                case 77:
                    StartCoroutine(ronda77());
                    break;
                case 78:
                    StartCoroutine(ronda78());
                    break;
                case 79:
                    StartCoroutine(ronda79());
                    break;
                case 80:
                    StartCoroutine(ronda80());
                    break;
                case 81:
                    StartCoroutine(ronda81());
                    break;
                case 82:
                    StartCoroutine(ronda82());
                    break;
                case 83:
                    StartCoroutine(ronda83());
                    break;
                case 84:
                    StartCoroutine(ronda84());
                    break;
                case 85:
                    StartCoroutine(ronda85());
                    break;
                case 86:
                    StartCoroutine(ronda86());
                    break;
                case 87:
                    StartCoroutine(ronda87());
                    break;
                case 88:
                    StartCoroutine(ronda88());
                    break;
                case 89:
                    StartCoroutine(ronda89());
                    break;
                case 90:
                    StartCoroutine(ronda90());
                    break;
                case 91:
                    StartCoroutine(ronda91());
                    break;
                case 92:
                    StartCoroutine(ronda92());
                    break;
                case 93:
                    StartCoroutine(ronda93());
                    break;
                case 94:
                    StartCoroutine(ronda94());
                    break;
                case 95:
                    StartCoroutine(ronda95());
                    break;
                case 96:
                    StartCoroutine(ronda96());
                    break;
                case 97:
                    StartCoroutine(ronda97());
                    break;
                case 98:
                    StartCoroutine(ronda98());
                    break;
                case 99:
                    StartCoroutine(ronda99());
                    break;
                case 100:
                    StartCoroutine(ronda100());
                    break;
                default:
                    Debug.LogError("Ronda no válida.");
                    break;
            }

            // Esperar hasta que todos los enemigos sean destruidos
            yield return new WaitUntil(() => todosFuerea);
            yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag(enemyTag).Length == 0);

            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Personaje");
            controlJuego.MasRonda();
            baseDatos.guardarPartida(gameObjects, Dificultad, controlJuego.dineroF, controlJuego.vidas, controlJuego.getRonda());
        }
    }
    IEnumerator ronda1()
    {

        yield return StartCoroutine(Ronda(5, 0)); // Instancia un enemigo
        todosFuerea = true;
    }
    IEnumerator ronda2()
    {
        yield return StartCoroutine(Ronda(7, 0)); // Instancia un enemigo
        todosFuerea = true;
    }
    IEnumerator ronda3()
    {
        yield return StartCoroutine(Ronda(10, 0)); // Instancia un enemigo
        todosFuerea = true;
    }
    IEnumerator ronda4()
    {
        StartCoroutine(Ronda(5, 0)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 1)); // Instancia un enemigo
        todosFuerea = true;
    }
    IEnumerator ronda5()
    {
        StartCoroutine(Ronda(7, 0)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        todosFuerea = true;
    }
    IEnumerator ronda6()
    {
        StartCoroutine(Ronda(10, 0)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 1)); // Instancia un enemigo
        todosFuerea = true;
    }
    IEnumerator ronda7()
    {
        yield return StartCoroutine(Ronda(3, 0)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 1)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 2)); // Instancia un enemigo
        todosFuerea = true;
    }
    IEnumerator ronda8()
    {
        StartCoroutine(Ronda(3, 0)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 1)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 2)); // Instancia un enemigo
        todosFuerea = true;
    }
    IEnumerator ronda9()
    {
        StartCoroutine(Ronda(5, 0)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 1)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 2)); // Instancia un enemigo
        todosFuerea = true;
    }
    IEnumerator ronda10()
    {
        StartCoroutine(Ronda(7, 0)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 1)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 2)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 3)); // Instancia un enemigo
        todosFuerea = true;

    }
    IEnumerator ronda11()
    {
        StartCoroutine(Ronda(4, 4)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 1)); // Instancia un enemigo
        todosFuerea = true;
    }
    IEnumerator ronda12()
    {

        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(7, 5)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(6, 2)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 4)); // Instancia un enemigo
        todosFuerea = true;
    }
    IEnumerator ronda13()
    {
        StartCoroutine(Ronda(7, 2)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 4)); // Instancia un enemigo
        todosFuerea = true;

    }
    IEnumerator ronda14()
    {
        StartCoroutine(Ronda(4, 5)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(6, 1)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 3)); // Instancia un enemigo
        yield return null; todosFuerea = true;
    }
    IEnumerator ronda15()
    {
        StartCoroutine(Ronda(5, 5)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(7, 0)); // Instancia un enemigo
        yield return null; todosFuerea = true;
    }
    IEnumerator ronda16()
    {
        StartCoroutine(Ronda(7, 5)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 6)); // Instancia un enemigo
        StartCoroutine(Ronda(6, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 4)); // Instancia un enemigo
        yield return null; todosFuerea = true;
    }
    IEnumerator ronda17()
    {
        StartCoroutine(Ronda(10, 5)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(7, 6)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 7)); // Instancia un enemigo
        yield return null; todosFuerea = true;
    }
    IEnumerator ronda18()
    {
        StartCoroutine(Ronda(4, 6)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 7)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 8)); // Instancia un enemigo
        yield return null; todosFuerea = true;
    }
    IEnumerator ronda19()
    {
        StartCoroutine(Ronda(10, 6)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 7)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(7, 8)); // Instancia un enemigo
        yield return null; todosFuerea = true;
    }
    IEnumerator ronda20()
    {
        StartCoroutine(Ronda(7, 4)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 5)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 9)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 8)); // Instancia un enemigo
        yield return null; todosFuerea = true;
    }
    IEnumerator ronda21()
    {
        yield return StartCoroutine(Ronda(7, 7)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 5)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 9)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 8)); // Instancia un enemigo
        yield return null; todosFuerea = true;
    }
    IEnumerator ronda22()
    {
        StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 9)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda23()
    {
        StartCoroutine(Ronda(7, 2)); // Instancia un enemigo 
        yield return StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 4)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 7)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda24()
    {
        StartCoroutine(Ronda(7, 4)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 6)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 8)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda25()
    {
        StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 9)); // Instancia un enemigo
        yield return null; todosFuerea = true;
    }
    IEnumerator ronda26()
    {
        yield return StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 11)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda27()
    {
        StartCoroutine(Ronda(9, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 8)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 11)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda28()
    {
        StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 11)); // Instancia un enemigo
        yield return null; todosFuerea = true;
    }
    IEnumerator ronda29()
    {
        StartCoroutine(Ronda(7, 5)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 9)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(8, 11)); // Instancia un enemigo
        yield return null; todosFuerea = true;
    }
    IEnumerator ronda30()
    {
        yield return StartCoroutine(Ronda(7, 3)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 4)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(2, 12)); // Instancia un enemigo
        yield return null; todosFuerea = true;
    }
    IEnumerator ronda31()
    {
        yield return StartCoroutine(Ronda(3, 7)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 3)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(8, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(6, 12)); // Instancia un enemigo
        yield return null; todosFuerea = true;
    }
    IEnumerator ronda32()
    {
        yield return StartCoroutine(Ronda(7, 7)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 4)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 11)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(8, 12)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda33()
    {
        yield return StartCoroutine(Ronda(7, 5)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 9)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 11)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 12)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda34()
    {
        yield return StartCoroutine(Ronda(6, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 13)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda35()
    {
        yield return StartCoroutine(Ronda(7, 5)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(8, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(6, 12)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 13)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda36()
    {
        yield return StartCoroutine(Ronda(7, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 11)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 12)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 13)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda37()
    {
        yield return StartCoroutine(Ronda(7, 5)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 9)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(8, 13)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda38()
    {
        yield return StartCoroutine(Ronda(20, 5)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(13, 12)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(22, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 11)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda39()
    {
        yield return StartCoroutine(Ronda(32, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(30, 12)); // Instancia un enemigo
        StartCoroutine(Ronda(14, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(12, 3)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda40()
    {

        yield return StartCoroutine(Ronda(1, 18)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
        yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag(enemyTag).Length == 0);
        if (controlJuego.Facil && todosFuerea && GameObject.FindGameObjectsWithTag(enemyTag).Length == 0)
        {
            stoper.Stop();
            List<BaseDatos.Nivel> n = baseDatos.ObtenerTodosLosNivelesPorUsuarioNivel();
            if (n[0].nivel < 6)
            {
                foreach (BaseDatos.Nivel niv in n)
                {
                    if (niv.Dificultad >= 2)
                    {
                        niv.Desbloqueado = true;
                    }
                }
            }
        }
    }
    IEnumerator ronda41()
    {
        yield return StartCoroutine(Ronda(7, 7)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 5)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 9)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 8)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda42()
    {
        StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 9)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda43()
    {
        StartCoroutine(Ronda(7, 2)); // Instancia un enemigo 
        StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 4)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 7)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda44()
    {
        StartCoroutine(Ronda(7, 4)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 6)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 8)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda45()
    {
        yield return StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 9)); // Instancia un enemigo
        yield return null; todosFuerea = true;
    }
    IEnumerator ronda46()
    {
        StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 11)); // Instancia un enemigo
        yield return null; todosFuerea = true;
    }
    IEnumerator ronda47()
    {
        StartCoroutine(Ronda(9, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 8)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 11)); // Instancia un enemigo
        yield return null; todosFuerea = true;
    }
    IEnumerator ronda48()
    {
        yield return StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 11)); // Instancia un enemigo
        yield return null; todosFuerea = true;
    }
    IEnumerator ronda49()
    {
        yield return StartCoroutine(Ronda(7, 5)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 9)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 23)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(8, 11)); // Instancia un enemigo
        yield return null; todosFuerea = true;
    }
    IEnumerator ronda50()
    {
        StartCoroutine(Ronda(7, 3)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 4)); // Instancia un enemigo
        StartCoroutine(Ronda(2, 18)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(2, 12)); // Instancia un enemigo
        yield return null; todosFuerea = true;
    }
    IEnumerator ronda51()
    {
        StartCoroutine(Ronda(3, 7)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 3)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(8, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(6, 14)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda52()
    {
        StartCoroutine(Ronda(7, 7)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 4)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 11)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 14)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda53()
    {
        StartCoroutine(Ronda(7, 5)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 9)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 11)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 14)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 18)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda54()
    {
        yield return StartCoroutine(Ronda(6, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 14)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda55()
    {
        StartCoroutine(Ronda(7, 5)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(6, 12)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 14)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda56()
    {
        StartCoroutine(Ronda(7, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 11)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 12)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 15)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda57()
    {
        yield return StartCoroutine(Ronda(7, 8)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 14)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 15)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda58()
    {
        StartCoroutine(Ronda(5, 18)); // Instancia un enemigo
        StartCoroutine(Ronda(20, 5)); // Instancia un enemigo
        StartCoroutine(Ronda(13, 12)); // Instancia un enemigo
        StartCoroutine(Ronda(22, 14)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 15)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda59()
    {
        yield return StartCoroutine(Ronda(32, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(30, 12)); // Instancia un enemigo
        StartCoroutine(Ronda(14, 14)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(12, 15)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda60()
    {
        yield return StartCoroutine(Ronda(2, 19)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda61()
    {
        yield return StartCoroutine(Ronda(7, 7)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 5)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 9)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 8)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda62()
    {
        yield return StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 9)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda63()
    {
        yield return StartCoroutine(Ronda(7, 2)); // Instancia un enemigo 
        yield return StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 4)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 7)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda64()
    {
        StartCoroutine(Ronda(7, 4)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 6)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 8)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda65()
    {
        yield return StartCoroutine(Ronda(30, 1)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(15, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 9)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda66()
    {
        yield return StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(22, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 11)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda67()
    {
        yield return StartCoroutine(Ronda(9, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 8)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 11)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda68()
    {
        StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 11)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda69()
    {
        StartCoroutine(Ronda(7, 5)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 9)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 11)); // Instancia un enemigo
        StartCoroutine(Ronda(20, 0)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 7)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 12)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 13)); // Instancia un enemigo
        yield return null; todosFuerea = true;
    }
    IEnumerator ronda70()
    {
        StartCoroutine(Ronda(7, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 4)); // Instancia un enemigo
        StartCoroutine(Ronda(2, 18)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(2, 12)); // Instancia un enemigo
        StartCoroutine(Ronda(2, 19)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda71()
    {
        StartCoroutine(Ronda(3, 7)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(6, 14)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda72()
    {
        StartCoroutine(Ronda(7, 7)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 4)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 23)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 11)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 14)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda73()
    {
        StartCoroutine(Ronda(7, 5)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 9)); // Instancia un enemigo
        StartCoroutine(Ronda(2, 19)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 11)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 14)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 18)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda74()
    {
        StartCoroutine(Ronda(6, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 14)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda75()
    {
        StartCoroutine(Ronda(7, 5)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(6, 12)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 14)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 19)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda76()
    {
        StartCoroutine(Ronda(7, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 11)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 12)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 15)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda77()
    {
        StartCoroutine(Ronda(7, 8)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 14)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 15)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda78()
    {
        StartCoroutine(Ronda(5, 18)); // Instancia un enemigo
        StartCoroutine(Ronda(20, 5)); // Instancia un enemigo
        StartCoroutine(Ronda(13, 12)); // Instancia un enemigo
        StartCoroutine(Ronda(22, 14)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 15)); // Instancia un enemigo
        StartCoroutine(Ronda(6, 19)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda79()
    {
        StartCoroutine(Ronda(32, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(30, 12)); // Instancia un enemigo
        StartCoroutine(Ronda(14, 14)); // Instancia un enemigo
        StartCoroutine(Ronda(12, 15)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda80()
    {
        StartCoroutine(Ronda(1, 20)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
        yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag(enemyTag).Length == 0);
        if (controlJuego.Medio && todosFuerea && GameObject.FindGameObjectsWithTag(enemyTag).Length == 0)
        {
            stoper.Stop();
            List<BaseDatos.Nivel> n = baseDatos.ObtenerTodosLosNivelesPorUsuarioSigienteNivel();
            if (n[0].nivel < 6)
            {
                foreach (BaseDatos.Nivel niv in n)
                {
                    if (niv.Dificultad == 1)
                    {
                        niv.Desbloqueado = true;
                    }
                }
            }
        }
    }
    IEnumerator ronda81()
    {
        StartCoroutine(Ronda(7, 17)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 5)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 9)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 23)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda82()
    {
        StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 18)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 9)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda83()
    {
        StartCoroutine(Ronda(7, 2)); // Instancia un enemigo 
        StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 23)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 4)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 17)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda84()
    {
        StartCoroutine(Ronda(7, 4)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 6)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 8)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda85()
    {
        StartCoroutine(Ronda(30, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(15, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 9)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda86()
    {
        StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(22, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 11)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda87()
    {
        StartCoroutine(Ronda(4, 18)); // Instancia un enemigo
        StartCoroutine(Ronda(9, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 8)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 11)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda88()
    {
        StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 11)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda89()
    {
        StartCoroutine(Ronda(7, 5)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 9)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 11)); // Instancia un enemigo
        StartCoroutine(Ronda(20, 0)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 7)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 12)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 13)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda90()
    {
        StartCoroutine(Ronda(7, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 4)); // Instancia un enemigo
        StartCoroutine(Ronda(6, 18)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(2, 12)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 19)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 21)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda91()
    {
        StartCoroutine(Ronda(3, 7)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(6, 14)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda92()
    {
        StartCoroutine(Ronda(7, 7)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 4)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 11)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 14)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda93()
    {
        StartCoroutine(Ronda(7, 5)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 9)); // Instancia un enemigo
        StartCoroutine(Ronda(2, 19)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 11)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 14)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 18)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda94()
    {
        StartCoroutine(Ronda(6, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 14)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda95()
    {
        StartCoroutine(Ronda(7, 5)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(6, 12)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 15)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 19)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 21)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda96()
    {
        StartCoroutine(Ronda(7, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 11)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 12)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 15)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda97()
    {
        StartCoroutine(Ronda(7, 8)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 21)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 14)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 16)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda98()
    {
        StartCoroutine(Ronda(5, 18)); // Instancia un enemigo
        StartCoroutine(Ronda(20, 5)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(13, 12)); // Instancia un enemigo
        StartCoroutine(Ronda(22, 14)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 16)); // Instancia un enemigo
        StartCoroutine(Ronda(6, 19)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda99()
    {
        StartCoroutine(Ronda(32, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(30, 12)); // Instancia un enemigo
        StartCoroutine(Ronda(14, 17)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 21)); // Instancia un enemigo
        StartCoroutine(Ronda(12, 15)); // Instancia un enemigo
        StartCoroutine(Ronda(6, 20)); // Instancia un enemigo
        yield return null;
        todosFuerea = true;
    }
    IEnumerator ronda100()
    {
        yield return StartCoroutine(Ronda(1, 22));
        yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag(enemyTag).Length == 0);
        if (controlJuego.Dificil && todosFuerea && GameObject.FindGameObjectsWithTag(enemyTag).Length == 0)
        {
            List<BaseDatos.Nivel> n = baseDatos.ObtenerTodosLosNivelesPorUsuarioSigienteNivel();
            if (n[0].nivel < 6)
            {
                foreach (BaseDatos.Nivel niv in n)
                {
                    if (niv.Dificultad == 1)
                    {
                        niv.Desbloqueado = true;
                        baseDatos.Poner(Dificultad, controlJuego.dinero * controlJuego.vidas, true);
                    }
                }
            }
        }
        controlJuego.final(true);
    }
    IEnumerator Ronda(int cantidadEnemigos, int tipoEnemigo)
    {
        if (spawnPointToSpawn2.Length > 0)
        {
            yield return DosPath(cantidadEnemigos, tipoEnemigo);
        }
        else
        {
            yield return UnPath(cantidadEnemigos, tipoEnemigo);
        }
        // Instanciar enemigos con un retraso entre ellos

    }
    IEnumerator UnPath(int cantidadEnemigos, int tipoEnemigo)
    {
        for (int i = 0; i < cantidadEnemigos; i++)
        {
            InstanciarEnemigo(tipoEnemigo, spawnPointToSpawn1); // Instancia un enemigo del tipo especificado
            yield return new WaitUntil(() => parado);
            yield return new WaitForSeconds(spawnDelay);

        }
    }
    IEnumerator DosPath(int cantidadEnemigos, int tipoEnemigo)
    {
        for (int i = 0; i < cantidadEnemigos; i++)
        {
            if (i % 2 == 0)
            {
                InstanciarEnemigo(tipoEnemigo, spawnPointToSpawn2); // Instancia un enemigo del tipo especificado
                yield return new WaitUntil(() => parado);
                yield return new WaitForSeconds(spawnDelay);
            }
            else
            {
                InstanciarEnemigo(tipoEnemigo, spawnPointToSpawn1); // Instancia un enemigo del tipo especificado
                yield return new WaitUntil(() => parado);
                yield return new WaitForSeconds(spawnDelay);
            }

        }
    }
    public void InstanciarEnemigo(int tipoEnemigo, Transform[] spawnPointToSpawn)
    {
        if (tipoEnemigo >= 0 && tipoEnemigo < prefabToSpawn.Length)
        {
            // Instanciar el prefab en el punto de spawn y asignar waypoints
            GameObject spawnedObject = Instantiate(prefabToSpawn[tipoEnemigo], spawnPointToSpawn[0].position, Quaternion.identity);
            spawnedObject.GetComponent<Movement>().waypoints = spawnPointToSpawn;
        }
        else
        {
            Debug.LogWarning("Índice de tipo de enemigo fuera de rango: " + tipoEnemigo);
        }
    }
}
