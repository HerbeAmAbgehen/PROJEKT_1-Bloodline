using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHeartbeat : MonoBehaviour
{
    public GameObject player;

    public GameObject Cat;

    private AudioSource Audio;

    private Vector3 Distance;

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Cat.transform.position - player.transform.position;

        Audio.pitch = Mathf.Clamp((1 * (10 / Distance.magnitude)), 0.5f, 2.3f);
    }
}
