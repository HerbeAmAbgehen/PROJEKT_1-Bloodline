using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public CanvasGroup CG;

    public Button Play;

    // Start is called before the first frame update
    void Start()
    {
        Play.onClick.AddListener(() => LoadGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadGame()
    {
        Play.GetComponent<AudioSource>().Play();
        StartCoroutine(FadeScene(1));
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
        SceneManager.LoadScene("City_Outskirts");
    }
}
