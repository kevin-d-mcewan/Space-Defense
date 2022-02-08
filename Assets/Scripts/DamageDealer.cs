using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    /* This Script is to determine how much damage the GameObject this script is attached to does*/

    [SerializeField] int damage = 10;


    public int GetDamage()
    {
        return damage;
    }

    // Function used in Health
    public void Hit()
    {
        // If it hits something it destroys itself
        Destroy(gameObject);
    }


}
