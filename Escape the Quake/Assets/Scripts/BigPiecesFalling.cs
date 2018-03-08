using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPiecesFalling : MonoBehaviour {

    /*
     * Randomly drops big piece
     */

    public Transform[] bigPiecesSpawn;
    public GameObject buildingChunk;
    public GameObject lookOutText;
    public float spawnTime;

    private float elapsedSeconds;
    private float secondsSinceLastSpawn;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        spawnTime = Random.Range(15, 30);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedSeconds += Time.deltaTime;
        secondsSinceLastSpawn += Time.deltaTime;

        if (elapsedSeconds > 30 && secondsSinceLastSpawn > spawnTime)      //calls function every 15 to 30 seconds
        {
            secondsSinceLastSpawn = 0;
            lookOutText.SetActive(true);
            SpawnBigPiece();
            spawnTime = Random.Range(15, 30);
        }
        if (secondsSinceLastSpawn > 1.25)
        {
            lookOutText.SetActive(false);
        }
    }

    void SpawnBigPiece()   //spawns big piece of building at 1 of 2 random positions
    {
        int i = Random.Range(0, 2);
        Instantiate(buildingChunk, bigPiecesSpawn[i].position, Quaternion.identity);
    }
}
