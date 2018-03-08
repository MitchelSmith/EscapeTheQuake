using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementButton : MonoBehaviour {

    public GameObject achievementList;
    public Sprite neutral, highlight;

    private Image sprite;

    void Awake()
    {
        sprite = GetComponent<Image>();
    }

    public void Click()
    {
        if (sprite.sprite == neutral)
        {
            sprite.sprite = highlight;
            achievementList.SetActive(true);
        }
        else
        {
            sprite.sprite = neutral;
            achievementList.SetActive(false);
        }
    }
}
