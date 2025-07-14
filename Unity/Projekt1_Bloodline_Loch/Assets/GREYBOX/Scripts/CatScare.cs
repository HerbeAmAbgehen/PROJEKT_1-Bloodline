using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatScare : MonoBehaviour
{

    public GameObject Target;

    public float speed;

    public GameObject BlackImage;

    public float FadeDuration;

    public string TargetScene;


    private CanvasGroup CG;

    private Vector3 StartCoordinates;

    private Vector3 TargetCoordinates;

    private Vector3 Direction;
    // Start is called before the first frame update
    void Start()
    {
        CG = BlackImage.GetComponent<CanvasGroup>();

        StartCoordinates = transform.position;

        Direction = Target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        if(transform.position.z < 1)
        {
            StartCoroutine(FadeScene(FadeDuration));
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
}
