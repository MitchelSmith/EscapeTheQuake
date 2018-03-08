using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBeeps : MonoBehaviour {

    /*
     * Plays starting beeps before game starts
     */

    public AudioClip lowBeep;
    public AudioClip highBeep;
    public float elapsedSeconds;

    private bool firstBeep = false;
    private bool secondBeep = false;
    private bool thirdBeep = false;
	
	// Update is called once per frame
	void Update ()
    {
        elapsedSeconds += Time.deltaTime;

        if (!firstBeep)
        {
            GetComponent<AudioSource>().clip = lowBeep;
            GetComponent<AudioSource>().Play();
            firstBeep = true;
        }
        if (!secondBeep && elapsedSeconds > 1)
        {
            GetComponent<AudioSource>().Play();
            secondBeep = true;
        }
        if (!thirdBeep && elapsedSeconds > 2)
        {
            GetComponent<AudioSource>().clip = highBeep;
            GetComponent<AudioSource>().Play();
            thirdBeep = true;
        }
	}
}
