using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour {

    /*
     * Destroys objects when they fall into it
     */

    public static bool gameOver = false;

    private float elapsedSeconds;

	// Use this for initialization
	void Start ()
    {
        elapsedSeconds = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        elapsedSeconds += Time.deltaTime;

        if (elapsedSeconds > 90)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gameOver = true;
            SpawnManager.totalPlatforms = 0;
            SpawnManager.destroyedPlatforms = 0;
        }
    }
}
