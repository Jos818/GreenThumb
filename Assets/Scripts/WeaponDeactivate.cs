//WeaponDeactivate.cs by Joseph Panara for Green Thumb
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//On contact with the trigger, it moves the player on a "false z-axis" so they can interact with plant objects
public class WeaponDeactivate : MonoBehaviour
{
    public PlayerMovement playerMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerMovement.raised = true;
        }
    }

    
}
