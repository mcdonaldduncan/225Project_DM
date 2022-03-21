using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [System.NonSerialized] public int enemiesDefeated;
    [System.NonSerialized] public int levelsCleared;

    [SerializeField] Text enemyScore;
    [SerializeField] Text clearedScore;

    // Assign the values from PlayerPrefs to the tracked scores so they persist from previous level
    void Start()
    {
        enemiesDefeated = PlayerPrefs.GetInt("TotalEnemies");
        levelsCleared = PlayerPrefs.GetInt("LevelsCleared");
    }

    // Update the text display
    void Update()
    {
        DisplayScores();
    }

    // Assign values to text displays
    void DisplayScores()
    {
        enemyScore.text = $"Enemies Defeated: {enemiesDefeated}";
        clearedScore.text = $"Levels Cleared: {levelsCleared}";
    }
}
