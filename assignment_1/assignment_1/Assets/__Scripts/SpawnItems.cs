using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
	public GameObject[] items;
	public int numberOfItemsToSpawn;
	public float maxRange = 10f;
	public float minRange = -10f;

	private int itemIndex;

    void Start()
    {
        Spawn();
		
    }

	public void Spawn() {
        // Loop through desired number of items to spawn
        for (int i = 0; i < numberOfItemsToSpawn; i++ ) {
            // Iterate through the different objects
			itemIndex = (i + 1) % items.Length;
            // Create a vector with random x and z coordinates
			Vector3 spawnPos = new Vector3(Random.Range(minRange, maxRange), 0.5f, Random.Range(minRange, maxRange));
            // Instantiate the pickup at the position specified
            Instantiate(items[itemIndex], spawnPos, Quaternion.identity);
		}
	}

}
