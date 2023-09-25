//PlantHealth.cs by Joseph Panara
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles the health point function of plant objects
public class PlantHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject ungrown;
    public GameObject parent;
    public bool pregrown;

    //Sets the current plant health to its maximum
    void Start()
    {
        currentHealth = maxHealth;
    }
    
    //Decreases plant health
    public void DecreaseHealth(int value)
    {
        currentHealth -= value;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

    //When the plant health reaches 0, it returns to its "ungrown" state
    //If the plant was originally potted, it returns to the potted state
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Weapon weapon))
        {
                DecreaseHealth(weapon.damageValue);
                if (currentHealth == 0)
                {
                pregrown = false;
                if (this.gameObject.TryGetComponent(out Shoot shoot))
                {
                    shoot.canAttack = true;
                }
                this.gameObject.SetActive(false);
                    ungrown.SetActive(true);
                if (parent.gameObject.TryGetComponent(out PlantBehavior plantbehavior))
                {
                    plantbehavior.pot.enabled = true;
                    plantbehavior.destroyed = false;
                    Rigidbody2D parentrb = parent.AddComponent<Rigidbody2D>();
                    parentrb.drag = 1000;
                    parentrb.gravityScale = 0;
                    parentrb.freezeRotation = true;
                    plantbehavior.SetRigidbody2D();
                    plantbehavior.audiosource.clip = plantbehavior.pushclip;
                }
            }
                
        }
    }
 }
