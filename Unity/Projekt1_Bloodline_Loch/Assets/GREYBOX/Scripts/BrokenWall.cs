using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenWall : MonoBehaviour
{
    public GameObject WallWhole;

    public GameObject WallBroken;

    public GameObject InteractionText;

    public GameObject BlackImage;

    private CanvasGroup CG;

    private MeshRenderer MR;

    private BoxCollider BC;

    private bool IsBroken = false;
    // Start is called before the first frame update
    void Start()
    {
        CG = BlackImage.GetComponent<CanvasGroup>();
        MR = GetComponent<MeshRenderer>();

        WallWhole.SetActive(true);
        WallBroken.SetActive(false);

        IsBroken = false;
        MR.enabled = true;
        BC.enabled = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.E) && !IsBroken)
        {
            StartCoroutine(BreakWall());
        }
    }
    private IEnumerator BreakWall()
    {
        StartCoroutine(FadeIn(1));
        
        WallWhole.SetActive(false);
        WallBroken.SetActive(true);
        MR.enabled = false;
        BC.enabled = false;
        yield return new WaitForSeconds(2);
        StartCoroutine(FadeIn(1));
        
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
    }
}
