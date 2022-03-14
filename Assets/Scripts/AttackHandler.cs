using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject attackPrefab;
    [SerializeField] GameObject enemyAttackPrefab;
    [SerializeField] GameObject player;
    [SerializeField] float attackSpeed;
    [SerializeField] float attackDelay;

    [System.NonSerialized] public bool isAttacking;

    SelectionHandler selectionHandler;
    TurnManager turnManager;

    GameObject playerAttackGameObject;
    GameObject enemyAttackGameObject;

    Vector3 playerAttackPosition;
    Vector3 enemyAttackPosition;

    float xOffset = 1f;

    void Start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        selectionHandler = GameObject.Find("SelectionHandler").GetComponent<SelectionHandler>();
    }

    void Update()
    {
        LaunchPlayerAttack();
        LaunchEnemyAttack();
    }

    private void FixedUpdate()
    {
        MovePlayerAttack();
        MoveEnemyAttack();
    }

    // Check for a selection, check turn, check key input, check attack currently flying. If all pass, flip turn, set attacking to true and launch player attack
    void LaunchPlayerAttack()
    {
        if(selectionHandler.selection == null)
            return;
        if (!turnManager.isPlayerTurn)
            return;
        if (!Input.GetKeyDown(KeyCode.Space))
            return;
        if (isAttacking)
            return;

        turnManager.isPlayerTurn = false;
        isAttacking = true;
        playerAttackPosition = new Vector3(player.transform.position.x + xOffset, player.transform.position.y, player.transform.position.z);
        playerAttackGameObject = Instantiate(attackPrefab);
        playerAttackGameObject.transform.position = playerAttackPosition;
    }

    // Move player attack towards selected enemy
    void MovePlayerAttack()
    {
        if (playerAttackGameObject == null)
            return; 

        float step = attackSpeed * Time.deltaTime;
        playerAttackGameObject.transform.position = Vector3.MoveTowards(playerAttackGameObject.transform.position, selectionHandler.selection.transform.position, step);

    }

    // Move enemy attack towards player
    void MoveEnemyAttack()
    {
        if (enemyAttackGameObject == null)
            return;

        float step = attackSpeed * Time.deltaTime;
        enemyAttackGameObject.transform.position = Vector3.MoveTowards(enemyAttackGameObject.transform.position, player.transform.position, step);
    }

    // Initial MoveAttack method to reduce redundant code, null reference errors when passing in gameobject that was not instantiated. Will change later to be implemented after a null check
    // Unused
    void MoveAttack(GameObject attack, Transform target)
    {
        if (attack == null)
            return;

        float step = attackSpeed * Time.deltaTime;
        attack.transform.position = Vector3.MoveTowards(attack.transform.position, target.position, step);
    }

    // Check enemies to see if any are not null, if all enemies are null return false
    bool CheckEnemies()
    {
        foreach (var enemy in enemies)
        {
            if (enemy != null)
            {
                return true;
            }
        }
        return false;
    }

    // Generate a random index to select an enemy attacker.
    int ChooseAttackerIndex()
    {
        int index;
        index = Random.Range(0, enemies.Length);

        // If the current index results in a null gameobject select a new index, repeat until non null index is found
        // Do not use without first checking enemies with CheckEnemies(), will result in infinite recursion crash
        if (enemies[index] == null)
        {
            return ChooseAttackerIndex();
        }
        return index;
    }

    // Instantiate enemy attack after delay
    IEnumerator EnemyAttackDelay(float delay, int index)
    {
        yield return new WaitForSeconds(delay);
        
        enemyAttackGameObject = Instantiate(enemyAttackPrefab);
        enemyAttackGameObject.transform.position = enemyAttackPosition;
    }

    // Check playerturn, check isAttacking and check for non null enemies before flipping turn and starting delayed attack
    void LaunchEnemyAttack()
    {
        if (turnManager.isPlayerTurn)
            return;
        if (isAttacking)
            return;
        if (!CheckEnemies())
            return;

        // If there are still non null enemies in enemies choose an index that has a non null enemy
        int index = ChooseAttackerIndex();
        turnManager.isPlayerTurn = true;
        isAttacking = true;
        enemyAttackPosition = new Vector3(enemies[index].transform.position.x - xOffset, enemies[index].transform.position.y, enemies[index].transform.position.z);
        StartCoroutine(EnemyAttackDelay(attackDelay, index));
    }

}
