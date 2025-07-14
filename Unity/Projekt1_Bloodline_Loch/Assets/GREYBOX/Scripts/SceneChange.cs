using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string scene;

    public GameObject InteractionText;

    public GameObject BlackImage;

    private CanvasGroup CG;

    private bool PlayerCollision;
    private void Start()
    {
        InteractionText.SetActive(false);
        PlayerCollision = false;

        CG = BlackImage.GetComponent<CanvasGroup>();
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
            StartCoroutine(FadeScene(1));
        }
    }

    private IEnumerator FadeScene(float duration)
    {

        float t = 0f;
        while (t < duration)

        {

            t += Time.deltaTime;
            CG.alpha = Mathf.Clamp01(t / duration);
            yield return null;

        }

        CG.alpha = 1f;
        SceneManager.LoadScene(scene);
    }
}
