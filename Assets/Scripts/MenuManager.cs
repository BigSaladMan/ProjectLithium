using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zone.Core.Utils;

public class MenuManager : Singleton<MenuManager>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayGame()
    {
        //SceneManager.LoadScene();
    }

    public void Credit()
    {
        //SceneManager.LoadScene();
    }
    public void QuitGame()
    {
        // TODO spawn error console to yell at player to alt+f4
    }   

}