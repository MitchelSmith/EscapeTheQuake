using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUps : MonoBehaviour {

    /*
     * Randomly spawns power ups on platforms
     */

    public Transform[] powerUpSpawn;
    public GameObject rain;
    public GameObject silencer;
    public GameObject magnet;
    public GameObject safetyFirst;
    public GameObject tripleJump;

    private int randomNumber;
    private bool powerUpSpawned = false;
    private GameObject randomPowerUp;

    // Use this for initialization
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Spawn()
    {
        powerUpSpawned = false;

        for (int i = 0; i < powerUpSpawn.Length; i++)
        {
            if (powerUpSpawned) //ensures only one power up is spawned per platform
            {
                return;
            }

            randomNumber = Random.Range(0, 3);  //chooses random power up to place
            if (randomNumber == 0)
                randomPowerUp = rain;
            if (randomNumber == 1)
                randomPowerUp = silencer;
            if (randomNumber == 2)
                randomPowerUp = magnet;

            int oneInTen = Random.Range(0, 10);  //random 1 in 10 chance to spawn a power up
            if (oneInTen < 1)
            {
                Instantiate(randomPowerUp, powerUpSpawn[i].position, Quaternion.identity);
                powerUpSpawned = true;
            }
        }
    }
}
