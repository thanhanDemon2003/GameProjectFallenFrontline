using FPS.Manager;
using FPS.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private Animator animator;
    private PistolScript pistol;
    private int pistolAnimatorLayer, smgAnimatorLayer;


    [SerializeField] GameObject pistolCam;
    [SerializeField] GameObject pistolModel;
    [SerializeField] Animator pistolAnimator;

    [SerializeField] GameObject smglCam;
    [SerializeField] GameObject smgModel;
    [SerializeField] Animator smgAnimator;

    public PlayerController player;

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
        }
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


}
