using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class InspectHelper : MonoBehaviour
{
    public bool ShowArm;
    [SerializeField] SkinnedMeshRenderer[] mesh;


    [Range(0, 1)]
    public float IKWeight;
    // Update is called once per frame
    void Update()
    {
        EnableArms();
    }

    private void EnableArms()
    {
        if (ShowArm)
        {
            foreach (var renderer in mesh)
            {
                renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            }
            return;
        }

        foreach (var renderer in mesh)
        {
            renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
        }
    }


}
