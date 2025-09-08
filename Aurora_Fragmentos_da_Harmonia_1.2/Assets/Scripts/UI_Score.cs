using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // Update is called once per frame
    void Update()
    {
        if(GameManeger.Instance != null)
        {
            scoreText.text = "X " + GameManeger.Instance.score;
        }
    }
}
