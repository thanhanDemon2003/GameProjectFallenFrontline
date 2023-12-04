using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSound : MonoBehaviour
{

    private AudioSource audioSource;

    public AudioClip[] zombieSound;
    public AudioClip[] deadSound;

    Zombie zombie;

    private float count = 5;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        zombie = GetComponentInParent<Zombie>();

    }

    // Update is called once per frame
    void Update()
    {
        if (zombie._isAlive)
        {
            Timer();
        }
        else
        {
            playZombieSound(deadSound);
            this.enabled = false;
        }
    }

    private void Timer()
    {
        if (count > 0)
        {
            count -= Time.deltaTime;
        }

        if (count <= 0)
        {
            playZombieSound(zombieSound);
            count = Random.RandomRange(5, 10);
        }
    }

    private void playZombieSound(AudioClip[] clip)
    {
        if (zombie.RandomChance() > 5)
        {
            audioSource.PlayOneShot(clip[Random.RandomRange(0, clip.Length)]);
        }
    }
}
