﻿using UnityEngine;
using Zone.Core.Utils;

public class GameManager : Singleton<GameManager>, IDamageable
{
    private int health = 3;



    public void TakeDamage()
    {
        health--;
        if (health == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //TODO need to implement
        // throw new NotImplementedException();
    }
}