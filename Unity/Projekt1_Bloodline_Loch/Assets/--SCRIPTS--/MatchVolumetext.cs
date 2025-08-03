using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MatchVolumetext : MonoBehaviour
{
    private TMP_Text text;
    public Slider volSlider;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();

        volSlider.onValueChanged.AddListener(delegate { MatchText(); });

        text.text = "Volume: " + $"{(int) (volSlider.value * 100)}";
    }

    private void MatchText()
    {
        text.text = "Volume: " + $"{(int) (volSlider.value*100)}";
    }
}
