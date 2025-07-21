using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatScare : MonoBehaviour
{
    public GameObject Player;

    public GameObject Throne;

    public GameObject BlackImage;

    public float speed;

    public float FadeDuration;

    public string TargetScene;

    public bool scare;


    private CanvasGroup CG;

    private CharacterController PC;

    private Vector3 PlayerStartPosition;

    

    private Collider CatCollider;

    private Vector3 PlayerCatDistance;
    // Start is called before the first frame update
    void Start()
    {
        CG = BlackImage.GetComponent<CanvasGroup>();

        PC = Player.GetComponent<CharacterController>();

        PlayerStartPosition = Player.transform.position;

        scare = false;

        CatCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (scare)
        {
            PlayerCatDistance = Player.transform.position - transform.position;
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
            if (PlayerCatDistance.magnitude < 3f)
            {
                StartCoroutine(FadeScene(FadeDuration));
            }

        }
    }

    private IEnumerator FadeScene(float duration)
    {

        float t = 0f;
        while (t < duration)

        {

            t += Time.deltaTime;
            CG.alpha = Mathf.Clamp01(t / duration);
            yield return null;

        }

        CG.alpha = 1f;
        SceneManager.LoadScene(TargetScene);
    }

    private void OnTriggerEnter(Collider other)
    {
        scare = true;
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

    private IEnumerator Scare()
    {
        StartCoroutine(FadeOut(1f));
        yield return new WaitForSeconds(1);
        PC.enabled = false;
        Player.transform.position = PlayerStartPosition;
        Throne.SetActive(false);
        CatCollider.enabled = false;
        StartCoroutine(FadeIn(1f));
        scare = true;

    }
    public void TriggerScare()
    {
        StartCoroutine(Scare());
    }
    */
}

