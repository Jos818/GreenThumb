//ActivateAnimation.cs by Joseh Panara for Green Thumb
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script handles animations/audio clips that are affected by player proximity
public class ActivateAnimation : MonoBehaviour
{
    private Animator animator;
    private AudioSource audiosource;

    void Start()
    {
        animator = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("Active", true);
            audiosource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            if (collision.CompareTag("Player"))
            {
                animator.SetBool("Active", false);
                audiosource.Play();
        }

    }
}
