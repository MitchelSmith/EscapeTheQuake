using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magnitude : MonoBehaviour {

    /*
     * Displays when the magnitude increases
     */

    public GameObject magnitude5Text;
    public GameObject magnitude7Text;
    public GameObject magnitude8Text;
    public GameObject magnitude9Text;
    public GameObject magnitude10Text;
    public GameObject magnitude11Text;
    public AudioClip earthquake;
    public Text newsText1;
    public Text newsText2;

    private float elapsedSeconds = 0;
    private bool audioOnePlayed = false;
    private bool audioTwoPlayed = false;
    private bool audioThreePlayed = false;
    private bool audioFourPlayed = false;
    private bool audioFivePlayed = false;
    private bool audioSixPlayed = false;

    // Use this for initialization
    void Start ()
    {
        GetComponent<AudioSource>().clip = earthquake;
    }
	
	// Update is called once per frame
	void Update ()
    {
        elapsedSeconds += Time.deltaTime;

        if (elapsedSeconds > 18.5f)
        {
            if(!audioOnePlayed)
            {
                GetComponent<AudioSource>().Play();
                audioOnePlayed = true;
                CameraShake.shakeDuration = 2;
            }
            magnitude5Text.SetActive(true);
            newsText1.text = "-- Earthquake In Downtown -- Magnitude 5 -- Take Cover -- Watch for Debris";
            newsText2.text = "-- Earthquake In Downtown -- Magnitude 5 -- Take Cover -- Watch for Debris";
        }
        if (elapsedSeconds > 20.5f)
            magnitude5Text.SetActive(false);

        if (elapsedSeconds > 33.5f)
        {
            if (!audioTwoPlayed)
            {
                GetComponent<AudioSource>().Play();
                audioTwoPlayed = true;
                CameraShake.shakeDuration = 2;
            }
            magnitude7Text.SetActive(true);
            newsText1.text = "-- Earthquake In Downtown -- Magnitude 7 -- Take Cover -- Watch for Debris";
            newsText2.text = "-- Earthquake In Downtown -- Magnitude 7 -- Take Cover -- Watch for Debris";
        }
        if (elapsedSeconds > 35.5f)
            magnitude7Text.SetActive(false);

        if (elapsedSeconds > 63.5f)
        {
            if (!audioThreePlayed)
            {
                GetComponent<AudioSource>().Play();
                audioThreePlayed = true;
                CameraShake.shakeDuration = 2;
            }
            magnitude8Text.SetActive(true);
            newsText1.text = "-- Earthquake In Downtown -- Magnitude 8 -- Take Cover -- Watch for Debris";
            newsText2.text = "-- Earthquake In Downtown -- Magnitude 8 -- Take Cover -- Watch for Debris";
        }
        if (elapsedSeconds > 65.5f)
            magnitude8Text.SetActive(false);

        if (elapsedSeconds > 93.5f)
        {
            if (!audioFourPlayed)
            {
                GetComponent<AudioSource>().Play();
                audioFourPlayed = true;
                CameraShake.shakeDuration = 2;
            }
            magnitude9Text.SetActive(true);
            newsText1.text = "-- Earthquake In Downtown -- Magnitude 9 -- Take Cover -- Watch for Debris";
            newsText2.text = "-- Earthquake In Downtown -- Magnitude 9 -- Take Cover -- Watch for Debris";
        }
        if (elapsedSeconds > 95.5f)
            magnitude9Text.SetActive(false);

        if (elapsedSeconds > 123.5f)
        {
            if (!audioFivePlayed)
            {
                GetComponent<AudioSource>().Play();
                audioFivePlayed = true;
                CameraShake.shakeDuration = 2;
            }
            magnitude10Text.SetActive(true);
            newsText1.text = "---- SYSTEM MALFUNCTION! ---- SYSTEM MALFUNCTION! ---- SYSTEM MALFUNCTION!";
            newsText2.text = "---- SYSTEM MALFUNCTION! ---- SYSTEM MALFUNCTION! ---- SYSTEM MALFUNCTION!";
        }
        if (elapsedSeconds > 125.5f)
            magnitude10Text.SetActive(false);

        if (elapsedSeconds > 183.5f)
        {
            if (!audioSixPlayed)
            {
                GetComponent<AudioSource>().Play();
                audioSixPlayed = true;
                CameraShake.shakeDuration = 2;
            }
            magnitude11Text.SetActive(true);
            newsText1.text = "---- SYSTEM MALFUNCTION! ---- SYSTEM MALFUNCTION! ---- SYSTEM MALFUNCTION!";
            newsText2.text = "---- SYSTEM MALFUNCTION! ---- SYSTEM MALFUNCTION! ---- SYSTEM MALFUNCTION!";
        }
        if (elapsedSeconds > 185.5f)
            magnitude11Text.SetActive(false);
    }
}
