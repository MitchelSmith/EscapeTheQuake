using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

    /*
     * Destroys coin and plays sound when touched
     */

    public AudioClip coinPickup;

    // Use this for initialization
    void Start ()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = coinPickup;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(coinPickup, new Vector2(transform.position.x, transform.position.y));   //plays audioclip at point of coin
            Destroy(gameObject);    //destroys coin when touched
        }
    }
}