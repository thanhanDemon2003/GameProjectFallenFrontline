using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{

    [Header("Ammo Atribute")]
    public bool primaryAmmo;
    void Start()
    {
    }

    public void Interact()
    {
        if (gameObject.CompareTag("Gas"))
        {
            MapObjective objective = GameObject.FindGameObjectWithTag("Objective").GetComponent<MapObjective>();
            if (objective.AddGas())
            {
                Destroy(gameObject);
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Painkiller"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponentInChildren<PlayerUseArm>().currentPotion += 1;
                Destroy(gameObject);
            }
        }
    }


}
