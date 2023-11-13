using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocCaseScript : MonoBehaviour
{
    public float interactionRange = 3f; 
    public LayerMask interactableLayer; 
    public Mission1Script gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<Mission1Script>();
    }

    private void Update()
    {      
        Vector3 playerPosition = transform.position;
        Vector3 forward = transform.forward;
        RaycastHit hit;

        if (Physics.Raycast(playerPosition, forward, out hit, interactionRange, interactableLayer))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("DocCase"))
            {
                Debug.Log(">>> DocCase!");         
                    gameManager.CollectDocument(); 
                    Destroy(hit.collider.gameObject);
            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("ExitPoint"))
            {
                Debug.Log(">>> ExitPoint!");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    gameManager.TryExit();
                }
            }
        }
    }
}
