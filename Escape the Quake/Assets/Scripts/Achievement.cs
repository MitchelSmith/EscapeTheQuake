using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement {

    private string name;
    private string description;
    private bool unlocked;
    private int spriteIndex;
    private GameObject achievementRef;
    private List<Achievement> dependencies = new List<Achievement>();
    private string child;

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public string Description
    {
        get
        {
            return description;
        }

        set
        {
            description = value;
        }
    }

    public int SpriteIndex
    {
        get
        {
            return spriteIndex;
        }

        set
        {
            spriteIndex = value;
        }
    }

    public string Child
    {
        get
        {
            return child;
        }

        set
        {
            child = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        Achievement myAchievement = new Achievement(name, description, achievementRef, spriteIndex);
    }

    public Achievement(string name, string description, GameObject achievementRef, int spriteIndex)
    {
        this.name = name;
        this.description = description;
        this.unlocked = false;
        this.spriteIndex = spriteIndex;
        this.achievementRef = achievementRef;
        LoadAchievement();
    }

    public void AddDependency(Achievement dependency)
    {
        dependencies.Add(dependency);
    }

    public bool EarnAchievement()
    {
        if (!unlocked && !dependencies.Exists(x => x.unlocked == false))
        {
            achievementRef.GetComponent<Image>().sprite = AchievementManager.Instance.unlockedSprite;
            SaveAchievement(true);       
            
            if (child != null)
            {
                AchievementManager.Instance.EarnAchievement(child);
            } 
            return true;
        }
        return false;
    }

    public void SaveAchievement(bool value)
    {
        unlocked = value;

        PlayerPrefs.SetInt(name, value ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void LoadAchievement()
    {
        unlocked = PlayerPrefs.GetInt(name) == 1 ? true : false;

        if (unlocked)
        {
            achievementRef.GetComponent<Image>().sprite = AchievementManager.Instance.unlockedSprite;
        }
    }
}
