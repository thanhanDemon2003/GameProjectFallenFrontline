
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float health =100;
    public float enemiesDmg;
    public void TakeDamage (float amount)
    {
        health -= amount;
    }
}
