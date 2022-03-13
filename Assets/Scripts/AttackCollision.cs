using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{
    AttackHandler attackHandler;

    private void Start()
    {
        attackHandler = GameObject.Find("AttackHandler").GetComponent<AttackHandler>();
    }

    // On collision destroy attack gameobject and reset isAttacking
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        attackHandler.isAttacking = false;
    }

}



