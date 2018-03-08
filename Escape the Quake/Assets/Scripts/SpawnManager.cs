using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    /*
     * Controls how the platforms spawn in front of the player
     */

    public int maxPlatforms = 10;       //maximum amount of platforms
    public static int destroyedPlatforms = 0;
    public static int totalPlatforms = 0;
    public int destroyedPlatformsView;
    public int totalPlatformsView;
    public GameObject currentPlatform;
    public GameObject platformOne;
    public GameObject platformTwo;
    public GameObject platformThree;
    public float horizontalMin = 14f;  //horizontal min and max of platform
    public float horizontalMax = 19f;
    public float verticalMin = -5.5f;     //vertical min and max of platform
    public float verticalMax = 4.5f;

    private float elapsedSeconds = 0;
    private Vector2 originPosition;

	// Use this for initialization
	void Start ()
    {
        originPosition = transform.position;    //first position is origin of spawn manager
        totalPlatforms = 0;
        destroyedPlatforms = 0;
        Spawn();
    }

    void Update()
    {
        elapsedSeconds += Time.deltaTime;

        destroyedPlatformsView = destroyedPlatforms;
        totalPlatformsView = totalPlatforms;
        if(destroyedPlatforms > 2 && totalPlatforms <= 30) //continually spawns platforms
        {
            destroyedPlatforms = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        for(int i = 0; i < maxPlatforms; i++)   //puts platform in random spots between premade mins and maxes
        {
            Vector2 randomPosition = originPosition + new Vector2(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));

            int n = Random.Range(0, 10);

            if (SimplePlatformController.elapsedSeconds < 60)
            {
                if (n <= 7)
                {
                    currentPlatform = platformOne;
                }
                if (n >= 9)
                {
                    currentPlatform = platformTwo;
                }
                if (n > 7 && n < 9)
                {
                    currentPlatform = platformThree;
                }
            }

            if (SimplePlatformController.elapsedSeconds > 60)
            {
                if (n <= 5)
                {
                    currentPlatform = platformOne;
                }
                if (n >= 8)
                {
                    currentPlatform = platformTwo;
                }
                if (n > 5 && n < 8)
                {
                    currentPlatform = platformThree;
                }
            }

            if (SimplePlatformController.elapsedSeconds > 120)
            {
                if (n <= 2)
                {
                    currentPlatform = platformOne;
                }
                if (n >= 7)
                {
                    currentPlatform = platformTwo;
                }
                if (n > 2 && n < 7)
                {
                    currentPlatform = platformThree;
                }
            }
            Instantiate(currentPlatform, randomPosition, Quaternion.identity);
            originPosition = randomPosition;
        }
        totalPlatforms += 10;
    }
}
