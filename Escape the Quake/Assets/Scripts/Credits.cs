using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    /*
     * Exits credits when over or when screen touched
     */

    public float elapsedSeconds;
	
	// Update is called once per frame
	void Update ()
    {
        elapsedSeconds += Time.deltaTime;

        if (elapsedSeconds > 20 || Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(0);
        }
	}
}
