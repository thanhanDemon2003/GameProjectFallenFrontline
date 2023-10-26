
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float health =100;
    public float enemiesDmg;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void TakeDamage (float amount)
    {
        health -= amount;
    }
}
