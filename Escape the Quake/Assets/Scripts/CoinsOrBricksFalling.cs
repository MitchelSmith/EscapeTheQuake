using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsOrBricksFalling : MonoBehaviour {

    /*
     * 50/50 chance of having it either rain bricks or rain coins
     */

    public Transform[] piecesSpawn;
    public GameObject brick;
    public GameObject coin;
    public static bool coinsFalling = false;
    public static bool bricksFalling = false;
    public static float elapsedSeconds;

    private float spawningElapsedSeconds;

    void Start()
    {
        coinsFalling = false;
        bricksFalling = false;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedSeconds += Time.deltaTime;
        spawningElapsedSeconds += Time.deltaTime;

        if (coinsFalling)
        {
            if (elapsedSeconds < 4.5)
            {
                if (spawningElapsedSeconds > 0.05)
                {
                    spawningElapsedSeconds = 0;
                    int i = Random.Range(0, 11);
                    Instantiate(coin, piecesSpawn[i].position, Quaternion.identity);
                }
            }
        }

        if (bricksFalling)
        {
            if (elapsedSeconds < 5)
            {
                if (spawningElapsedSeconds > 0.1)
                {
                    spawningElapsedSeconds = 0;
                    int i = Random.Range(0, 11);
                    Instantiate(brick, piecesSpawn[i].position, Quaternion.identity);
                }
            }
        }

        if (elapsedSeconds > 5)
        {
            coinsFalling = false;
            bricksFalling = false;
        }
    }
}
