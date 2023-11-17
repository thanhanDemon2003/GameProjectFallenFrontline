using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocCaseScript : MonoBehaviour
{
    public float interactionRange = 4f; 
    public LayerMask interactableLayer;

    private void Start()
    {

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
                Debug.Log(">>> find Case");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Mission1Script.CollectDocument();
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
//chay thu coi
