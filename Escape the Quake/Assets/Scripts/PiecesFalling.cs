using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesFalling : MonoBehaviour {

    /*
     * Makes bricks fall randomly during gameplay
     */

    public Transform[] piecesSpawn;
    public GameObject brick;

    private float elapsedSeconds;
    private float totalSeconds;
    private Rigidbody2D rb2d;
	
	// Update is called once per frame
	void Update ()
    {
        elapsedSeconds += Time.deltaTime;
        totalSeconds += Time.deltaTime;
		if(totalSeconds > 3.5 && elapsedSeconds > 2)      //calls function every two seconds
        {
            elapsedSeconds = 0;
            SpawnPiece();
        }
	}

    void SpawnPiece()   //spawns piece of building at 1 of 4 random positions
    {
        int i = Random.Range(0, 4);
        Instantiate(brick, piecesSpawn[i].position, Quaternion.identity);
    }
}
