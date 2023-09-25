//PlantBehavior.cs by Joseph Panara for Green Thumb
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//Handles the behavior for the growable plant objects
public class PlantBehavior : MonoBehaviour
{
    public GameObject ungrown;
    public GameObject grown;
    public Shoot grownshoot;
    public Animator plantanimator;
    public AudioSource audiosource;
    public AudioClip growclip;
    public AudioClip pushclip;
    public Collider2D pot;
    public Rigidbody2D rb;
    public bool destroyed = false;
    public Tilemap upperbordermap;
    public Tilemap wallmap;
    public Tile replacement;
    public List<Vector3Int> destroytiles;
    public List<Vector3Int> replacetiles;
    bool inArea = false;
    public PlayerMovement playerMovement;

    //Checks for optional components
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audiosource = GetComponent<AudioSource>();
        grownshoot = grown.GetComponent<Shoot>();


        if (pot)
        { 
            audiosource.clip = pushclip;
        }

    }

    public void SetRigidbody2D()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    //Checks if the Watering Can object is in range to interact with the plant object
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Watering Can")
        {
            inArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Watering Can")
        {
            inArea = false;

        }
        

    }

    //Handles the Plant Growth animation and audio
    private IEnumerator GrowthAnimation()
    {
        plantanimator = grown.GetComponent<Animator>();
        audiosource.loop = false;
        audiosource.clip = growclip;
        audiosource.Play();
        plantanimator.SetBool("Growing", true);
        grownshoot.GrowthDelay();
        yield return new WaitForSeconds(1);
        plantanimator.SetBool("Growing", false);
    }


    private void Update()
    {
        //Checks if the plant is a movable "Potted Plant" and handles audio
        if (pot && destroyed == false)
        {
            if (rb.velocity.x > 0.1 || rb.velocity.y > 0.1 || rb.velocity.x < -0.1 || rb.velocity.y < -0.1)
            {
                if (audiosource.isPlaying == false)
                {
                    audiosource.clip = pushclip;
                    audiosource.loop = true;
                    audiosource.Play();
                }
            }
            else
            {
                audiosource.loop = false;
                audiosource.Stop();
            }
            
        }
        //If the player is on the same "false z-axis" as the plant and the Watering Can is in range, the plant growth process starts
        if (inArea && playerMovement.raised != true)
        {
                ungrown.SetActive(false);
            //If the plant is potted, the pot and Rigidbody to move the pot are deactivated or destroyed
            if (pot)
            {
                pot.enabled = false;
                Destroy(rb);
                destroyed = true;
            }
            //The plant growth animation plays
            StartCoroutine(GrowthAnimation());
            //If the plant affects the tilemap, certain tiles are removed and added
            //This allows the plant to appear as if it becomes a part of the landscape
            foreach (Vector3Int destroytiles in destroytiles)
                {
                    wallmap.SetTile(destroytiles, null);
                    upperbordermap.SetTile(destroytiles, null);
                }
                foreach (Vector3Int replacetiles in replacetiles)
                {
                    upperbordermap.SetTile(replacetiles, replacement);
                }
                grown.SetActive(true);
            //Sets the plant's health if it has the PlantHealth component
            if (grown.TryGetComponent(out PlantHealth planthealth))
            {
                planthealth.currentHealth = planthealth.maxHealth;
            }

        }
        
    }

}
