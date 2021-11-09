using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveDisplay : MonoBehaviour
{
    public Text waveText;
    private float timer = 4f;
    private string message;

    private void Start() {
        waveText = GetComponent<Text>();
    }

    private void Update() {
        timer -= Time.deltaTime;

        if (timer <= 0) {
            HideText();
        }
    }

    private void HideText() {
        waveText.enabled = false;
    }
    public void SetWaveText(string _text) {
        message = _text;
        waveText.text = message;
        waveText.enabled = true;
        timer = 4f;
    }
}
