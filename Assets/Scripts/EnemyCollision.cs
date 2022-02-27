using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] Material medHealth;
    [SerializeField] Material lowHealth;

    private GameObject healthBar;

    private Vector3 healthScale;

    private int health;
    private int startingHealth;

    private void Start()
    {
        health = 5;
        startingHealth = health;
        healthBar = transform.GetChild(0).gameObject;

        healthScale = healthBar.transform.localScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        health--;
        ScaleHealthBar();
        if (health <= 0)
            Destroy(gameObject);
        
    }

    void ScaleHealthBar()
    {
        float healthBarZ = ((float)health / (float)startingHealth) * 2;

        healthBar.transform.localScale = new Vector3(healthScale.x, healthScale.y, healthBarZ);

        if (health <= (float)startingHealth / 3)
        {
            healthBar.GetComponent<MeshRenderer>().material = lowHealth;
        }
        else if (health <= (float)startingHealth / 3 * 2)
        {
            healthBar.GetComponent<MeshRenderer>().material = medHealth;
        }
    }
}
