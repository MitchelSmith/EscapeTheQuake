using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour {

    /*
     * Makes platforms fall after player jumps on them
     */

    public float fallDelay;
    public float totalSeconds = SimplePlatformController.elapsedSeconds;
    public float elapsedSeconds;
    public BuildingCollapse other;

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();

        transform.DetachChildren();
	}

    void Update()
    {
        elapsedSeconds += Time.deltaTime;
        totalSeconds = SimplePlatformController.elapsedSeconds;

        if (totalSeconds < 19)  //As time goes on platforms fall faster
            fallDelay = 2f;
        if (totalSeconds > 19)
            fallDelay = 1.5f;
        if (totalSeconds > 34)
            fallDelay = 1f;
        if (totalSeconds > 64)
            fallDelay = 0.75f;
        if (totalSeconds > 94)
            fallDelay = 0.5f;
        if (totalSeconds > 124)
            fallDelay = 0.25f;

        if(elapsedSeconds > 90)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))      //invokes fall function after fallDelay seconds
        {
            Invoke("Fall", fallDelay);
        }

        if (collision.gameObject.CompareTag("Piece"))      //invokes fall function after fallDelay seconds
        {
            Invoke("Fall", 0f);
        }

        if (collision.gameObject.CompareTag("EndTrigger"))
        {
            Destroy(gameObject);
            SpawnManager.destroyedPlatforms++;
            SpawnManager.totalPlatforms--;
        }
    }

    void Fall()
    {
        other.Collapse();
        transform.DetachChildren();
        rb2d.isKinematic = false;   //lets platforms fall
    }
}
