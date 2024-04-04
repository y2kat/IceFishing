using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPool : MonoBehaviour
{
    public GameObject fishPrefab;
    public int poolSize = 10;
    private List<GameObject> fishPool;
    private Coroutine spawnFishCoroutine;

    public void InitializePool()
    {
        fishPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject fish = Instantiate(fishPrefab);
            fish.SetActive(false);
            fishPool.Add(fish);
        }
    }

    /*void Start()
    {
        //crea el pool de peces
        fishPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject fish = Instantiate(fishPrefab);
            fish.SetActive(false);
            fishPool.Add(fish);
        }
        //comienza a spawnear peces
        //StartCoroutine(SpawnFish());

        spawnFishCoroutine = StartCoroutine(SpawnFish());
    }*/

    IEnumerator SpawnFish()
    {
        while (true)
        {
            //encuentra un pez inactivo en el pool
            GameObject fish = fishPool.Find(f => !f.activeInHierarchy);
            if (fish != null)
            {
                float randomY = Random.Range(-4, 2.5f);
                fish.transform.position = new Vector2(10, randomY);
                fish.SetActive(true);
            }
            //espera un tiempo antes de spawnear el próximo pez
            yield return new WaitForSeconds(Random.Range(2, 4));
        }
    }

    public void ResetPool()
    {
        if (fishPool != null)
        {
            foreach (GameObject fish in fishPool)
            {
                fish.SetActive(false);
            }
        }
        if (spawnFishCoroutine != null)
        {
            StopCoroutine(spawnFishCoroutine);
            spawnFishCoroutine = null;
        }
    }

    public void StartSpawning()
    {
        if (spawnFishCoroutine == null)
        {
            spawnFishCoroutine = StartCoroutine(SpawnFish());
        }
    }
}
