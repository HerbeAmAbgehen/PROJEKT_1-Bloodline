using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretItem : MonoBehaviour
{
    public GameObject Text;
    public bool TextActive = false;

    private bool KnowsSecret;
    private SecretCounter SecretCounter;

    private void Start()
    {
        SecretCounter = GameObject.Find("PlayerCapsule").GetComponent<SecretCounter>();
        Text.SetActive(false);
    }

    public void ShowText()
    {
        Text.SetActive(true);
        TextActive = true;
        if (!KnowsSecret)
        {
            SecretCounter.FoundSecret();
            KnowsSecret = false;
        }
    }

    public void HideText()
    {
        Text.SetActive(false);
        TextActive = false;
    }

}
