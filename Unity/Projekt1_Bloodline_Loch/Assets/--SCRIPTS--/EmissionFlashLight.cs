using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class EmissionFlashLight : MonoBehaviour
{
    public float FlashTime = 0.05f;

    public float FlashStrength;

    private Light LightComponent;

    private float DefaultIntensity;



    // Start is called before the first frame update
    void Start()
    {
        LightComponent = GetComponent<Light>();

        DefaultIntensity = LightComponent.intensity;

        InvokeRepeating("Lightning", 1, 4);
    }


    private void Lightning()
    {
        LightComponent.intensity = DefaultIntensity * FlashStrength;
        StartCoroutine(FlashTimer());  
    }

    IEnumerator FlashTimer()
    {
        LightComponent.intensity = DefaultIntensity * FlashStrength;

        yield return new WaitForSeconds(FlashTime*0.75f);

        LightComponent.intensity = DefaultIntensity;

        yield return new WaitForSeconds(0.1f);

        LightComponent.intensity = DefaultIntensity * FlashStrength * 1.7f;

        yield return new WaitForSeconds(FlashTime);

        LightComponent.intensity = DefaultIntensity;
    }
}
