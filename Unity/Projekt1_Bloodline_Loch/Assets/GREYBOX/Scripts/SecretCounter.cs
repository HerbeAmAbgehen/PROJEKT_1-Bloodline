using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretCounter : MonoBehaviour
{
    private int SecretsFound;

    public void FoundSecret()
    {
        SecretsFound++;
    }
}
