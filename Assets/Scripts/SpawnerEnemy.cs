using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemigoPrefab;
    public int maxEnemigos = 5;
    public float tiempoEntreSpawn = 3f;

    private float contador = 0f;
    private int enemigosCreados = 0;

    void Update()
    {
        if (enemigosCreados >= maxEnemigos) return;

        contador += Time.deltaTime;

        if (contador >= tiempoEntreSpawn)
        {
            Instantiate(enemigoPrefab, transform.position, Quaternion.identity);

            enemigosCreados++;
            contador = 0f;

            Debug.Log("Spawn: " + enemigosCreados);
        }
    }
}