using UnityEngine;
using UnityEngine.SceneManagement;
using Zone.Core.Utils;

public class GameManager : Singleton<GameManager>, IDamageable
{
    public int health = 3;



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
        SceneManager.LoadScene("DeathScene");
    }

    public void ResetState()
    {
        health = 3;
    }
}
