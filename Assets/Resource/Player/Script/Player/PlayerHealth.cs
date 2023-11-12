using FPS.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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


    [SerializeField] GameObject HitVFX;
    private Transform mainCamera;
    private float xRotation;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        mainCamera = Camera.main.transform;
    }

    private void Update()
    {
        if (currentHP <= 0f)
        {
            xRotation = Mathf.Lerp(mainCamera.localRotation.x, 0f, 2 * Time.deltaTime);
            Dead();
            mainCamera.localRotation = Quaternion.Euler(xRotation, 0, 0);
            animator.SetBool("PistolEquip", false);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHP -= amount;
        Debug.Log(">>> Player HP: " + currentHP);
        animator.Play("Hit");
        Destroy(Instantiate(HitVFX), 2f);
    }

    public void Dead()
    {
        player.state = PlayerController.State.Unarmed;
        cameraArm.SetActive(false);
        animator.SetTrigger("Dead");
        player.canControl = false;
        transform.gameObject.layer = LayerMask.NameToLayer("Default");
    }

}
