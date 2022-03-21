using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] Text text;

    int totalEnemies;
    int totalLevels;

    // Store pref values, assign to text
    void Start()
    {
        totalEnemies = PlayerPrefs.GetInt("TotalEnemies");
        totalLevels = PlayerPrefs.GetInt("LevelsCleared");
        text.text = $"Results:\nEnemies Defeated: {totalEnemies}\nLevels Cleared: {totalLevels}";
    }

    // Method invoked on button click event to return to main menu
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitToDesktop()
    {
        Application.Quit();
    }
}
