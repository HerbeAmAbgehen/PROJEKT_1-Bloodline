using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretCounter : MonoBehaviour
{
    public int SecretsFound;

    public bool pattedRat;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void FoundSecret(bool KnowsSecret)
    {
        if (!KnowsSecret)
        {
            SecretsFound++;
        }
        
        Debug.Log("Found a secret. Secrets found: " + SecretsFound);
    }
}
