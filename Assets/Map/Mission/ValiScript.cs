using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValiScript : MonoBehaviour
{
    public float playerDistance = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, playerDistance))
        {
            Debug.Log("find player!");
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.green);
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                Debug.Log("Vali va chạm với người chơi.");
            }
        }
    }
}
