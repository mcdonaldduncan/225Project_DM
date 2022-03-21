using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Set PlayerPref values to 0 when the main menu initializes
    void Start()
    {
        PlayerPrefs.SetInt("TotalEnemies", 0);
        PlayerPrefs.SetInt("LevelsCleared", 0);
        PlayerPrefs.SetInt("CurrentHealth", 20);
    }

    // Method invoked by button click event to start game, load scene1
    public void StartGame()
    {
        SceneManager.LoadScene("Scene1");
    }
}
