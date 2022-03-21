using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject boss;
    [SerializeField] string nextLevelName;

    ScoreManager scoreManager;
    AttackHandler attackHandler;
    bool shouldContinue;

    // Cache components and assign boolean values
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        attackHandler = GameObject.Find("AttackHandler").GetComponent<AttackHandler>();
        shouldContinue = true;
    }

    // Run advance player and next scene check
    void Update()
    {
        AdvancePlayer();
        CheckNextScene();
    }

    // Check if player should advance position and do so if necessary
    void AdvancePlayer()
    {
        if (attackHandler.CheckEnemies())
            return;
        if (!shouldContinue)
            return;

        player.transform.Translate(35, 0, 0);
        shouldContinue = false;
        attackHandler.enemies[0] = boss;
    }

    // Check if boss has died, if so save the tracked scores to player prefs and load next scene
    void CheckNextScene()
    {
        if (boss != null)
            return;

        scoreManager.levelsCleared++;
        PlayerPrefs.SetInt("TotalEnemies", scoreManager.enemiesDefeated);
        PlayerPrefs.SetInt("LevelsCleared", scoreManager.levelsCleared);
        SceneManager.LoadScene(nextLevelName);

    }
}
