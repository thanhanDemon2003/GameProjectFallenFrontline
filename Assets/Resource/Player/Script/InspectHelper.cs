using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class InspectHelper : MonoBehaviour
{
    public bool ShowArm;
    public bool PlayerShadow;
    [SerializeField] SkinnedMeshRenderer[] meshArm;

    [SerializeField] SkinnedMeshRenderer[] meshPlayer;
    [SerializeField] GameObject weaponRoot;

    [Range(0, 1)]
    public float IKWeight;
    // Update is called once per frame
    void Update()
    {
        EnablePlayerShadow();
    }

    private void EnableArms()
    {
        if (ShowArm)
        {
            foreach (var renderer in meshArm)
            {
                renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            }
            return;
        }

        foreach (var renderer in meshArm)
        {
            renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
        }
    }


    private void EnablePlayerShadow()
    {
        if (PlayerShadow)
        {
            foreach (var renderer in meshPlayer)
            {
                renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            }
            weaponRoot.SetActive(true);
            return;
        }

        foreach (var renderer in meshArm)
        {
            renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        }
        weaponRoot.SetActive(false);
    }
}
