using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string scene;


    public GameObject BlackImage;

    private CanvasGroup CG;

    private void Start()
    {
        CG = BlackImage.GetComponent<CanvasGroup>();
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

    public void ChangeScene()
    {
        StartCoroutine(FadeScene(1));
    }
}
