using FPS.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAnimation : MonoBehaviour
{
    public InputManager input;

    
    public Animator ArmAnimator;
    private int AimLayerIndex;
    void Start()
    {
        AimLayerIndex = ArmAnimator.GetLayerIndex("Aim");
    }

    // Update is called once per frame
    void Update()
    {
        if (input.Aim)
        {
            Aim();
        }
        else
        {
            StartCoroutine(Unaim());
        }

    }

    private void Aim()
    {
        ArmAnimator.SetBool("Aim", true);
    }

    private IEnumerator Unaim()
    {
        ArmAnimator.SetBool("Aim", false);
        yield return new WaitForSeconds(1f);
    }
}
