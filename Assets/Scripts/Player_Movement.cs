//Player_Movement.cs by Brackeys
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    public bool canMove;
    public AudioSource audio;
    public bool audioplaying;

    void Start()
    {
        canMove = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        //Attaches player movement to vertical and horizontal axises and sets animations
        if (canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
            if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
            {
                animator.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
                animator.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
            }
        }
        //Freezes player
        else
        {
            movement.x = 0;
            movement.y = 0;
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", 0);
        }
        //Handles player movement audio
        if (movement.x != 0 & audioplaying != true || movement.y != 0 & audioplaying != true)
        {
            audio.Play();
            audioplaying = true;
        }
        else if (movement.x == 0 & movement.y == 0)
        {
            audio.Stop();
            audioplaying = false;
        }
    }
    void FixedUpdate()
    {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}