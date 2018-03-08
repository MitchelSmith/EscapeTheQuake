using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCollapse : MonoBehaviour {

    /*
     * Collapses buildings when platform falls
     */

    public bool isCollapsing = false;
    public float delta = 0.1f;
    public float speed = 60f;
    public float elapsedSeconds;

    private Rigidbody2D rb2d;
    private Vector2 startPos;
    private Vector2 move;

    // Use this for initialization
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();

        startPos = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isCollapsing)
        {
            if (Time.timeScale == 0)
                return;

            elapsedSeconds += Time.deltaTime;
            move.x += delta * Mathf.Sin(Time.time * speed);
            move.y -= 4f * Time.deltaTime;
            transform.position = move;

            if (elapsedSeconds > 10)
                Destroy(gameObject);
        }
    }

    public void Collapse()
    {
        if (!isCollapsing)
        {
            rb2d.isKinematic = false;
            isCollapsing = true;
            move = startPos;
        }
    }
}
