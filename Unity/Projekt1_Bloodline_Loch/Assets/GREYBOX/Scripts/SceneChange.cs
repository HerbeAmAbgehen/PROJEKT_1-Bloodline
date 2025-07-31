using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string scene;

    public bool playsAudio;

    public GameObject BlackImage;

    private CanvasGroup CG;

    private AudioSource Audio;



    private void Start()
    {
        CG = BlackImage.GetComponent<CanvasGroup>();
        if (playsAudio)
        {
            Audio = GetComponent<AudioSource>();
        }
    }

    private IEnumerator FadeScene(float duration)
    {
        if (playsAudio)
        {
            Audio.Play(); 
        }

        AudioListener.volume = 1f;
        float t = 0f;
        while (t < duration)

        {
            AudioListener.volume = Mathf.Clamp(AudioListener.volume -= 0.01f, 0, 1);
            t += Time.deltaTime;
            CG.alpha = Mathf.Clamp01(t / duration);
            yield return null;

        }
        AudioListener.volume = 0f;
        CG.alpha = 1f;
        SceneManager.LoadScene(scene);
    }

    public void ChangeScene()
    {
        StartCoroutine(FadeScene(1));
    }
}
