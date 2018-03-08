using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoFlip : MonoBehaviour {

    /*
     * Keeps clouds from flipping with character image
     */

    private SpriteRenderer mySpriteRenderer;

	// Use this for initialization
	void Awake ()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (SimplePlatformController.facingRight == false)
        {
            mySpriteRenderer.flipX = true;
        }
        else
        {
            mySpriteRenderer.flipX = false;
        }
    }
}
