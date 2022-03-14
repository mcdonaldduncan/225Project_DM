using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCollision : MonoBehaviour
{
    [SerializeField] Material medHealth;
    [SerializeField] Material lowHealth;
    [SerializeField] int health;

    ScoreManager ScoreManager;

    GameObject healthBar;

    Vector3 healthScale;
    
    int startingHealth;

    // Assign value of starting health and cache healthbar gameobject for reference
    private void Start()
    {
        startingHealth = health;
        healthBar = transform.GetChild(0).gameObject;
        healthScale = healthBar.transform.localScale;
        ScoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // On collision, reduce health by one and scale health bar to reflect change
    private void OnCollisionEnter(Collision collision)
    {
        health--;
        ScaleHealthBar();
        if (health <= 0)
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("Enemy"))
            {
                ScoreManager.enemiesDefeated++;
            }
        }
    }

    // Scale and color health bar based off remaining health compared to starting health
    void ScaleHealthBar()
    {
        float healthBarZ = (float)health / (float)startingHealth * 2;

        healthBar.transform.localScale = new Vector3(healthScale.x, healthScale.y, healthBarZ);

        if (health <= (float)startingHealth / 3f)
        {
            healthBar.GetComponent<MeshRenderer>().material = lowHealth;
        }
        else if (health <= (float)startingHealth / 3f * 2f)
        {
            healthBar.GetComponent<MeshRenderer>().material = medHealth;
        }
    }
}
