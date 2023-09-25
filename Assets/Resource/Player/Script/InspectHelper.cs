using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class InspectHelper : MonoBehaviour
{
    public bool ShowArm;

    [SerializeField] SkinnedMeshRenderer[] mesh;

    // Update is called once per frame
    void Update()
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
