using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetFootsteps : MonoBehaviour
{
    public AudioClip wetSteps;

    private AudioClip defaultClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            defaultClip = other.gameObject.GetComponent<AudioSource>().clip;
            other.gameObject.GetComponent<AudioSource>().clip = wetSteps;
            other.gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("Replaced sound");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<AudioSource>().clip = defaultClip;
            other.gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
