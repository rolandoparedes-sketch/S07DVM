using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemigoPrefab;


    public Transform[] spawnPoints;
    public float tiempoEntreSpawn = 3f;
    private float contador = 0f;

    public int maxEnemigos = 5;

    private List<GameObject> enemigosActivos = new List<GameObject>();

    void Update()
    {
       
        enemigosActivos.RemoveAll(e => e == null);

        contador += Time.deltaTime;

        if (contador >= tiempoEntreSpawn && enemigosActivos.Count < maxEnemigos)
        {
            Spawn();
            contador = 0f;
        }
    }

    void Spawn()
    {
        if (spawnPoints.Length == 0) return;

        
        foreach (Transform punto in spawnPoints)
        {
            if (enemigosActivos.Count >= maxEnemigos) break;

            GameObject enemigo = Instantiate(enemigoPrefab, punto.position, punto.rotation);
            enemigosActivos.Add(enemigo);
        }
    }
}