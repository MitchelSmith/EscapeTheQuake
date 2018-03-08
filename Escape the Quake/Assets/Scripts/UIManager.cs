using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    /*
     * Controls many buttons and pop ups
     */

    public GameObject pauseMenu;
    public GameObject mutedSound;
    public GameObject unmutedSound;
    public GameObject readyText;
    public GameObject steadyText;
    public GameObject runText;
    public GameObject instructions;
    public GameObject settings;
    public GameObject areYouSure;
    public GameObject gameOver;
    public GameObject stats;
    public GameObject gameShop;
    public GameObject achievements;
    public Button settingsButton;
    public Button statsButton;
    public Button creditsButton;
    public Button instructionsButton;
    public Button gameShopButton;
    public Button achievementsButton;
    public AudioClip click;
    public Text totalCoinsText;
    public Text highScoreText;
    public Text totalDistanceText;
    public Text bestDistanceText;
    public Text bestCoinsText;
    public float totalCoins;
    public float runCoins;
    public float highScore;
    public float totalDistance;
    public float runDistance;
    public bool mute = false;
    public int playedTutorial = 0;

    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = click;
        Time.timeScale = 1;
    }

    void Update()
    {

    }

    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        GetComponent<AudioSource>().Play();
    }

    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        GetComponent<AudioSource>().Play();
    }

    public void LoadLevel(string level)
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(level);
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        GetComponent<AudioSource>().Play();
        Application.Quit();
    }

    public void MuteInGame()
    {
        GetComponent<AudioSource>().Play();
        if (mute == false)
        {
            AudioListener.pause = true;
            mute = true;
            mutedSound.SetActive(true);
            unmutedSound.SetActive(false);
        }
        else
        {
            AudioListener.pause = false;
            mute = false;
            mutedSound.SetActive(false);
            unmutedSound.SetActive(true);
        }
    }

    public void Mute()
    {
        GetComponent<AudioSource>().Play();
        if (mute == false)
        {
            AudioListener.pause = true;
            mute = true;
        }
        else
        {
            AudioListener.pause = false;
            mute = false;
        }
    }

    public void OpenInstructions()
    {
        GetComponent<AudioSource>().Play();
        instructions.SetActive(true);
        statsButton.interactable = false;
        settingsButton.interactable = false;
        creditsButton.interactable = false;
        gameShopButton.interactable = false;
        achievementsButton.interactable = false;
        instructionsButton.interactable = false;
    }

    public void CloseInstructions()
    {
        GetComponent<AudioSource>().Play();
        instructions.SetActive(false);
        statsButton.interactable = true;
        settingsButton.interactable = true;
        creditsButton.interactable = true;
        gameShopButton.interactable = true;
        achievementsButton.interactable = true;
        instructionsButton.interactable = true;
    }

    public void OpenSettings()
    {
        GetComponent<AudioSource>().Play();
        settings.GetComponent<Animation>().Play();
        settings.SetActive(true);
        statsButton.interactable = false;
        instructionsButton.interactable = false;
        creditsButton.interactable = false;
        gameShopButton.interactable = false;
        achievementsButton.interactable = false;
        settingsButton.interactable = false;
    }

    public void CloseSettings()
    {
        GetComponent<AudioSource>().Play();
        settings.SetActive(false);
        statsButton.interactable = true;
        instructionsButton.interactable = true;
        creditsButton.interactable = true;
        gameShopButton.interactable = true;
        achievementsButton.interactable = true;
        settingsButton.interactable = true;
    }

    public void ResetStats()
    {
        GetComponent<AudioSource>().Play();
        PlayerPrefs.DeleteAll();
        areYouSure.SetActive(false);
    }

    public void OpenAreYouSure()
    {
        GetComponent<AudioSource>().Play();
        areYouSure.SetActive(true);
    }

    public void CloseAreYouSure()
    {
        GetComponent<AudioSource>().Play();
        areYouSure.SetActive(false);
    }

    public void StartOver(string level)
    {
        GetComponent<AudioSource>().Play();
        Time.timeScale = 1;
        EndTrigger.gameOver = false;
        SceneManager.LoadScene(level);
        gameOver.SetActive(false);
    }

    public void OpenStats()
    {
        GetComponent<AudioSource>().Play();
        stats.GetComponent<Animation>().Play();
        totalCoins = PlayerPrefs.GetInt("Total Coins");
        runCoins = PlayerPrefs.GetInt("Best Run Coins");
        highScore = PlayerPrefs.GetFloat("High Score");
        totalDistance = PlayerPrefs.GetFloat("Total Distance") / 5280;
        runDistance = PlayerPrefs.GetFloat("Best Run Distance");
        totalCoinsText.text = "Total Coins: " + totalCoins.ToString();
        highScoreText.text = "High Score: " + highScore.ToString("F0");
        totalDistanceText.text = "Total Distance: " + totalDistance.ToString("F2") + " miles";
        bestCoinsText.text = "Run Coins: " + runCoins.ToString() + " coins";
        bestDistanceText.text = "Run Distance: " + runDistance.ToString("F2") + " feet";
        stats.SetActive(true);
        settingsButton.interactable = false;
        instructionsButton.interactable = false;
        creditsButton.interactable = false;
        gameShopButton.interactable = false;
        achievementsButton.interactable = false;
        statsButton.interactable = false;
    }

    public void CloseStats()
    {
        GetComponent<AudioSource>().Play();
        stats.SetActive(false);
        settingsButton.interactable = true;
        instructionsButton.interactable = true;
        creditsButton.interactable = true;
        gameShopButton.interactable = true;
        achievementsButton.interactable = true;
        statsButton.interactable = true;
    }

    public void OpenGameShop()
    {
        GetComponent<AudioSource>().Play();
        gameShop.GetComponent<Animation>().Play();
        gameShop.SetActive(true);
        settingsButton.interactable = false;
        instructionsButton.interactable = false;
        creditsButton.interactable = false;
        achievementsButton.interactable = false;
        statsButton.interactable = false;
        gameShopButton.interactable = false;
    }

    public void CloseGameShop()
    {
        GetComponent<AudioSource>().Play();
        gameShop.SetActive(false);
        settingsButton.interactable = true;
        instructionsButton.interactable = true;
        creditsButton.interactable = true;
        achievementsButton.interactable = true;
        statsButton.interactable = true;
        gameShopButton.interactable = true;
    }

    public void OpenAchievements()
    {
        GetComponent<AudioSource>().Play();
        achievements.GetComponent<Animation>().Play();
        settingsButton.interactable = false;
        instructionsButton.interactable = false;
        creditsButton.interactable = false;
        gameShopButton.interactable = false;
        statsButton.interactable = false;
        achievementsButton.interactable = false;
    }

    public void CloseAchievements()
    {
        GetComponent<AudioSource>().Play();
        settingsButton.interactable = true;
        instructionsButton.interactable = true;
        creditsButton.interactable = true;
        gameShopButton.interactable = true;
        statsButton.interactable = true;
        achievementsButton.interactable = true;
    }
}