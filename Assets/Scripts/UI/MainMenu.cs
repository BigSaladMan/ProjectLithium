using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private MenuManager menuManager;
    [SerializeField] private GameObject menuPlanet;
    [SerializeField] private GameObject creditPlanet;

    private void Start() 
    {
        menuManager = MenuManager.instance;    
        creditPlanet.SetActive(false);
    }

    public void ShowGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ShowMain() 
    {
        menuManager.CloseMenu("credits");
        menuManager.OpenMenu("main");
        menuPlanet.SetActive(true);
        creditPlanet.SetActive(false);
    } 
    
    public void ShowCredit()
    {
        menuManager.CloseMenu("main");
        menuManager.OpenMenu("credits");
        menuPlanet.SetActive(false);
        creditPlanet.SetActive(true);
    }

    public void ShowPlanetGenerator()
    {
        Application.OpenURL("https://deep-fold.itch.io/pixel-planet-generator");
    }
    

    public void ShowQuit()
    {
        // TODO spawn error console to yell at player to alt+f4
        
        // yes we have the code to actually quit and it will never run, 
        // but thats not that fun isn't it
#if FALSE  
        // If we are running in a standalone build of the game
#if UNITY_STANDALONE
        // Quit the application
        Application.Quit();
#endif
        // If we are running in the editor
#if UNITY_EDITOR
        // Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
#endif
    }
}
