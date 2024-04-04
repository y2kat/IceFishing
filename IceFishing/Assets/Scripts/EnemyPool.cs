using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int poolSize = 10;
    private List<GameObject> enemyPool;
    private Coroutine spawnEnemiesCoroutine;

    public void InitializePool()
    {
        enemyPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }
    }

    /*void Start()
    {
        //crea el pool de enemigos
        enemyPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }
        //comienza a spawnear enemigos
        //StartCoroutine(SpawnEnemies());
        spawnEnemiesCoroutine = StartCoroutine(SpawnEnemies());
    }*/

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            //encuentra un enemigo inactivo en el pool
            GameObject enemy = enemyPool.Find(e => !e.activeInHierarchy);
            if (enemy != null)
            {
                float randomY = Random.Range(-4, 2.5f);
                enemy.transform.position = new Vector2(-10, randomY);

                enemy.SetActive(true);
            }
            //espera un tiempo antes de spawnear el próximo enemigo
            yield return new WaitForSeconds(Random.Range(2, 4));
        }
    }

    public void ResetPool()
    {
        if (enemyPool != null)
        {
            foreach (GameObject enemy in enemyPool)
            {
                enemy.SetActive(false);
            }
        }
        if (spawnEnemiesCoroutine != null)
        {
            StopCoroutine(spawnEnemiesCoroutine);
            spawnEnemiesCoroutine = null;
        }
    }

    public void StartSpawning()
    {
        if (spawnEnemiesCoroutine == null)
        {
            spawnEnemiesCoroutine = StartCoroutine(SpawnEnemies());
        }
    }
}
