using FPS.Manager;
using FPS.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    public GameObject Knife, Gun;
    public Animator knifeAnimator;

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
    }

    private void KnifeUse()
    {
        if (inputManager.Knife && !buttonPressed)
        {
            Knife.SetActive(true);
        }

        Gun.SetActive(!AnimCheck(knifeAnimator, "Knife"));
        Knife.SetActive(AnimCheck(knifeAnimator, "Knife"));
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
