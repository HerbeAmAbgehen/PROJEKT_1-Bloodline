using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class LightFlashes : MonoBehaviour
{
    public float FlashTime = 0.05f;

    private Light DirectionalLight;

    private float LightIntensity;

    private float DefaultIntensity;

    private float RandomLight;

    // Start is called before the first frame update
    void Start()
    {
        DirectionalLight = GetComponent<Light>();

        DefaultIntensity = DirectionalLight.intensity;

        InvokeRepeating("Lightning", 1, 4);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Lightning()
    {
        LightIntensity = Random.Range(0.3f, 0.7f);
        DirectionalLight.intensity = LightIntensity;  
        StartCoroutine(FlashTimer());
        RandomLight = Random.Range(0f, 10f);
        
        
    }

    IEnumerator FlashTimer()
    {
        yield return new WaitForSeconds(FlashTime);

        DirectionalLight.intensity = DefaultIntensity;

        if (RandomLight > 3f)
        {
            Lightning();
        }
    }
}
