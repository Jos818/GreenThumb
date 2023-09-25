//Shoot.cs by Joseph Panara for Green Thumb
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles the behavior for objects that shoot projectiles
public class Shoot : MonoBehaviour

{
    public Weapon weapon;
    public float coolDown;
    public float delay;
    public bool canAttack = true;
    public float growthdelay = 1;

    //Checks if the object has PlantHealth, and runs the Delay coroutine
    void Awake()
    {
        if (this.gameObject.TryGetComponent(out PlantHealth planthealth))
        {
            if (planthealth.pregrown == false)
            {
                delay = delay + 1;
            }
            
        }
        StartCoroutine(Delay());
    }

    //Runs the Attack function
    void Update()
    {

        if (canAttack != false)
        {
            Attack(transform.localScale);
        }
        
    }

    //Creates the projectile based on a prefab at the designated location then launches it in a specified direction and speed
    //Then begins the CoolDown coroutine to manage projectile firing rate
    public void Attack(Vector3 scale)
    {
            GameObject projectile = Instantiate(weapon.projectile, weapon.shootPosition.position, Quaternion.identity);
            projectile.GetComponent<Projectile>().SetValues(weapon.duration, weapon.alignmnent, weapon.damageValue);
            projectile.transform.localScale = new Vector3(projectile.transform.localScale.x * (scale.x / Mathf.Abs(scale.x)), projectile.transform.localScale.y, projectile.transform.localScale.z);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.AddForce(weapon.direction * weapon.force * scale.x);
            StartCoroutine(CoolDown());
        
    }

    //A series of delays that manage projectile firing rate
    private IEnumerator CoolDown()
    {
        canAttack = false;
        yield return new WaitForSeconds(coolDown);
        canAttack = true;
    }

    private IEnumerator Delay()
    {
        canAttack = false;
        yield return new WaitForSeconds(delay);
        canAttack = true;
    }

    public IEnumerator GrowthDelay()
    {
        canAttack = false;
        yield return new WaitForSeconds(growthdelay);
        canAttack = true;
    }
}
