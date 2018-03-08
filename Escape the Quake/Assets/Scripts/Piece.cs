using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour {

    /*
     * Destroys bricks when they touch end trigger
     */

    private bool hitPlayer = false;     //to track if brick has hit player
    private int totalHits;              //total bricks that have hit player

    void Start()
    {
        totalHits = PlayerPrefs.GetInt("Bricks Hit");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EndTrigger"))  //destroys brick when hitting end trigger object
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))  //if brick hits player, adds to total hits
        {
            if(!hitPlayer)
            {
                totalHits++;
                hitPlayer = true;
                PlayerPrefs.SetInt("Bricks Hit", totalHits);
                PlayerPrefs.Save();
            }
        }
    }
}
