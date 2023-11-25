using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [Header("Checking Enemy")]
    [SerializeField] Transform player;
    [SerializeField] float range;
    [SerializeField] LayerMask layer;

    public bool inCombat;

    [Header("Sound Properties")]
    [SerializeField] AudioSource ambient;
    [SerializeField] AudioSource action;

    [SerializeField] float volume;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckEnemy();
        setMusic();
    }

    private void setMusic()
    {

        if (inCombat)
        {
            volume += 0.2f * Time.deltaTime;
        }
        else
        {
            volume -= 0.2f * Time.deltaTime;
        }

        if (volume < 0f) volume = 0f;
        if (volume > 0.6f) volume = 0.6f;

        action.volume = volume;
    }

    private void CheckEnemy()
    {
        Collider[] hitCollider = Physics.OverlapSphere(player.position, range, layer);
        if (hitCollider.Length > 30)
        {
            inCombat = true;
        }
        if (hitCollider.Length < 10)
        {
            inCombat = false;
        }

        Debug.Log(hitCollider.Length);
    }
}
