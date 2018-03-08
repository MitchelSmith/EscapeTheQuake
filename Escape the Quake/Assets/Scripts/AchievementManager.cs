using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AchievementManager : MonoBehaviour {

    public GameObject achievementPrefab;
    public Sprite[] sprites;
    public ScrollRect scrollRect;
    public GameObject achievementMenu;
    public GameObject visualAchievement;
    public Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement>();
    public Sprite unlockedSprite;
    
    private AchievementButton activeButton;
    private static AchievementManager instance;
    private int fadeTime = 2;
    private int today = (int)DateTime.Now.DayOfWeek;
    private string hidden1, hidden2, hidden3, hidden4, hidden5, hidden6;
    private string redShirtHidden = "???? ?????? ???????? ??? ????";
    private string redShirt = "Fall before reaching 100 feet";
    private string rebelHidden = "?? ???? ???? ??? ????? ?? ????";
    private string rebel = "Go left from the start 30 feet";
    private string biggerSeismometerHidden = "????? ????????? ??";
    private string biggerSeismometer = "Reach magnitude 11";
    private string studentHidden = "???? ??? ???????? ?? ?????";
    private string student = "Play the tutorial 10 times";
    private string brickHidden = "??? ?? ? ????? ?? ?????";
    private string brick = "Hit by a brick 30 times";
    private string leaveMarkHidden = "??? ?? ??? ????? ?? ?????";
    private string leaveMark = "Hit by big piece 10 times";

    public static AchievementManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<AchievementManager>();
            }
            return instance;
        }
    }

    // Use this for initialization
    void Start()
    {
        activeButton = GameObject.Find("GeneralButton").GetComponent<AchievementButton>();

        //BEGINNER ACHIEVEMENTS
        CreateAchievement("General", "New Kid On The Fault", "Played the tutorial", 0);
        CreateAchievement("General", "Amateur Seismologist", "Reach a score of 150", 0);
        CreateAchievement("General", "Fun Runner", "Reach 300 feet in a single run", 0);
        CreateAchievement("General", "Chump Change", "Collect 40 coins in a single run", 0);
        CreateAchievement("General", "Jack Of All Trades", "Collect each powerup once", 0);

        //INTERMEDIATE ACHIEVEMENTS
        CreateAchievement("General", "Master of None", "Upgrade each powerup once", 0);
        CreateAchievement("General", "Going The Distance", "Reach 1,250 feet in a single run", 0);
        CreateAchievement("General", "Collector", "Collect 100 power ups", 0);
        CreateAchievement("General", "Money Bags", "Collect a total of 1000 coins", 0);

        //EXPERT ACHIEVEMENTS
        CreateAchievement("General", "Marathoner", "Reach a total distance of 26.2 miles", 0);
        CreateAchievement("General", "Piece Of Quake", "Reach a score of 1000", 0);
        CreateAchievement("General", "Feel The Power", "Upgrade all power ups completely", 0);
        CreateAchievement("General", "Escape Artist", "Reach 2,000 feet in a single run", 0);
        CreateAchievement("General", "Feeling Lucky", "Have it rain coins 50 times", 0);

        //EXTREME ACHIEVEMENTS
        CreateAchievement("General", "Penny Pincher", "Have 25,000 coins at once", 0);
        CreateAchievement("General", "I Would Run 500 Miles", "Reach a total distance of 500 miles", 0);
        CreateAchievement("General", "And I Would Run 500 More", "Reach a total distance of 1,000 miles", 0);

        //OTHER ACHIEVEMENTS
        CreateAchievement("General", "Redshirt", hidden1, 0);
        CreateAchievement("General", "Rebel", hidden2, 0);
        CreateAchievement("General", "We're Gonna Need A Bigger Seismometer", hidden3, 0);
        CreateAchievement("General", "Professional Student", hidden4, 0);
        CreateAchievement("General", "Ain't That A Brick In The Head", hidden5, 0);
        CreateAchievement("General", "That'll Leave A Mark", hidden6, 0);

        //DAILY ACHIEVEMENTS
        //Changes according to the day of the week
        if (today == 0)
        {
            
        }
        if (today == 1)
        {
           
        }
        if (today == 2)
        {

        }
        if (today == 3)
        {

        }
        if (today == 4)
        {
            CreateAchievement("Daily", "A Penny Saved", "Collect 100 coins in one run", 0);
        }
        if (today == 5)
        {
            CreateAchievement("Daily", "Walk In The Park", "Reach a distance of 1000 feet in one run", 0);
        }
        if (today == 6)
        {

        }

        foreach (GameObject achievementList in GameObject.FindGameObjectsWithTag("AchievementList"))
        {
            achievementList.SetActive(false);
        }

        activeButton.Click();

        achievementMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetFloat("High Score") >= 150)
        {
            EarnAchievement("Amateur Seismologist");
        }
        if (PlayerPrefs.GetFloat("High Score") >= 1000)
        {
            EarnAchievement("Piece Of Quake");
        }
        if ((PlayerPrefs.GetFloat("Total Distance") / 5280) >= 500)
        {
            EarnAchievement("I Would Run 500 Miles");
        }
        if ((PlayerPrefs.GetFloat("Total Distance") / 5280) >= 1000)
        {
            EarnAchievement("And I Would Run 500 More");
        }
        if (PlayerPrefs.GetFloat("Run Distance") >= 300)
        {
            EarnAchievement("Fun Runner");
        }
        if (PlayerPrefs.GetInt("Run Coins") >= 40)
        {
            EarnAchievement("Chump Change");
        }
        if (PlayerPrefs.GetFloat("Run Distance") >= 1250)
        {
            EarnAchievement("Going The Distance");
        }
        if ((PlayerPrefs.GetFloat("Total Distance") / 5280) >= 26.2)
        {
            EarnAchievement("Marathoner");
        }
        if (PlayerPrefs.GetFloat("Run Distance") >= 2000)
        {
            EarnAchievement("Escape Artist");
        }
        if (PlayerPrefs.GetInt("Total Coins") >= 25000)
        {
            EarnAchievement("Penny Pincher");
        }
        if (PlayerPrefs.GetInt("Total Coins") >= 1000)
        {
            EarnAchievement("Money Bags");
        }
        if (PlayerPrefs.GetInt("Played Tutorial") >= 1)
        {
            EarnAchievement("New Kid On The Fault");
        }
        if (PlayerPrefs.GetInt("Played Tutorial") >= 10)
        {
            EarnAchievement("Professional Student");
            studentHidden = student;
        }
        if (PlayerPrefs.GetInt("Run Coins") >= 100)
        {
            EarnAchievement("A Penny Saved");
        }
        if (PlayerPrefs.GetFloat("Run Distance") >= 1000)
        {
            EarnAchievement("Walk In The Park");
        }
        if (PlayerPrefs.GetFloat("Run Distance") >= -30)
        {
            EarnAchievement("Rebel");
            rebelHidden = rebel;
        }
        if (PlayerPrefs.GetFloat("Run Distance") >= 0 && PlayerPrefs.GetFloat("Run Distance") <= 100)
        {
            EarnAchievement("Redshirt");
            redShirtHidden = redShirt;
        }
    }

    public void EarnAchievement(string title)
    {
        if (achievements[title].EarnAchievement())
        {
            GameObject achievement = (GameObject)Instantiate(visualAchievement);
            SetAchievementInfo("EarnCanvas", achievement, title);
            StartCoroutine(FadeAchievement(achievement));
        }
    }

    public IEnumerator HideAchievement(GameObject achievement)
    {
        yield return new WaitForSeconds(3);
        Destroy(achievement);
    }

    public void CreateAchievement(string parent, string title, string description, int spriteIndex, string[] dependencies = null)
    {
        GameObject achievement = (GameObject)Instantiate(achievementPrefab);

        Achievement newAchievement = new Achievement(title, description, achievement, spriteIndex);

        achievements.Add(title, newAchievement);

        SetAchievementInfo(parent, achievement, title);

        if (dependencies != null)
        {
            foreach (string achievementTitle in dependencies)
            {
                Achievement dependency = achievements[achievementTitle];
                dependency.Child = title;
                newAchievement.AddDependency(dependency);
            }
        }
    }

    public void SetAchievementInfo(string parent, GameObject achievement, string title)
    {
        achievement.transform.SetParent(GameObject.Find(parent).transform);
        achievement.transform.localScale = new Vector3(1, 1, 1);
        achievement.transform.GetChild(0).GetComponent<Text>().text = title;
        achievement.transform.GetChild(1).GetComponent<Text>().text = achievements[title].Description;
        achievement.transform.GetChild(2).GetComponent<Image>().sprite = sprites[achievements[title].SpriteIndex];
    }

    public void ChangeCategory(GameObject button)
    {
        AchievementButton achievementButton = button.GetComponent<AchievementButton>();

        scrollRect.content = achievementButton.achievementList.GetComponent<RectTransform>();

        achievementButton.Click();
        activeButton.Click();
        activeButton = achievementButton;
    }

    public void ActivateList()
    {
        achievementMenu.SetActive(!achievementMenu.activeSelf);
    }

    private IEnumerator FadeAchievement(GameObject achievement)
    {
        CanvasGroup canvasGroup = achievement.GetComponent<CanvasGroup>();

        float rate = 1.0f / fadeTime;
        int startAlpha = 0;
        int endAlpha = 1;

        for(int i = 0; i < 2; i++)
        {
            float progress = 0.0f;

            while (progress < 1.0)
            {
                canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, progress);

                progress += rate * Time.deltaTime;

                yield return null;
            }

            yield return new WaitForSeconds(2);
            startAlpha = 1;
            endAlpha = 0;
        }

        Destroy(achievement);
    }
}
