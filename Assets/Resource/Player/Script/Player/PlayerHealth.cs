using FPS.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHP;
    public float currentHP;


    [Header("Dead animation")]

    [SerializeField] Animator animator;
    [SerializeField] PlayerController player;
    [SerializeField] GameObject model;
    [SerializeField] GameObject modelArm;
    [SerializeField] GameObject cameraArm;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    private void Update()
    {
        if (currentHP <= 0f)
        {
            Dead();
            animator.SetBool("PistolEquip", false);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHP -= amount;
        Debug.Log(">>> Player HP: " + currentHP);
       
    }

    public void Dead()
    {
        player.state = PlayerController.State.Unarmed;
        cameraArm.SetActive(false);
        model.SetActive(false);
        animator.Play("Dead");
        player.canControl= false;
    }

}
