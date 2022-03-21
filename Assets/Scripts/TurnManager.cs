using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [System.NonSerialized] public bool isPlayerTurn;

    void Start()
    {
        isPlayerTurn = true;
    }

}
