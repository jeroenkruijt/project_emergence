using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallShowScript : MonoBehaviour
{
    public blueprint player;
    private Text text;
    private void Start() {
        text = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<blueprint>();
    }

    private void Update() {
        UpdateWall(); 
    }

    private void UpdateWall() {
        text.text = System.Convert.ToString(player.CurrentWalls() + " / " + player.WallsLimit());
    }
}
