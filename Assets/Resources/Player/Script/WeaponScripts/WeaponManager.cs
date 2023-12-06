using FPS.Manager;
using FPS.Player;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class WeaponManager : MonoBehaviour
{
    private Animator animator;
    private int pistolAnimatorLayer, smgAnimatorLayer;


    [SerializeField] GameObject pistolCam;
    [SerializeField] GameObject pistolModel;
    [SerializeField] Animator pistolAnimator;

    [SerializeField] GameObject smglCam;
    [SerializeField] GameObject smgModel;
    [SerializeField] Animator smgAnimator;

    public PlayerController player;
    public InputManager input;

    public bool flashLightEquip = false;
    private bool buttonPressed = false;
    [SerializeField] GameObject FlashLight;


    public float unAimFOV = 68;
    public float AimFOV = 55;

    public int primaryAmmo;
    public int secondaryAmmo;
    public TextMeshProUGUI addAmmoText;
    void Start()
    {
        animator = GetComponent<Animator>();
        pistolAnimatorLayer = animator.GetLayerIndex("Pistol_Layer");
        smgAnimatorLayer = animator.GetLayerIndex("SMG_Layer");

    }

    // Update is called once per frame
    void Update()
    {
        switch (player.state)
        {
            case PlayerController.State.Primary:
                StartCoroutine(SetSMG());
                return;

            case PlayerController.State.Secondary:
                StartCoroutine(SetSecondary());
                return;

            case PlayerController.State.Unarmed:
                StartCoroutine(Setunarmed());
                return;
        }
    }

    private void FixedUpdate()
    {
        EquipFLash();
    }

    private IEnumerator Setunarmed()
    {
        pistolAnimator.SetBool("Equip", false);
        animator.SetBool("PistolEquip", false);

        animator.SetBool("SMGEquip", false);
        smgAnimator.SetBool("Equip", false);

        yield return new WaitForSeconds(0.5f);
        animator.SetLayerWeight(pistolAnimatorLayer, 0f);
        pistolCam.SetActive(false);
        pistolModel.SetActive(false);


        smgModel.SetActive(false);
        smglCam.SetActive(false);
        animator.SetLayerWeight(smgAnimatorLayer, 0f);

    }
    private IEnumerator SetSMG()
    {
        pistolAnimator.SetBool("Equip", false);
        animator.SetBool("PistolEquip", false);

        yield return new WaitForSeconds(0.5f);

        pistolCam.SetActive(false);
        animator.SetLayerWeight(pistolAnimatorLayer, 0f);
        pistolModel.SetActive(false);

        animator.SetBool("SMGEquip", true);
        smglCam.SetActive(true);
        animator.SetLayerWeight(smgAnimatorLayer, 1f);
        smgModel.SetActive(true);
    }
    private IEnumerator SetSecondary()
    {
        //disable smg
        animator.SetBool("SMGEquip", false);
        smgAnimator.SetBool("Equip", false);
        yield return new WaitForSeconds(0.5f);

        //set pistol
        smgModel.SetActive(false);
        smglCam.SetActive(false);
        animator.SetLayerWeight(smgAnimatorLayer, 0f);

        animator.SetBool("PistolEquip", true);
        pistolCam.SetActive(true);
        animator.SetLayerWeight(pistolAnimatorLayer, 1f);
        pistolModel.SetActive(true);
    }

    private void EquipFLash()
    {
        if (input.Flash && !buttonPressed)
        {
            flashLightEquip = !flashLightEquip;
            buttonPressed = true;
        }

        if (!input.Flash)
        {
            buttonPressed = false;
        }

        FlashLight.SetActive(flashLightEquip);
    }

    public void AddAmmo(bool isPrimary)
    {
        if (isPrimary)
        {
            int ammoAdd = Random.RandomRange(10, 15);
            primaryAmmo += ammoAdd;
            StartCoroutine(Indicator("+" + ammoAdd + " SMG"));
        }
        else
        {
            int ammoAdd = Random.RandomRange(5, 15);
            secondaryAmmo += ammoAdd;
            StartCoroutine(Indicator("+" + ammoAdd + " Pistol"));
        }
    }

    private IEnumerator Indicator(string text)
    {
        addAmmoText.text = text;
        yield return new WaitForSeconds(2f);
        addAmmoText.text = "";
    }
}
