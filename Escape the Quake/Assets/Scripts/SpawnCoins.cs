using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour {

    /*
     * Spawns coins on platform
     */
    
    public Transform[] coinSpawn;
    public GameObject coin;

	// Use this for initialization
	void Start ()
    {
        Spawn();
	}
	
	void Spawn ()
    {
		for(int i = 0; i < coinSpawn.Length; i++)
        {
            int coinFlip = Random.Range(0, 2);
            if (coinFlip > 0)
            Instantiate(coin, coinSpawn[i].position, Quaternion.identity);
        }
	}
}
