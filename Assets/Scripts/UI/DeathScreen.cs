using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathScreen : MonoBehaviour
{

    [SerializeField] private TMP_Text scoreText;

    void Start()
    {    
        scoreText.text = $"{GameManager.instance.score}";
    }

    public void ShowMain()
    {
        SceneManager.LoadScene("Menus");
        Destroy(GameManager.instance);
    }

}
