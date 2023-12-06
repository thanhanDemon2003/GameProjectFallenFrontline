using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using static UnityEngine.GraphicsBuffer;

public class ZombieAttack : MonoBehaviour
{
    Zombie zombie;
    private Transform player;
    public bool RotatetoPlayer;

    [SerializeField]
    float maxRange = 2.5f;

    [SerializeField]
    float damage = 10f;

    [SerializeField]
    LayerMask hitLayer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (RotatetoPlayer)
        {
            FaceToPlayer();
        }
    }

    public void FaceToPlayer()
    {
        Vector3 targetDirection = player.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 10f * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        Debug.Log(">>>>Face to player");
    }

    public void AttackNormal()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxRange, hitLayer))
        {
            PlayerHealth player = hit.collider.GetComponent<PlayerHealth>();

            if (player == null) return;
            player.TakeDamage(damage);
        }
    }
}
