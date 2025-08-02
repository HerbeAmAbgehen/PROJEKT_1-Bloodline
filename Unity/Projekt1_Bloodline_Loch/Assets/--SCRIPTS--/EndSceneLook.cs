using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneLook : MonoBehaviour
{

    public GameObject Cat;

    public AnimationClip LookToCat;

    public AnimationClip LookFromCat;

    public AnimationClip CatLook;

    public GameObject BlackImage; 

    public float FadeDuration;

    private Animator CamAnim;

    private Animator CatAnim;

    private CanvasGroup CG;
    // Start is called before the first frame update
    void Start()
    {
        CamAnim = GetComponent<Animator>();
        CatAnim = Cat.GetComponent<Animator>();
        CG = BlackImage.GetComponent<CanvasGroup>();

        StartCoroutine(CameraAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator CameraAnimation()
    {
        StartCoroutine(FadeIn(FadeDuration));

        yield return new WaitForSeconds(FadeDuration+2);

        CamAnim.SetTrigger("LookToCat");
        CatAnim.SetTrigger("Look");

        yield return new WaitForSeconds(CatLook.length+1);
        GetComponent<AudioSource>().Play();
        CatAnim.SetTrigger("Scratch");

        yield return new WaitForSeconds(4);

        CamAnim.SetTrigger("LookFromCat");

        yield return new WaitForSeconds(LookFromCat.length+4);

        StartCoroutine(FadeOut(FadeDuration));
    }

    private IEnumerator FadeIn(float duration)
    {
        AudioListener.volume = 0;
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

    private IEnumerator FadeOut(float duration)
    {

        float t = 0f;
        while (t < duration)

        {
            AudioListener.volume = Mathf.Clamp(AudioListener.volume -= 0.01f, 0, 1); ;
            t += Time.deltaTime;
            CG.alpha = Mathf.Clamp01(t / duration);
            yield return null;

        }
        AudioListener.volume = 0;
        CG.alpha = 1f;

        SceneManager.LoadScene("Achievement");
    }
}
