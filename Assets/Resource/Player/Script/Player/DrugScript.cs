using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DrugScript : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerUseArm playerArm;
    public void Healing()
    {
        playerHealth.currentHP += 50;
        playerArm.currentPotion--;
        Debug.Log(">>> Healling");
    }
}
