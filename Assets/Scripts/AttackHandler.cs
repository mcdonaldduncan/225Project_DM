using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    [SerializeField] GameObject attackPrefab;
    [SerializeField] float attackSpeed;

    SelectionHandler selectionHandler;
    GameObject attackGameObject;

    Vector3 startPosition;

    void Start()
    {
        selectionHandler = GameObject.Find("SelectionHandler").GetComponent<SelectionHandler>();
        startPosition = attackPrefab.transform.position;
    }

    void Update()
    {
        LaunchAttack();
        MoveAttack();
    }

    void LaunchAttack()
    {
        if(selectionHandler.selection == null)
            return;

        if (!Input.GetKeyDown(KeyCode.Space))
            return;

        
        attackGameObject = Instantiate(attackPrefab);
        attackGameObject.transform.position = startPosition;
    }

    void MoveAttack()
    {
        if (attackGameObject == null)
            return; 

        float step = attackSpeed * Time.deltaTime;
        attackGameObject.transform.position = Vector3.MoveTowards(attackGameObject.transform.position, selectionHandler.selection.transform.position, step);

    }

}
