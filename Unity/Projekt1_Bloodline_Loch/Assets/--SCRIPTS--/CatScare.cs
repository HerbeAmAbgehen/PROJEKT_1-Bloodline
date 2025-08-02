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

    public GameObject BloodParticles;

    private CanvasGroup CGblack;

    private CanvasGroup CGred;

    private Image redImage;

    private Image blackImage;

    private CharacterController PC;

    private Animator Animator;

    private bool killPlayer = false;


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
        if (killPlayer && Player.transform.localRotation.x > -80)
        {
            Player.transform.Rotate(Vector3.left * 120 * Time.deltaTime);
        }
                                            
    }

    private IEnumerator FadeScene(float duration)
    {
        yield return new WaitForSeconds(Cat_Jump.length / 4);
        killPlayer = true;
        BloodParticles.SetActive(true);

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

    public void TriggerScare()
    {
        GetComponent<AudioSource>().Play();
        StartCoroutine(FadeScene(FadeDuration));
        GameObject.Find("heartbeat").GetComponent<AudioSource>().Stop();
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

