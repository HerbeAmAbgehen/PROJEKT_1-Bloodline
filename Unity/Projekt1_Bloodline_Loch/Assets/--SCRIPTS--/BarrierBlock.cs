using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierBlock : MonoBehaviour
{
    public GameObject Text;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(TextTimer());
    }

    private IEnumerator TextTimer()
    {
        Text.SetActive(true);
        yield return new WaitForSeconds(3);
        Text.SetActive(false);
    }
}
