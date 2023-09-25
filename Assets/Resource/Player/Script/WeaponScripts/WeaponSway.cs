using FPS.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    public InputManager inputManager;

    [SerializeField] float smooth;
    [SerializeField] float multiplier;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = inputManager.Look.x * multiplier;
        float mouseY = inputManager.Look.y * multiplier;

        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion targetRotate = rotationX * rotationY;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotate, smooth*Time.deltaTime);
    }
}
