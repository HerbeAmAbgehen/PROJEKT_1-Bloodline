using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string scene;

    public GameObject InteractionText;

    private bool PlayerCollision;
    private void Start()
    {
        InteractionText.SetActive(false);
        PlayerCollision = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        InteractionText.SetActive(true);
        PlayerCollision = true;

    }

    private void OnTriggerExit(Collider collider)
    {
        InteractionText.SetActive(false);
        PlayerCollision = false;
    }

    private void Update()
    {
        if (PlayerCollision && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(scene);
        }
    }
}
