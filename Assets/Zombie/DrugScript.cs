using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugScript : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int maxPotion;
    public int currentPotion;

    // Start is called before the first frame update
    void Start()
    {
        maxPotion = 3;
        currentPotion = maxPotion;
    }

    public void Healing()
    {
        if(currentPotion > 0)
        {
            playerHealth.currentHP = playerHealth.maxHP;
            currentPotion --;
            Debug.Log(">>> Healling");
        }
    }
}
