using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFadeIn : MonoBehaviour
{

    public GameObject BlackImage;

    private CanvasGroup CG;
    private float maxVolume;
    // Start is called before the first frame update
    void Start()
    {
        CG = BlackImage.GetComponent<CanvasGroup>();
        maxVolume = GameObject.Find("Options_DDOL").GetComponent<GameSettings>().volume;

        StartCoroutine(FadeIn(1));
    }


    public IEnumerator FadeIn(float duration)
    {
        
        AudioListener.volume = 0f;
        float t = 0f;
        while (t < duration)

        {
            AudioListener.volume = Mathf.Clamp(AudioListener.volume += 0.01f, 0, maxVolume);
            t += Time.deltaTime;
            CG.alpha = 1f - Mathf.Clamp01(t / duration);
            yield return null;

        }
        AudioListener.volume = AudioListener.volume = maxVolume;
        CG.alpha = 0f;

    }
}
