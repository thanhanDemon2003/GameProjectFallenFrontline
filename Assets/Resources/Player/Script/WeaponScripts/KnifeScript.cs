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

    private Transform _cam;

    private void Awake()
    {
        _cam = Camera.main.transform;
    }

    public void Slash()
    {
        RaycastHit hit;
        if (Physics.SphereCast(_cam.position, 0.5f, _cam.forward, out hit, maxRange, hitLayer))
        {
            

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            TargetScript target = hit.transform.GetComponentInParent<TargetScript>();

            if (target != null)
            {
                target.TakeDamage(damage);
                Zombie zombie = hit.collider.GetComponentInParent<Zombie>();

                if (zombie != null)
                {
                    if (zombie._currentState != Zombie.ZombieState.Ragdoll &&
                        zombie._currentState != Zombie.ZombieState.Dead)
                    {
                        //zombie._currentState = Zombie.ZombieState.Ragdoll;
                        zombie._animator.SetTrigger("Stumble");
                        return;
                    }

                    Vector3 forceDirection = zombie.transform.position - Camera.main.transform.position;
                    forceDirection.y = 1;
                    forceDirection.Normalize();

                    Vector3 force = 50 * forceDirection;

                    zombie.TriggerRagdoll(force, hit.point);
                }
            }

            else if (hit.collider.gameObject.CompareTag("Wall"))
            {

            }
            else if (hit.collider.gameObject.CompareTag("Destructable"))
            {
                hit.transform.gameObject.GetComponent<MeshDestroy>().DestroyMesh();
            }
        }

    }

}
