using FPS.Manager;
using FPS.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseArm : MonoBehaviour
{
    public GameObject Knife, Gun, ArmHeal;
    public GameObject knifeRoot, gunRoot;
    public Animator knifeAnimator,healAnimator;
    public Animator modelAnimator;

    public InputManager inputManager;
    private bool buttonPressed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        KnifeUse();
        HealUse();
    }

    private void KnifeUse()
    {
        if (inputManager.Knife && !buttonPressed)
        {
            modelAnimator.SetTrigger("Knife");
            Knife.SetActive(true);
            buttonPressed = true;
            StartCoroutine(waitUse());
        }

        if (!inputManager.Knife) buttonPressed= false;

        Gun.SetActive(!AnimCheck(knifeAnimator, "Knife"));
        Knife.SetActive(AnimCheck(knifeAnimator, "Knife"));
        gunRoot.SetActive(!AnimCheck(knifeAnimator, "Knife"));
        knifeRoot.SetActive(AnimCheck(knifeAnimator, "Knife"));
    }

    IEnumerator waitUse()
    {
        yield return new WaitForSeconds(0.2f);
        modelAnimator.ResetTrigger("Knife");
    }

    private void HealUse()
    {
        if (inputManager.Heal && !buttonPressed)
        {
            ArmHeal.SetActive(true);
            buttonPressed = true;
        }

        if (!inputManager.Heal) buttonPressed = false;

        Gun.SetActive(!AnimCheck(healAnimator, "Heal"));
        ArmHeal.SetActive(AnimCheck(healAnimator, "Heal"));
    }

    private bool AnimCheck(Animator anim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }
}
