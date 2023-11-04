using FPS.Manager;
using FPS.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepManager : MonoBehaviour
{
    public bool isAI;

    PlayerController player;
    AudioSource audio;
    [SerializeField] AudioClip concreteStep;
    [SerializeField] Transform[] feetBones;
    RaycastHit hit;
    [SerializeField] float range = 0.2f;
    void Start()
    {
        audio = GetComponent<AudioSource>();

        if (isAI) return;
        player = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAI) return;
        CheckGround();
    }

    private void CheckGround()
    {
        if (player.curSpeed <= 1) return;
        if (audio.isPlaying) return;
        foreach (Transform t in feetBones)
        {
            if (Physics.Raycast(t.position, Vector3.up * - 1, out hit, range))
            {
                if (hit.collider.CompareTag("Concrete"))
                {
                    PlaySound(concreteStep);
                }
            }
        }
    }

    private void PlaySound(AudioClip clip)
    {
        audio.pitch = Random.Range(0.8f, 1.0f);
        audio.PlayOneShot(clip);
    }

    public void PlayFootStep()
    {
        if (Physics.Raycast(transform.position, Vector3.up * -1, out hit, range))
        {
            if (hit.collider.CompareTag("Concrete"))
            {
                PlaySound(concreteStep);
            }
        }
    }
}
