using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    private int health = 3; // TODO do we want 3 health on enemy

    public void TakeDamage()
    {
        health--;
        // TODO implement this
        //throw new System.NotImplementedException();
    }

}
