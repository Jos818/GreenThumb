//Push.cs by Joseph Panara for Green Thumb
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles the behavior when the player pushes pushable objects
public class Push : MonoBehaviour
{
    public float pushspeed = 5f;
    new Vector3 currentposition;
    float horizontalInput;
    float verticalInput;
    public bool pushing = false;
    public Collider2D collider;

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        if (pushing != false)
        {
            transform.position = transform.position + new Vector3(horizontalInput * pushspeed * Time.deltaTime, verticalInput * pushspeed * Time.deltaTime, 0);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            pushing = true;
 
    }

    private void OnCollisionExit2D (Collision2D collision)
    {
            pushing = false;

    }
}
