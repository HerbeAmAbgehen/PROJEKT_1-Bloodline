using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class LightFlashes : MonoBehaviour
{
    public float FlashTime = 0.05f;

    public float FlashMinStrength, FlashMaxStrength;

    public AudioClip Thunder_1;

    public AudioClip Thunder_2;

    public AudioClip Thunder_3;

    private Light LightComponent;

    private float LightIntensity;

    private float DefaultIntensity;

    private float RandomLight;

    private AudioSource Audio;

    // Start is called before the first frame update
    void Start()
    {
        LightComponent = GetComponent<Light>();

        Audio = GetComponent<AudioSource>();

        DefaultIntensity = LightComponent.intensity;

        InvokeRepeating("Lightning", 1, 4);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Lightning()
    {
        int flashVariant = Random.Range(1, 4);

        if (flashVariant == 1)
        {
            Audio.clip = Thunder_1;
        }
        else if (flashVariant == 2)
        {
            Audio.clip = Thunder_2;
        }
        else
        {
            Audio.clip = Thunder_3;
        }

        Audio.Play();

        LightIntensity = Random.Range(FlashMinStrength, FlashMaxStrength);
        LightComponent.intensity = LightIntensity;  
        StartCoroutine(FlashTimer());
        RandomLight = Random.Range(0f, 10f);
        
        
    }

    IEnumerator FlashTimer()
    {
        yield return new WaitForSeconds(FlashTime);

        LightComponent.intensity = DefaultIntensity;

        if (RandomLight > 3f)
        {
            Lightning();
        }
    }
}
