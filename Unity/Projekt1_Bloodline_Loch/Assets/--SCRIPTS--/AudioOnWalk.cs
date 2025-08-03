using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class AudioOnWalk : MonoBehaviour
{
    public AudioSource PlayerAudio;

    public FirstPersonController PlayerFPS;

    public AudioClip DefaultSteps;

    public AudioClip WetSteps;

    public AudioClip WaterSteps;

    public AudioClip RockSteps;

    public AudioClip WoodSteps;

    public AudioClip DirtSteps;

    private bool AudioIsPlaying;

    private bool changedSteps;

    private float DefaultPitch;

    private float HighPitch;

    private void Start()
    {
        DefaultPitch = PlayerAudio.pitch;
        HighPitch = DefaultPitch * 1.55f;
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && PlayerFPS.Grounded && !AudioIsPlaying)
        {
            AudioIsPlaying = true;
            PlayerAudio.Play();
            Debug.Log("Audio Plays");
        }
        else if(!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) || !PlayerFPS.Grounded)
        {
            AudioIsPlaying = false;
            PlayerAudio.Stop();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            PlayerAudio.pitch = HighPitch;
        }
        else
        {
            PlayerAudio.pitch = DefaultPitch;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("GroundWet") && !changedSteps)
        {
            PlayerAudio.clip = WetSteps;
            PlayerAudio.Play();
        }
        if (other.CompareTag("GroundWater") && !changedSteps)
        {
            PlayerAudio.clip = WaterSteps;
            PlayerAudio.Play();
        }
        if (other.CompareTag("GroundRock") && !changedSteps)
        {
            PlayerAudio.clip = RockSteps;
            PlayerAudio.Play();
        }
        if (other.CompareTag("GroundWood") && !changedSteps)
        {
            PlayerAudio.clip = WoodSteps;
            PlayerAudio.Play();
        }
        if (other.CompareTag("GroundDirt") && !changedSteps)
        {
            PlayerAudio.clip = DirtSteps;
            PlayerAudio.Play();
        }

        changedSteps = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (PlayerAudio.clip != DefaultSteps)
        {
            PlayerAudio.clip = DefaultSteps;
            PlayerAudio.Play();
            changedSteps = false;
        }

    }
}
