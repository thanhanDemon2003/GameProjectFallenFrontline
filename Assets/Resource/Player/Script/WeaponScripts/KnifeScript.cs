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

            TargetScript target = hit.transform.GetComponentInParent<TargetScript>();

            if (target != null)
            {
                target.TakeDamage(damage * 5);
                Zombie zombie = hit.collider.GetComponentInParent<Zombie>();

                if (zombie != null)
                {
                    Vector3 forceDirection = zombie.transform.position - Camera.main.transform.position;
                    forceDirection.y = 1;
                    forceDirection.Normalize();

                    Vector3 force = 50 * forceDirection;

                    zombie.TriggerRagdoll(force, hit.point);


                }
            }

            else if (hit.collider.gameObject.CompareTag("Wall"))
            {
                Debug.Log(">>> Knife Wall");
            }
            else if (hit.collider.gameObject.CompareTag("Destructable"))
            {
                hit.transform.gameObject.GetComponent<MeshDestroy>().DestroyMesh();
            }
        }

    }

}
