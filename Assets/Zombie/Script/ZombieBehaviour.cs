using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieBehaviour : MonoBehaviour
{
    [SerializeField] Zombie m_Zombie;
    [SerializeField] TargetScript target;

    private NavMeshAgent agent;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FollowPlayer()
    {
        agent.SetDestination(player.transform.position);
    }




}
