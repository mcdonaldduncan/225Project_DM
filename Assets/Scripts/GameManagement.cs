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
    EntityCollision playerStats;
    bool shouldContinue;

    // Cache components and assign boolean values
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        attackHandler = GameObject.Find("AttackHandler").GetComponent<AttackHandler>();
        shouldContinue = true;

        // Cache playerstats components and assign player health based on persistent value
        playerStats = player.GetComponent<EntityCollision>();
        playerStats.health = PlayerPrefs.GetInt("CurrentHealth");
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

        //Vector3 offsetVector = player.transform.position + new Vector3(35, 0, 0);
        //float step = Time.deltaTime * 2;
        //player.transform.position = Vector3.MoveTowards(player.transform.position, offsetVector, step);

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

        // Set persistent values
        PlayerPrefs.SetInt("TotalEnemies", scoreManager.enemiesDefeated);
        PlayerPrefs.SetInt("LevelsCleared", scoreManager.levelsCleared);
        PlayerPrefs.SetInt("CurrentHealth", playerStats.health);

        // Load next scene
        SceneManager.LoadScene(nextLevelName);

    }
}
