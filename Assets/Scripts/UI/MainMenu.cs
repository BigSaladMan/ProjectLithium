using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private MenuManager menuManager;

    private void Start() 
    {
        menuManager = MenuManager.instance;    
    }

    public void ShowGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ShowMain() 
    {
        menuManager.CloseMenu("credits");
        menuManager.OpenMenu("main");
    } 
    
    public void ShowCredit()
    {
        menuManager.CloseMenu("main");
        menuManager.OpenMenu("credits");
    }

    public void ShowPlanetGenerator()
    {
        Application.OpenURL("https://deep-fold.itch.io/pixel-planet-generator");
    }
    

    public void ShowQuit()
    {
        // TODO spawn error console to yell at player to alt+f4
    }   
}
