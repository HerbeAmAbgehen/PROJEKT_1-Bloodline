using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretItem : MonoBehaviour
{
    public GameObject Text;
    public bool TextActive = false;
    public float TextActiveTime;

    private bool KnowsSecret;
    private SecretCounter SecretCounter;

    private void Start()
    {
        SecretCounter = GameObject.Find("PlayerCapsule").GetComponent<SecretCounter>();
        Text.SetActive(false);
    }

    public void ShowText()
    {
        StartCoroutine(TextTimer());
        GameObject.Find("Secret_Counter").GetComponent<SecretCounter>().FoundSecret(KnowsSecret);
        KnowsSecret = true;
    }


    private IEnumerator TextTimer()
    {
        GetComponent<AudioSource>().Stop();
        Text.SetActive(true);
        yield return new WaitForSeconds(TextActiveTime);
        Text.SetActive(false);
    }
}
