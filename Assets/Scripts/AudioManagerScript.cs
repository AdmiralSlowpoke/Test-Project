using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
}
