using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //  This will be modified after save and load game systems are added
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public void QuitGame()
    {
        //Application.Quit();   Will be activated before building the game

        Debug.Log("Nigger Out");
    }
}
