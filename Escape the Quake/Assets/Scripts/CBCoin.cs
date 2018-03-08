using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBCoin : MonoBehaviour {

    /*
     * For coins dropped by power up
     */

    public AudioClip coinPickup;

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = coinPickup;

        rb2d.isKinematic = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(coinPickup, new Vector2(transform.position.x, transform.position.y));   //plays audioclip at point of coin
            Destroy(gameObject);    //destroys coin when touched
        }
    }
}
