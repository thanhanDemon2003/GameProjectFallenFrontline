using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InteractScript : MonoBehaviour
{
    public float interactionRange = 4f;
    public LayerMask interactableLayer;
    public TextMeshProUGUI interactionText;
    public bool interactable;

    private void Start()
    {
        interactionText.text = "";
        interactable = true;
    }

    private void Update()
    {
        Vector3 playerPosition = transform.position;
        Vector3 forward = transform.forward;
        RaycastHit hit;

        Debug.DrawRay(playerPosition, forward * interactionRange, Color.green);

        if (Physics.Raycast(playerPosition, forward, out hit, interactionRange, interactableLayer))
        {
            if (hit.collider.CompareTag("DocCase"))
            {
                Debug.DrawRay(playerPosition, forward * interactionRange, Color.red);
                interactionText.text = "Press E to interact";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Mission1Script.CollectDocument();
                    Destroy(hit.collider.gameObject);
                    interactionText.text = "";
                }
            }
            if (hit.collider.CompareTag("VirusSample"))
            {
                Debug.DrawRay(playerPosition, forward * interactionRange, Color.red);
                interactionText.text = "Press E to interact";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Mission1Script.CollectVirusSample();
                    Destroy(hit.collider.gameObject);
                    interactionText.text = "";
                }
            }
            if (hit.collider.CompareTag("ExitPoint"))
            {
                Debug.DrawRay(playerPosition, forward * interactionRange, Color.red);
                Mission1Script.TryExit();
            }
        }
        else
        {
            Debug.Log(">>> Other");
            interactionText.text = "";
        }
    }
}
