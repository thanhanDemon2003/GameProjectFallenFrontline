using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHP;
    public float currentHP;

    // Start is called before the first frame update
    void Start()
    {
        maxHP = 100f;
        currentHP = maxHP;
    }

    public void TakeDamage(float amount)
    {
        currentHP -= amount;
        Debug.Log(">>> Player HP: " + currentHP);
        if (currentHP <= 0f)
        {
            Debug.Log(">>> Player Die ");
            Debug.Log(">>> Play animation die");
        }
    }
}
