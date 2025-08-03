using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class AchievementText : MonoBehaviour
{
    public TMP_Text SecretText;

    public TMP_Text RatText;

    public CanvasGroup CG;

    public CanvasGroup SecretCanva;

    public CanvasGroup RatCanva;

    private SecretCounter SC;

    private void Start()
    {
        SC = GameObject.Find("Secret_Counter").GetComponent<SecretCounter>();

        if(SC.SecretsFound != 8)
        {
            SecretText.text = "You found " + $"{SC.SecretsFound}" + " of 8 secrets!";
        }
        else if (SC.SecretsFound > 8)
        {
            SecretText.text = "You found " + $"{SC.SecretsFound}" + " of 8 secrets! CHEATER!!";
        }
        else
        {
            SecretText.text = "You found every secret!";
        }

        if (SC.pattedRat)
        {
            RatText.text = "You patted the rat!";
        }
        else
        {
            RatText.text = "You did not pat the rat!";
        }

            StartCoroutine(FadeTexts(2));
    }

    private IEnumerator FadeScene(float duration)
    {
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
        Destroy(SC);
        Destroy(GameObject.Find("Options_DDOL"));
        SceneManager.LoadScene("MainMenu");
    }

    private IEnumerator FadeTexts(float duration)
    {
        yield return new WaitForSeconds (5);

        float t = 0f;
        while (t < duration)

        {
            t += Time.deltaTime;
            SecretCanva.alpha = 1 - Mathf.Clamp01(t / duration);
            yield return null;

        }
        SecretCanva.alpha = 0f;

        yield return new WaitForSeconds(0.5f);

        t = 0f;
        while (t < duration)

        {
            t += Time.deltaTime;
            RatCanva.alpha = Mathf.Clamp01(t / duration);
            yield return null;

        }
        RatCanva.alpha = 1f;
        StartCoroutine(FadeScene(2));
    }

}
