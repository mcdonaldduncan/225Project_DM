using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    AttackHandler attackHandler;

    // Cache attack handler component
    void Start()
    {
        attackHandler = GameObject.Find("AttackHandler").GetComponent<AttackHandler>();
    }

    // Invoke on button press, set player option to heal
    public void SetHeal()
    {
        attackHandler.isHealing = true;
    }

    // Invoke on button press, set player option to attack
    public void SetAttacking()
    {
        attackHandler.isHealing = false;
    }

    // Invoke on button press, load main menu
    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
