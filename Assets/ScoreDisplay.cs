using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;

    private void Update() {
        scoreText.text = System.Convert.ToString("Score: "+ score);
    }

    public void IncreaseScore(int _score) {
        score += _score;
    }
}
