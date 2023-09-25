using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //This class should be placed on anything enemy related! Or anything that the player can damage
    public int maxHealth = 100;

    public int currentHealth;

    public Animator enemyanimator;

    public EnemyAnimSpeed animspeed;

    public Shoot shoot;

    public BoxCollider2D collider;

    public AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        enemyanimator = GetComponent<Animator>();
        animspeed = GetComponent<EnemyAnimSpeed>();
        shoot = GetComponent<Shoot>();
        audiosource = GetComponent<AudioSource>();
    }

    public void DecreaseHealth(int value)
    {
        currentHealth -= value;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Weapon weapon))
        {
            if (weapon.alignmnent == Weapon.Alignment.Environment)
            {
                DecreaseHealth(weapon.damageValue);
                if (currentHealth == 0)
                {
                    //Destroy(this.gameObject);
                    if (shoot)
                    {
                        shoot.enabled = false;
                    }
                    animspeed.playspeed = 1;
                    animspeed.change = true;
                    enemyanimator.SetBool("isDead", true);
                    audiosource.Play();
                    collider.enabled = false;
                    //If this enemy reaches 0 health, they are straight up destroyed. 
                    //If you want something fancy like an animation or the like, you can try to implement it here
                }
            }
        }
    }
}
