using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f; 
    private bool movingRight = true; 
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MoveEnemy();
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

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            foreach (ContactPoint2D contact in col.contacts)
            {
                Vector3 hit = contact.normal;
                float angle = Vector3.Angle(hit, Vector3.up);
                
                if (Mathf.Approximately(angle, 90))
                {
                    Vector3 cross = Vector3.Cross(Vector3.forward, hit);
                    if (cross.y > 0)
                    {
                        movingRight = true; 
                    }
                    else
                    {
                        movingRight = false; 
                    }
                }
            }
        }
    }
    
    
}
