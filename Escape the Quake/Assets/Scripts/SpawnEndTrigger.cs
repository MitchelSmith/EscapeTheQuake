using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEndTrigger : MonoBehaviour {

    public GameObject endTrigger;
    public Transform endTriggerSpawn;

	// Use this for initialization
	void Start ()
    {
        Spawn();
	}

    void Spawn()
    {
        Instantiate(endTrigger, endTriggerSpawn.position, Quaternion.identity);
    }
}
