using FPS.Manager;
using FPS.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    public InputManager inputManager;
    public PlayerController player;

    [Header("Sway")]
    [SerializeField] float smooth;
    [SerializeField] float multiplier;

    [Header("Bobbing")]
    public float speedCurve;
    float curveSin { get => Mathf.Sin(speedCurve); }
    float curveCos { get => Mathf.Cos(speedCurve); }

    public Vector3 travelLimit = Vector3.one * 0.025f;
    public Vector3 bobLimit = Vector3.one * 0.01f;
    Vector3 bobPosition;

    public float bobExaggeration;

    [Header("Bob Rotation")]
    public Vector3 multiplierBob;
    Vector3 bobEulerRotation;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Sway();

        if (inputManager.Aim)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            return;
        }
        BobOffset();
        BobRotation();
        CompositeRotation();
    }

    void Sway()
    {
        float mouseX = inputManager.Look.x * multiplier;
        float mouseY = inputManager.Look.y * multiplier;

        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion targetRotate = rotationX * rotationY;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotate, smooth * Time.deltaTime);
    }


    void BobOffset()
    {
        speedCurve += Time.deltaTime * (player.isOnGround ? (Input.GetAxis("Horizontal") + Input.GetAxis("Vertical")) * bobExaggeration : 1f) + 0.01f;

        bobPosition.x = (curveCos * bobLimit.x * (player.isOnGround ? 1 : 0)) - (inputManager.Move.x * travelLimit.x);
        bobPosition.y = (curveSin * bobLimit.y) - (Input.GetAxis("Vertical") * travelLimit.y);
        bobPosition.z = -(inputManager.Move.y * travelLimit.z);
    }

    void BobRotation()
    {
        bobEulerRotation.x = (inputManager.Move != Vector2.zero ? multiplierBob.x * (Mathf.Sin(2 * speedCurve)) : 0);
        bobEulerRotation.y = (inputManager.Move != Vector2.zero ? multiplierBob.y * curveCos : 0);
        bobEulerRotation.z = (inputManager.Move != Vector2.zero ? multiplierBob.z * curveCos * inputManager.Move.x : 0);
    }

    void CompositeRotation()
    {


        BobState();

        transform.localPosition =
            Vector3.Lerp(transform.localPosition, bobPosition, Time.deltaTime * smooth);

        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(bobEulerRotation), Time.deltaTime * smooth);
    }

    private void BobState()
    {
        if (inputManager.Run)
        {
            bobExaggeration = 10;
            return;
        }
        else if (player.isCrouching)
        {
            bobExaggeration = 2;
            return;
        }

        bobExaggeration = 5;
    }
}
