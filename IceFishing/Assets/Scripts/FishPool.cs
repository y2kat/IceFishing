using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPool : MonoBehaviour
{
    public GameObject fishPrefab;
    public int poolSize = 10;
    private List<GameObject> fishPool;

    void Start()
    {
        // Crea el pool de peces
        fishPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject fish = Instantiate(fishPrefab);
            fish.SetActive(false);
            fishPool.Add(fish);
        }
        StartCoroutine(SpawnFish());
    }

    IEnumerator SpawnFish()
    {
        while (true)
        {
            GameObject fish = fishPool.Find(f => !f.activeInHierarchy);
            if (fish != null)
            {
                float randomY = Random.Range(-4, 2.5f);
                fish.transform.position = new Vector2(10, randomY);

                fish.SetActive(true);
            }
            yield return new WaitForSeconds(Random.Range(2, 4));
        }
    }
}
