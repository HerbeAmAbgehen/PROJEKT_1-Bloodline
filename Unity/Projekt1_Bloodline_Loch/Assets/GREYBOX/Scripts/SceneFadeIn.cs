using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFadeIn : MonoBehaviour
{

    public GameObject BlackImage;

    private CanvasGroup CG;
    // Start is called before the first frame update
    void Start()
    {
        CG = BlackImage.GetComponent<CanvasGroup>();

        StartCoroutine(FadeIn(1));
    }


    public IEnumerator FadeIn(float duration)
    {

        float t = 0f;
        while (t < duration)

        {

            t += Time.deltaTime;
            CG.alpha = 1f - Mathf.Clamp01(t / duration);
            yield return null;

        }

        CG.alpha = 0f;

    }
}
