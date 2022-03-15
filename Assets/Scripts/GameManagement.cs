using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    [SerializeField] GameObject player;

    AttackHandler attackHandler;

    // Start is called before the first frame update
    void Start()
    {
        attackHandler = GameObject.Find("AttackHandler").GetComponent<AttackHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AdvancePlayer()
    {
        if (!attackHandler.CheckEnemies())
            return;

        player.transform.Translate(20, 0, 0);
        
    }
}
