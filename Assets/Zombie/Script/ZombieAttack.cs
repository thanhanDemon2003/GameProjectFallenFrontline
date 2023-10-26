using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ZombieAttack : MonoBehaviour
{
    Zombie zombie;

    [SerializeField]
    float maxRange = 2.5f;

    [SerializeField]
    LayerMask hitLayer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void AttackNormal()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxRange, hitLayer))
        {
            PlayerHealth player = hit.collider.GetComponent<PlayerHealth>();

            if (player == null) return;
            player.TakeDamage(10f);
        }
    }
}
