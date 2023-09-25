//ProjectileIgnore.cs by Joseph Panara for Green Thumb
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ignores physics interactions between the projectile layer and the pot/water layer
public class ProjectileIgnore : MonoBehaviour
{
    void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 7);
        //6 and 7 are numbers of layers specified for the pots and the projectiles. Make sure numbers line up!
    }

}
