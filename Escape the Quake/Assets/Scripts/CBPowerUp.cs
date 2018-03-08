using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBPowerUp : MonoBehaviour {

    /*
     * Decides if it rains bricks or coins onto the player when hit
     */

    public AudioClip triggerBricks;
    public AudioClip triggerCoins;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int coinFlip = Random.Range(0, 2);
            if (coinFlip > 0)
            {
                GetComponent<AudioSource>().clip = triggerCoins;
                AudioSource.PlayClipAtPoint(triggerCoins, new Vector2(transform.position.x, transform.position.y));
                SpawnCoin();
            }
            else
            {
                GetComponent<AudioSource>().clip = triggerBricks;
                AudioSource.PlayClipAtPoint(triggerBricks, new Vector2(transform.position.x, transform.position.y));
                SpawnBrick();
            }

            Destroy(gameObject);    //destroys when touched
        }
    }

    void SpawnCoin()
    {
        CoinsOrBricksFalling.coinsFalling = true;
        CoinsOrBricksFalling.elapsedSeconds = 0;
    }

    void SpawnBrick()
    {
        CoinsOrBricksFalling.bricksFalling = true;
        CoinsOrBricksFalling.elapsedSeconds = 0;
    }
}
