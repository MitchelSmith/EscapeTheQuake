using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimplePlatformController : MonoBehaviour
{
    /*
     * Main Game and Character Controller
     */

    [HideInInspector] public static bool facingRight = true;   //shows direction character is facing for flipping image

    public float moveForce = 365f;      //force used for x movement
    public float maxSpeed = 7f;       //max force allowed for movement
    public float jumpForce = 620f;      //force used for y movement
    public float jumpSeconds = 0;       //ensures only double jumping
    public static float elapsedSeconds = 0;    //total seconds since game start
    public float secondsAfterHit = 0;   //seconds after hit by big piece
    public static float distance;       //distance traveled during playthrough
    public static float speed = 0;
    public static bool gameOver = false;
    public Transform groundCheck;
    public Text scoreText;
    public Text highScoreText;
    public Text coinsText;
    public Text totalCoinsText;
    public Text endingCoinsText;
    public Text endingScoreText;
    public Text distanceText;
    public AudioClip jumpSound;
    public GameObject readyText;
    public GameObject steadyText;
    public GameObject runText;
    public GameObject gameOverPage;

    private float score = 0;
    private float runScore;
    private float highScore;
    private int coins = 0;
    private int totalCoins;
    private int currentCoins;
    private int runCoins;
    private int bestRunCoins;
    private float pastDistance;
    private float totalDistance;
    private float runDistance;
    private float bestRunDistance;
    private bool grounded = false;      //tracks if touching ground
    private bool isJumping = false;     //variable used to allow double jumping
    private bool isJumping2 = false;    //variable used to allow double jumping
    private bool gameStart = false;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = jumpSound;

        highScore = PlayerPrefs.GetFloat("High Score");
        highScoreText.text = "High Score: " + highScore.ToString("F0");
        runScore = PlayerPrefs.GetFloat("Run Score");
        runScore = 0;

        totalCoins = PlayerPrefs.GetInt("Total Coins");
        currentCoins = PlayerPrefs.GetInt("Current Coins");
        runCoins = PlayerPrefs.GetInt("Run Coins");
        bestRunCoins = PlayerPrefs.GetInt("Best Run Coins");
        runCoins = 0;
        totalCoinsText.text = "Total Coins: " + totalCoins.ToString();

        coinsText.text = "Coins: " + 0.ToString();

        pastDistance = PlayerPrefs.GetFloat("Total Distance");
        runDistance = PlayerPrefs.GetFloat("Run Distance");
        bestRunDistance = PlayerPrefs.GetFloat("Best Run Distance");

        elapsedSeconds = 0;

        gameOverPage.SetActive(false);
        gameOver = false;
        EndTrigger.gameOver = false;
        facingRight = true;

        rb2d.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        jumpSeconds += Time.deltaTime;
        elapsedSeconds += Time.deltaTime;
        secondsAfterHit += Time.deltaTime;

        gameOver = EndTrigger.gameOver;

        if (elapsedSeconds > 3 && !gameStart)     //allows ready set go to run before character touches platform
        {
            rb2d.isKinematic = false;
            gameStart = true;
        }

        if (elapsedSeconds < 4)     //stops ready set go from running after it finishes
            ReadySetGo();

        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  //when touching ground, changes boolean to true

        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1)
        {
            if (isJumping == false)
            {
                GetComponent<AudioSource>().Play();
                jumpSeconds = 0;
                isJumping = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);  //changes y velocity to zero for jump
                rb2d.AddForce(new Vector2(0f, jumpForce));      //applies jump force to character
            }
            else if (isJumping2 == false)
            {
                GetComponent<AudioSource>().Play();
                isJumping2 = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
                rb2d.AddForce(new Vector2(0f, jumpForce));
            }
        }

        if (secondsAfterHit > 2)    //reverts jump force back after getting hit by big piece
            RevertJumpForce();

        PlayerScore();  //updates player score and high score
        distanceText.text = "DISTANCE " + distance.ToString("F1") + " feet";
        PlayerPrefs.SetFloat("Run Distance", distance);

        if (gameOver)
        {
            totalDistance = (pastDistance + distance);
            if (runDistance > bestRunDistance)
            {
                bestRunDistance = runDistance;
                PlayerPrefs.SetFloat("Best Run Distance", bestRunDistance);
            }
            PlayerPrefs.SetFloat("Total Distance", totalDistance);
            PlayerPrefs.Save();
            gameOverPage.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void FixedUpdate()
    {
        float h = Input.acceleration.x;   //uses accelerometer to get direction of movement
        speed = h * rb2d.velocity.x;

        if (h > 1)
            h = 1;
        if (h < -1)
            h = -1;

        if (speed < maxSpeed)     //makes the player move in certain direction
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)      //clamps velocity to maxSpeed
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);  //makes velocity direction of movement (using sign -1 of 1 for direction) * maxSpeed

        if (h > 0 && !facingRight)      //flips player image when going certain direction
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if(grounded && jumpSeconds > 0.25)
        {
            isJumping = false;
            isJumping2 = false;
        }
    }

    void Flip()     //flips character sprite when facing certain direction
    {
        if (elapsedSeconds < 3)
            return;
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void PlayerScore()
    {
        if(gameOver)
        {
            return;
        }

        distance = gameObject.transform.position.x * 1.8f;

        scoreText.text = "Score: " + score.ToString("F0");
        endingScoreText.text = "--- SCORE --- " + score.ToString("F0");

        if (elapsedSeconds < 3.5)
        {
            return;
        }
        else
        {
            score = (elapsedSeconds - 3.5f) * 3f;
        }

        runScore = score;
        PlayerPrefs.SetFloat("Run Score", runScore);

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("High Score", highScore);
            PlayerPrefs.Save();
        }
        highScoreText.text = "High Score: " + highScore.ToString("F0");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coins++;
            totalCoins++;
            currentCoins++;
            runCoins++;

            coinsText.text = "Coins: " + coins.ToString();
            totalCoinsText.text = "Total Coins: " + totalCoins.ToString();
            endingCoinsText.text = "COINS " + coins.ToString();

            if (runCoins > bestRunCoins)
            {
                PlayerPrefs.SetInt("Best Run Coins", runCoins);
            }

            PlayerPrefs.SetInt("Total Coins", totalCoins);
            PlayerPrefs.SetInt("Current Coins", currentCoins);
            PlayerPrefs.SetInt("Run Coins", runCoins);
            PlayerPrefs.Save();
        }
    }

    void ReadySetGo()    //displays ready steady run before game starts
    {
        readyText.SetActive(true);
        if (elapsedSeconds > 1f)
        {
            readyText.SetActive(false);
            steadyText.SetActive(true);
        }
        if (elapsedSeconds > 2f)
        {
            steadyText.SetActive(false);
            runText.SetActive(true);
        }
        if (elapsedSeconds > 3f)
        {
            runText.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piece"))      //if hit by object, cuts jump force in half
        {
            secondsAfterHit = 0;
            jumpForce = 350;
        }
    }

    void RevertJumpForce()  //puts jump force back to original value
    {
        jumpForce = 620;
    }
}
