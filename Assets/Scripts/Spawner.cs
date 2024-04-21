using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private int lastPrefabIndex;

    private void Start()
    {
        Invoke(nameof(SpawnTile), 0);
    }

    private void SpawnTile()
    {
        Instantiate(tilePrefabs[RandomPrefabIndex()], transform, true);
        // Instantiate(tilePrefabs[0], transform, true);
        Invoke(nameof(SpawnTile), Random.Range(2, 4));
    }

    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}