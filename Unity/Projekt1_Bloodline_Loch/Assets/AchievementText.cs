using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class AchievementText : MonoBehaviour
{
    public TMP_Text Text;

    public CanvasGroup CG;

    private SecretCounter SC;

    private void Start()
    {
        SC = GameObject.Find("Secret_Counter").GetComponent<SecretCounter>();

        if(SC.SecretsFound != 7)
        {
            Text.text = "You found " + $"{SC.SecretsFound}" + " of 7 secrets!";
        }
        else if (SC.SecretsFound > 7)
        {
            Text.text = "You found " + $"{SC.SecretsFound}" + " of 7 secrets! CHEATER!!";
        }
        else
        {
            Text.text = "You found every secret!";
        }

            StartCoroutine(FadeScene(2));
    }

    private IEnumerator FadeScene(float duration)
    {
        yield return new WaitForSeconds(5);

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
        SceneManager.LoadScene("MainMenu");
    }
}
