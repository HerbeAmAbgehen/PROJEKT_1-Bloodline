using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class EmissionFlash : MonoBehaviour
{
    public float FlashTime = 0.05f;

    public float FlashStrength;

    private Renderer Renderer;

    private Vector4 DefaultColor;

    private Vector4 FlashIntensity;


    // Start is called before the first frame update
    void Start()
    {
        Renderer = GetComponent<Renderer>();

        DefaultColor = Renderer.material.GetColor("_EmissionColor");

        FlashIntensity = DefaultColor * FlashStrength;

        InvokeRepeating("Lightning", 1, 4);
    }


    private void Lightning()
    {
        Renderer.material.SetColor("_EmissionColor", FlashIntensity);
        StartCoroutine(FlashTimer());  
    }

    IEnumerator FlashTimer()
    {
        Renderer.material.SetColor("_EmissionColor", FlashIntensity);

        yield return new WaitForSeconds(FlashTime*0.75f);

        Renderer.material.SetColor("_EmissionColor", DefaultColor);

        yield return new WaitForSeconds(0.1f);
        
        Renderer.material.SetColor("_EmissionColor", FlashIntensity * 1.7f);

        yield return new WaitForSeconds(FlashTime);

        Renderer.material.SetColor("_EmissionColor", DefaultColor);
    }
}
