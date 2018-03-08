using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour {

    public bool playingTutorial;
    public GameObject tiltPhone;
    public GameObject tapToJump;
    public GameObject collectCoins;
    public GameObject piecesFalling;
    public GameObject platformsFall;
    public GameObject readyToPlay;
    public GameObject brick;
    public GameObject bigPiece;
    public float jumpForce = 600f;
    public Transform spawnPiece;
    public Transform spawnBigPiece;

    private float elapsedSeconds;
    private int playedTutorial;
    private bool trigger1 = false;
    private bool trigger2 = false;
    private bool trigger3 = false;
    private bool trigger4 = false;
    private bool trigger5 = false;
    private bool jumpDone = false;
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();

        playingTutorial = true;

        playedTutorial = PlayerPrefs.GetInt("Played Tutorial");
    }
	
	// Update is called once per frame
	void Update ()
    {
        elapsedSeconds += Time.deltaTime;

        if (elapsedSeconds > 3.3)
            SimplePlatformController.elapsedSeconds = 3.4f;

        if (Input.GetMouseButtonDown(0) && trigger1 && !trigger5)
        {
            tapToJump.SetActive(false);
            tiltPhone.SetActive(false);
            rb2d.isKinematic = false;
            if(!jumpDone)
            {
                rb2d.AddForce(new Vector2(0f, jumpForce));
                jumpDone = true;
            }
        }

        if (Input.GetMouseButtonDown(0) && trigger2 && !trigger5)
        {
            collectCoins.SetActive(false);
            rb2d.isKinematic = false;
        }

        if (Input.GetMouseButtonDown(0) && trigger3 && !trigger5)
        {
            piecesFalling.SetActive(false);
            rb2d.isKinematic = false;
        }

        if (Input.GetMouseButtonDown(0) && trigger4 && !trigger5)
        {
            platformsFall.SetActive(false);
            rb2d.isKinematic = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TapToJump"))
        {
            if (trigger1)
            {
                return;
            }
            rb2d.isKinematic = true;
            tapToJump.SetActive(true);
            trigger1 = true;
            rb2d.velocity = Vector2.zero;
        }

        if (collision.gameObject.CompareTag("CollectCoins"))
        {
            if (trigger2)
            {
                return;
            }
            rb2d.isKinematic = true;
            collectCoins.SetActive(true);
            trigger2 = true;
            rb2d.velocity = Vector2.zero;
        }

        if (collision.gameObject.CompareTag("Pieces"))
        {
            if (trigger3)
            {
                return;
            }
            rb2d.isKinematic = true;
            piecesFalling.SetActive(true);
            trigger3 = true;
            rb2d.velocity = Vector2.zero;
            Instantiate(brick, spawnPiece.position, Quaternion.identity);
            Instantiate(bigPiece, spawnBigPiece.position, Quaternion.identity);
        }

        if (collision.gameObject.CompareTag("PlatformsFall"))
        {
            if (trigger4)
            {
                return;
            }
            rb2d.isKinematic = true;
            platformsFall.SetActive(true);
            trigger4 = true;
            rb2d.velocity = Vector2.zero;
        }

        if (collision.gameObject.CompareTag("ReadyToPlay"))
        {
            if (trigger5)
            {
                return;
            }
            playedTutorial++;
            PlayerPrefs.SetInt("Played Tutorial", playedTutorial);
            PlayerPrefs.Save();
            rb2d.isKinematic = true;
            readyToPlay.SetActive(true);
            trigger5 = true;
            rb2d.velocity = Vector2.zero;
        }
    }
}
