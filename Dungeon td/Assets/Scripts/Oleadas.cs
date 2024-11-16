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
    public Transform[] spawnPointToSpawn;
    public ControlJuego controlJuego;
    public string enemyTag = "Enemy 1";
    private float spawnDelay = 1f;
    public BaseDatos baseDatos;
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


            string nombreRonda = $"ronda{controlJuego.rondas}";

            // Obtiene el método usando Reflection
            MethodInfo metodoRonda = GetType().GetMethod(nombreRonda, BindingFlags.NonPublic | BindingFlags.Instance);

            // Verifica si el método existe y lo ejecuta como Coroutine
            if (metodoRonda != null)
            {
                StartCoroutine((IEnumerator)metodoRonda.Invoke(this, null));
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
        StartCoroutine(Ronda(5, 0)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 1)); // Instancia un enemigo

    }
    IEnumerator ronda5()
    {
        StartCoroutine(Ronda(7, 0)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(7, 1)); // Instancia un enemigo

    }
    IEnumerator ronda6()
    {
        StartCoroutine(Ronda(10, 0)); // Instancia un enemigo
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
        StartCoroutine(Ronda(3, 0)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 1)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 2)); // Instancia un enemigo

    }
    IEnumerator ronda9()
    {
        StartCoroutine(Ronda(5, 0)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 1)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 2)); // Instancia un enemigo
    }
    IEnumerator ronda10()
    {
        StartCoroutine(Ronda(7, 0)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 1)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 2)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 3)); // Instancia un enemigo

    }
    IEnumerator ronda11()
    {
        StartCoroutine(Ronda(4, 4)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 1)); // Instancia un enemigo

    }
    IEnumerator ronda12()
    {

        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(7, 5)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(6, 2)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 4)); // Instancia un enemigo

    }
    IEnumerator ronda13()
    {
        StartCoroutine(Ronda(7, 2)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 4)); // Instancia un enemigo


    }
    IEnumerator ronda14()
    {
        StartCoroutine(Ronda(4, 5)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(6, 1)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 3)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda15()
    {
        StartCoroutine(Ronda(5, 5)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(7, 0)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda16()
    {
        StartCoroutine(Ronda(7, 5)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 6)); // Instancia un enemigo
        StartCoroutine(Ronda(6, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 4)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda17()
    {
        StartCoroutine(Ronda(10, 5)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(7, 6)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 7)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda18()
    {
        StartCoroutine(Ronda(4, 6)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 7)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 8)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda19()
    {
        StartCoroutine(Ronda(10, 6)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 7)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(7, 8)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda20()
    {
        StartCoroutine(Ronda(7, 4)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 5)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 9)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 8)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda21()
    {
        yield return StartCoroutine(Ronda(7, 7)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 5)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 9)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 8)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda22()
    {
        StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 9)); // Instancia un enemigo

        yield return null;
    }
    IEnumerator ronda23()
    {
        StartCoroutine(Ronda(7, 2)); // Instancia un enemigo 
        yield return StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 4)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 7)); // Instancia un enemigo

        yield return null;
    }
    IEnumerator ronda24()
    {
        StartCoroutine(Ronda(7, 4)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 6)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 8)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda25()
    {
        StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 9)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda26()
    {
        yield return StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 11)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda27()
    {
        StartCoroutine(Ronda(9, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 8)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 11)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda28()
    {
        StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 11)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda29()
    {
        StartCoroutine(Ronda(7, 5)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 9)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(8, 11)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda30()
    {
        yield return StartCoroutine(Ronda(7, 3)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 4)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(2, 12)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda31()
    {
        yield return StartCoroutine(Ronda(3, 7)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 3)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(8, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(6, 12)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda32()
    {
        yield return StartCoroutine(Ronda(7, 7)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 4)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 11)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(8, 12)); // Instancia un enemigo

        yield return null;
    }
    IEnumerator ronda33()
    {
        yield return StartCoroutine(Ronda(7, 5)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 9)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 11)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 12)); // Instancia un enemigo

        yield return null;
    }
    IEnumerator ronda34()
    {
        yield return StartCoroutine(Ronda(6, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 13)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda35()
    {
        yield return StartCoroutine(Ronda(7, 5)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(8, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(6, 12)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 13)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda36()
    {
        yield return StartCoroutine(Ronda(7, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 11)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 12)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 13)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda37()
    {
        yield return StartCoroutine(Ronda(7, 5)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 9)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(8, 13)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda38()
    {
        yield return StartCoroutine(Ronda(20, 5)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(13, 12)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(22, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 11)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda39()
    {
        yield return StartCoroutine(Ronda(32, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(30, 12)); // Instancia un enemigo
        StartCoroutine(Ronda(14, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(12, 3)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda40()
    {

        yield return StartCoroutine(Ronda(1, 18)); // Instancia un enemigo
        yield return null;
        if (controlJuego.Facil)
        {
            stoper.Stop();
            List<BaseDatos.Nivel> n = baseDatos.ObtenerTodosLosNivelesPorUsuarioNivel();
            foreach (BaseDatos.Nivel niv in n)
            {
                if (niv.Dificultad >= 2)
                {
                    niv.Desbloqueado = true;
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
    }
    IEnumerator ronda42()
    {
        StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 9)); // Instancia un enemigo

        yield return null;
    }
    IEnumerator ronda43()
    {
        StartCoroutine(Ronda(7, 2)); // Instancia un enemigo 
        StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 4)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 7)); // Instancia un enemigo

        yield return null;
    }
    IEnumerator ronda44()
    {
        StartCoroutine(Ronda(7, 4)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 6)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 8)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda45()
    {
        yield return StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 9)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda46()
    {
        StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 11)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda47()
    {
        StartCoroutine(Ronda(9, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 8)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 11)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda48()
    {
        yield return StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 11)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda49()
    {
        yield return StartCoroutine(Ronda(7, 5)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 9)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 23)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(8, 11)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda50()
    {
        StartCoroutine(Ronda(7, 3)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 4)); // Instancia un enemigo
        StartCoroutine(Ronda(2, 18)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(2, 12)); // Instancia un enemigo
        yield return null;


        yield return null;
    }
    IEnumerator ronda51()
    {
        StartCoroutine(Ronda(3, 7)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 3)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(8, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(6, 14)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda52()
    {
        StartCoroutine(Ronda(7, 7)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 4)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 11)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 14)); // Instancia un enemigo

        yield return null;
    }
    IEnumerator ronda53()
    {
        StartCoroutine(Ronda(7, 5)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 9)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 11)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 14)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 18)); // Instancia un enemigo

        yield return null;
    }
    IEnumerator ronda54()
    {
        yield return StartCoroutine(Ronda(6, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 14)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda55()
    {
        StartCoroutine(Ronda(7, 5)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(6, 12)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 14)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda56()
    {
        StartCoroutine(Ronda(7, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 11)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 12)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 15)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda57()
    {
        yield return StartCoroutine(Ronda(7, 8)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 14)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 15)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda58()
    {
        StartCoroutine(Ronda(5, 18)); // Instancia un enemigo
        StartCoroutine(Ronda(20, 5)); // Instancia un enemigo
        StartCoroutine(Ronda(13, 12)); // Instancia un enemigo
        StartCoroutine(Ronda(22, 14)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(3, 15)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda59()
    {
        yield return StartCoroutine(Ronda(32, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(30, 12)); // Instancia un enemigo
        StartCoroutine(Ronda(14, 14)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(12, 15)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda60()
    {
        yield return StartCoroutine(Ronda(2, 19)); // Instancia un enemigo

        yield return null;
    }
    IEnumerator ronda61()
    {
        yield return StartCoroutine(Ronda(7, 7)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 5)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 9)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 8)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda62()
    {
        yield return StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 9)); // Instancia un enemigo

        yield return null;
    }
    IEnumerator ronda63()
    {
        yield return StartCoroutine(Ronda(7, 2)); // Instancia un enemigo 
        yield return StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 4)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 7)); // Instancia un enemigo

        yield return null;
    }
    IEnumerator ronda64()
    {
        StartCoroutine(Ronda(7, 4)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 6)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 8)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda65()
    {
        yield return StartCoroutine(Ronda(30, 1)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(15, 10)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(4, 9)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda66()
    {
        yield return StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(22, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 11)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda67()
    {
        yield return StartCoroutine(Ronda(9, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 8)); // Instancia un enemigo
        yield return StartCoroutine(Ronda(5, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 11)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda68()
    {
        StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 11)); // Instancia un enemigo
        yield return null;
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
        yield return null;
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
    }
    IEnumerator ronda71()
    {
        StartCoroutine(Ronda(3, 7)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(6, 14)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda72()
    {
        StartCoroutine(Ronda(7, 7)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 4)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 23)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 11)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 14)); // Instancia un enemigo

        yield return null;
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
    }
    IEnumerator ronda74()
    {
        StartCoroutine(Ronda(6, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 14)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda75()
    {
        StartCoroutine(Ronda(7, 5)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(6, 12)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 14)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 19)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda76()
    {
        StartCoroutine(Ronda(7, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 11)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 12)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 15)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda77()
    {
        StartCoroutine(Ronda(7, 8)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 14)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 15)); // Instancia un enemigo
        yield return null;
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
    }
    IEnumerator ronda79()
    {
        StartCoroutine(Ronda(32, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(30, 12)); // Instancia un enemigo
        StartCoroutine(Ronda(14, 14)); // Instancia un enemigo
        StartCoroutine(Ronda(12, 15)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda80()
    {
        StartCoroutine(Ronda(1, 20)); // Instancia un enemigo
        yield return null;
        if (controlJuego.Medio)
        {
            stoper.Stop();
            List<BaseDatos.Nivel> n = baseDatos.ObtenerTodosLosNivelesPorUsuarioSigienteNivel();
            foreach (BaseDatos.Nivel niv in n)
            {
                if (niv.Dificultad == 1)
                {
                    niv.Desbloqueado = true;
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
    }
    IEnumerator ronda82()
    {
        StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 18)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 9)); // Instancia un enemigo

        yield return null;
    }
    IEnumerator ronda83()
    {
        StartCoroutine(Ronda(7, 2)); // Instancia un enemigo 
        StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 23)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 4)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 17)); // Instancia un enemigo

        yield return null;
    }
    IEnumerator ronda84()
    {
        StartCoroutine(Ronda(7, 4)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 6)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 8)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 10)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda85()
    {
        StartCoroutine(Ronda(30, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(15, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 9)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda86()
    {
        StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(22, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 11)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda87()
    {
        StartCoroutine(Ronda(4, 18)); // Instancia un enemigo
        StartCoroutine(Ronda(9, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 8)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 11)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda88()
    {
        StartCoroutine(Ronda(7, 1)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 11)); // Instancia un enemigo
        yield return null;
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
    }
    IEnumerator ronda91()
    {
        StartCoroutine(Ronda(3, 7)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 3)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(6, 14)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda92()
    {
        StartCoroutine(Ronda(7, 7)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 4)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 11)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 14)); // Instancia un enemigo

        yield return null;
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
    }
    IEnumerator ronda94()
    {
        StartCoroutine(Ronda(6, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 14)); // Instancia un enemigo
        yield return null;
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
    }
    IEnumerator ronda96()
    {
        StartCoroutine(Ronda(7, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 11)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 12)); // Instancia un enemigo
        StartCoroutine(Ronda(5, 15)); // Instancia un enemigo
        yield return null;
    }
    IEnumerator ronda97()
    {
        StartCoroutine(Ronda(7, 8)); // Instancia un enemigo
        StartCoroutine(Ronda(10, 10)); // Instancia un enemigo
        StartCoroutine(Ronda(4, 21)); // Instancia un enemigo
        StartCoroutine(Ronda(3, 14)); // Instancia un enemigo
        StartCoroutine(Ronda(8, 16)); // Instancia un enemigo
        yield return null;
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
    }
    IEnumerator ronda100()
    {
        yield return StartCoroutine(Ronda(1, 22));
        if (controlJuego.Dificil)
        {
            List<BaseDatos.Nivel> n = baseDatos.ObtenerTodosLosNivelesPorUsuarioSigienteNivel();
            foreach (BaseDatos.Nivel niv in n)
            {
                if (niv.Dificultad == 1)
                {
                    niv.Desbloqueado = true;
                }
            }
        }
        controlJuego.final(true);
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
