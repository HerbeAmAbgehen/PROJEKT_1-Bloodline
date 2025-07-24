using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CatScare : MonoBehaviour
{
    public GameObject Player;

    public GameObject BlackImage;

    public GameObject RedImage;

    public float FadeDuration;

    public string TargetScene;

    public AnimationClip Cat_Jump;


    private CanvasGroup CGblack;

    private CanvasGroup CGred;

    private Image redImage;

    private Image blackImage;

    private CharacterController PC;

    private Animator Animator;


    // Start is called before the first frame update
    void Start()
    {
        CGblack = BlackImage.GetComponent<CanvasGroup>();

        CGred = RedImage.GetComponent<CanvasGroup>();

        PC = Player.GetComponent<CharacterController>();

        Animator = GetComponent<Animator>();

        blackImage = BlackImage.GetComponent<Image>();

        redImage = RedImage.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator FadeScene(float duration)
    {
        yield return new WaitForSeconds(Cat_Jump.length / 4);

        float t = 0f;
        while (t < duration)

        {

            t += Time.deltaTime;
            CGred.alpha = Mathf.Clamp01(t / duration);
            CGblack.alpha = Mathf.Clamp01(t / duration);
            redImage.color *= 0.995f;
            yield return null;

        }

        redImage.color = Color.black;
        CGred.alpha = 0f;
        CGblack.alpha = 1f;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(TargetScene);
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(FadeScene(FadeDuration));
        PC.enabled = false;
        Animator.SetTrigger("Jump");
        
    }

    /*private IEnumerator FadeOut(float duration)
    {

        float t = 0f;
        while (t < duration)

        {

            t += Time.deltaTime;
            CG.alpha = Mathf.Clamp01(t / duration);
            yield return null;

        }

        CG.alpha = 1f;

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
    */
}

