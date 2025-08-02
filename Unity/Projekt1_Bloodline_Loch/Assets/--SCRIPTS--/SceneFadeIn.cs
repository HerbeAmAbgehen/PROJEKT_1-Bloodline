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

        AudioListener.volume = 0f;
        float t = 0f;
        while (t < duration)

        {
            AudioListener.volume = Mathf.Clamp(AudioListener.volume += 0.01f, 0, 1);
            t += Time.deltaTime;
            CG.alpha = 1f - Mathf.Clamp01(t / duration);
            yield return null;

        }
        AudioListener.volume = 1f;
        CG.alpha = 0f;

    }
}
