using UnityEngine;
using UnityEngine.SceneManagement;
using Zone.Core.Utils;
using TMPro;

public class GameManager : Singleton<GameManager>, IDamageable
{
    public int health = 3;

    public int score = 0; // TODO when going to death scene, check keep alive on gamemanager and grab score from here

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text healthText;

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            scoreText.text = $"Score: {score}";    
            healthText.text = $"Health: {health}";    
        }
            
    }

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
        SceneManager.LoadScene("DeathScene");
    }

    public void ResetState()
    {
        health = 3;
        score = 0;
    }
}
