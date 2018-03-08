using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPiece : MonoBehaviour
{
    /*
     * Plays disoriented sound when hit by big piece
     */

    private bool hitPlayer = false;     //to track if big piece has hit player
    private int totalHits;              //total big pieces that have hit player

    void Start()
    {
        totalHits = PlayerPrefs.GetInt("Big Pieces Hit");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EndTrigger"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))  //if big piece hits player, adds to total hits
        {
            if (!hitPlayer)
            {
                totalHits++;
                hitPlayer = true;
                PlayerPrefs.SetInt("Big Pieces Hit", totalHits);
                PlayerPrefs.Save();
            }
        }
    }
}
