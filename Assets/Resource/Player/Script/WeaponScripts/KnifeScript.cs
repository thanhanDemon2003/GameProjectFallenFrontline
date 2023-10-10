using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour
{
    public Transform knifePivot;
    public float maxRange;
    public float damage;
    public int impactForce;
    public LayerMask hitLayer;


    public void Slash()
    {
            RaycastHit hit;
            if (Physics.Raycast(knifePivot.transform.position, knifePivot.transform.forward, out hit, maxRange, hitLayer))
            {
                Debug.DrawRay(knifePivot.transform.position, knifePivot.transform.forward * hit.distance, Color.green);
                Debug.Log(hit.transform.name);

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }

                TargetScript target = hit.transform.GetComponent<TargetScript>();

                if (target != null)
                {
                    target.TakeDamage(damage);
                    Debug.Log(">>> knife target");
                }

                else if (hit.collider.gameObject.CompareTag("Wall"))
                {
                    Debug.Log(">>> Knife Wall");
                }
                else
                {
                    Debug.Log(">>> Knife orther");
                }
            }

        }

    }
