using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudioPitch : MonoBehaviour
{
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio= GetComponent<AudioSource>();
        audio.pitch = Random.Range(0.8f, 1.2f);
    }
}
