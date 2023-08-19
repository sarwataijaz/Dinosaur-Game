using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioBeep : MonoBehaviour
{
    private AudioSource audioSource;
    public float volume;
    private bool completePlaying = false;
    public GameObject setActive;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void playAudio()
    {
        if (audioSource.isPlaying)
        {
            // Do nothing while audio is playing
        }
        else if (!completePlaying)
        {
            completePlaying = true;
            audioSource.volume = volume;
            audioSource.Play();
            setActive.SetActive(false);
        }
    }
}

