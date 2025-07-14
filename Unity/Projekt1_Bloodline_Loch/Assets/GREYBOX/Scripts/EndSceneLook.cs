using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        yield return new WaitForSeconds(FadeDuration);

        CamAnim.SetTrigger("LookToCat");

        yield return new WaitForSeconds(LookToCat.length);

        CatAnim.SetTrigger("Look");

        yield return new WaitForSeconds(CatLook.length);        
        
        CatAnim.SetTrigger("Scratch");

        yield return new WaitForSeconds(2);

        CamAnim.SetTrigger("LookFromCat");

        yield return new WaitForSeconds(LookFromCat.length+2);

        StartCoroutine(FadeOut(FadeDuration));
    }

    private IEnumerator FadeIn(float duration)
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

    private IEnumerator FadeOut(float duration)
    {

        float t = 0f;
        while (t < duration)

        {

            t += Time.deltaTime;
            CG.alpha = Mathf.Clamp01(t / duration);
            yield return null;

        }

        CG.alpha = 1f;

        Application.Quit();
    }
}
