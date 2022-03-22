using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityCollision : MonoBehaviour
{
    [SerializeField] Material medHealth;
    [SerializeField] Material lowHealth;
    [SerializeField] Material highHealth;
    [SerializeField] public int health;
    [SerializeField] int startingHealth;

    ScoreManager scoreManager;
    GameManagement gameManagement;

    GameObject healthBar;
    MeshRenderer healthRend;

    Vector3 healthScale;

    // Assign value of starting health and cache healthbar gameobject for reference
    private void Start()
    {
        healthBar = transform.GetChild(0).gameObject;
        healthRend = healthBar.GetComponent<MeshRenderer>();
        healthScale = healthBar.transform.localScale;
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        gameManagement = GameObject.Find("GameManager").GetComponent<GameManagement>();
        ScaleHealthBar();
    }

    // On collision, reduce health by one and scale health bar to reflect change
    private void OnCollisionEnter(Collision collision)
    {
        health--;
        ScaleHealthBar();
        if (health > 0)
            return;

        // Increment enemies defeated if gameobject is an enemy
        if (gameObject.CompareTag("Enemy"))
        {
            scoreManager.enemiesDefeated++;
            Destroy(gameObject);
        }
        // Set gameover to true if gameobject is player
        if (gameObject.CompareTag("Player"))
        {
            gameManagement.gameOver = true;
        }
        
    }

    // Scale and color health bar based off remaining health compared to starting health
    public void ScaleHealthBar()
    {
        float healthBarZ = (float)health / (float)startingHealth * 2;

        healthBar.transform.localScale = new Vector3(healthScale.x, healthScale.y, healthBarZ);

        if (health <= (float)startingHealth / 3f)
        {
            healthRend.material = lowHealth;
        }
        else if (health <= (float)startingHealth / 3f * 2f)
        {
            healthRend.material = medHealth;
        }
        else
        {
            healthRend.material = highHealth;
        }
    }
}
