using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string scene;

    public GameObject InteractionText;


    private void Start()
    {
        InteractionText.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        InteractionText.SetActive(true);
        

    }

    private void OnTriggerExit(Collider collider)
    {
        InteractionText.SetActive(false);
    }

    private void Update()
    {
        if (InteractionText.activeSelf == true && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(scene);
        }
    }
}
