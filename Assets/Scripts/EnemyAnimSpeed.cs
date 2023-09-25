//EnemyAnimSpeed.cs by Joseph Panara for Green Thumb
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls the animation speed of an object
public class EnemyAnimSpeed : MonoBehaviour
{
    public Animator animator;
    public float playspeed = 1;
    public bool change;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.speed = playspeed;

    }
    //Performs a one-time update to animation speed
    void Update()
    {
        if (change = true)
        {
            animator.speed = playspeed;
            change = false;
        }
    }

}
