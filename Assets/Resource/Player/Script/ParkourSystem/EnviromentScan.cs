using FPS.Manager;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class EnviromentScan : MonoBehaviour
{
    [Header("Parkua Scan")]
    [SerializeField] Transform hipPoint;
    [SerializeField] float distance = 0.8f;
    [SerializeField] float heightLenght = 5f;
    [SerializeField] LayerMask obstacleLayer;

    [Header("Camera Scan")]
    [SerializeField] LayerMask hitLayer;
    [SerializeField] TextMeshProUGUI actionText;
    private Camera _cam;
    RaycastHit hit;

    private InputManager input;
    private bool pressed;
    WeaponManager weapon;
    public ObstacleHitData ObstacleCheck()
    {
        var hitData = new ObstacleHitData();
        RaycastHit hitInfo;
        hitData.forwardHitFound = Physics.Raycast(hipPoint.position, hipPoint.forward, out hitData.forwardHitInfo, distance, obstacleLayer);

        Debug.DrawRay(hipPoint.position, hipPoint.forward * distance, (hitData.forwardHitFound) ? Color.red : Color.white);


        if (hitData.forwardHitFound)
        {
            var heightOrigin = hitData.forwardHitInfo.point + Vector3.up * heightLenght;
            hitData.heightHitFound = Physics.Raycast(heightOrigin, Vector3.down, out hitData.heightHitInfo, obstacleLayer);

            Debug.DrawRay(heightOrigin, Vector3.down * heightLenght, (hitData.heightHitFound) ? Color.red : Color.white);

        }
        return hitData;
    }



    private void Start()
    {
        _cam = Camera.main;
        input = GetComponent<InputManager>();
        weapon= GetComponent<WeaponManager>();
    }

    private void Update()
    {
        Interaction();
    }
    private bool ForwardScan()
    {
        return Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, 8, hitLayer);
    }

    private void Interaction()
    {
        if (!ForwardScan())
        {
            actionText.SetText("");
            return;
        }

        if (hit.collider.gameObject.CompareTag("Gas"))
        {
            actionText.SetText("E - Pick Up");

            if (input.Interact && !pressed)
            {
                hit.collider.gameObject.GetComponent<ObjectPickup>().Interact();
                pressed = true;
            }

            if (!input.Interact) pressed = false;

        }

        else if (hit.collider.gameObject.CompareTag("Ammo"))
        {
            actionText.SetText("E - Pick Up");

            if (input.Interact && !pressed)
            {
                bool isPrimary = hit.collider.gameObject.GetComponent<ObjectPickup>().primaryAmmo;
                weapon.AddAmmo(isPrimary);
                Destroy(hit.collider.gameObject);
                pressed = true;
            }

            if (!input.Interact) pressed = false;
        }


        else if (hit.collider.gameObject.CompareTag("Generator"))
        {
            actionText.SetText("E - Fill Up");
            if (input.Interact && !pressed)
            {
                hit.collider.gameObject.GetComponentInParent<MapObjective>().UseGas();
                pressed = true;
            }

            if (!input.Interact) pressed = false;
        }

        else if (hit.collider.gameObject.CompareTag("Car"))
        {
            actionText.SetText("E - Leave");
            if (input.Interact && !pressed)
            {
                hit.collider.gameObject.GetComponentInParent<MapObjective>().FinisheGame();
                pressed = true;
            }

            if (!input.Interact) pressed = false;
        }
    }
}

public struct ObstacleHitData
{
    public bool forwardHitFound;
    public bool heightHitFound;
    public RaycastHit forwardHitInfo;
    public RaycastHit heightHitInfo;
}
