using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum Alignment
    {
        Player,
        Enemy,
        Environment
    }

    public enum WeaponType
    {
        Melee,
        Ranged,
        Projectile
    }

    public Alignment alignmnent = Alignment.Player;
    public WeaponType weaponType = WeaponType.Melee;

    public int damageValue;

    [Header("IF MELEE WEAPON")]
    public Collider2D collider;
    public SpriteRenderer sprite;
    public AudioSource audiosource;
    public AudioClip collideclip;

    [Header("IF RANGED WEAPON")]
    public GameObject projectile;
    public Vector2 direction;
    public float force = 100f;
    public float duration = 10f;
    public Transform shootPosition;

    //[Header("IF PLAYER WEAPON")]
   // public PlayerMovement playerMovement;



    public bool flipWeapon = false;

    void Start()
    {
        if (alignmnent == Alignment.Player)
        {
            collider.enabled = false;
        }

        if(weaponType == WeaponType.Projectile)
        {
            audiosource = GetComponent<AudioSource>();
            sprite = GetComponent<SpriteRenderer>();
        }
    }

    public void WeaponStart()
    {
        //this.gameObject.SetActive(true);
        collider.enabled = true;
        //sprite.enabled = true;
    }

    public void WeaponFinished()
    {
        collider.enabled = false;
        //sprite.enabled = false;
        //this.gameObject.SetActive(false);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (weaponType == WeaponType.Projectile)
        {
            StartCoroutine(DestroySequence());
        }
    }

    private void OnValidate()
    {
        direction = direction.normalized;
    }

    private IEnumerator DestroySequence()
    {
        audiosource.clip = collideclip;
        audiosource.Play();
        collider.enabled = false;
        sprite.enabled = false;
        yield return new WaitForSeconds(collideclip.length);
        Destroy(this.gameObject);
    }










}
