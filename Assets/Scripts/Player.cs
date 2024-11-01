using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int Lives;
    public float Speed = 5f;
    public float jumpForce = 1f;
    private Vector3 movement;
    private Animator animator;
    private bool isGrounded = true;

    private Rigidbody2D rigidBody;

    private void Awake()
    {
        Events.OnGetLives += OnGetLives;
        Events.ChangeLives(Lives);

    }

    private int OnGetLives()
    {
        return Lives;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        movement = new Vector3(horizontal, 0f, 0f);
        movement = movement * (Speed * Time.deltaTime);
        transform.position += movement;
        
        if(horizontal > 0)
        {
            animator.SetBool("RunRight", true);
        }
        else if (horizontal < 0)
        {
            animator.SetBool("RunLeft", true);
        }
        else
        {
            animator.SetBool("RunRight", false);
            animator.SetBool("RunLeft", false);   
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            return;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Events.ChangeLives(Events.GetLives() - 1);
            Lives--;
            if (Lives <= 0)
            {
                SceneManager.LoadScene(2);
            }
        }

        if (collision.gameObject.CompareTag("Chest"))
        {
            SceneManager.LoadScene(3);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            print("water");
            SceneManager.LoadScene(2);
        }
    }
    
    
}





















