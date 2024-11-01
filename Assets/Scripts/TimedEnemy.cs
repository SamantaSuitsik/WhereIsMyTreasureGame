using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedEnemy : MonoBehaviour
{
    public float moveSpeed = 2f; 
    private bool movingRight = true; 
    private SpriteRenderer spriteRenderer;
    private float timer;
    private float switchTime = 1;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MoveEnemy();

        timer += Time.deltaTime;

        if (timer >= switchTime)
        {
            movingRight = !movingRight;
            timer = 0;
        }
    }

    void MoveEnemy()
    {
        if (movingRight)
        {
            spriteRenderer.flipX = false; 
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0); // Move right

        }
        else
        {
            spriteRenderer.flipX = true; 
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0); // Move left
        }
    }
}
