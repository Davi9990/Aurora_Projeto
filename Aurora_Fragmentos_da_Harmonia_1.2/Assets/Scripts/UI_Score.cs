using System.Collections;
using System.Collections.Generic;
using TMPro; // para TextMeshProUGUI
using UnityEngine;

public class UI_Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // certifique-se de arrastar no Inspector

    void Update()
    {
        // Verifica se a UI e o GameManager existem antes de atualizar
        if (scoreText != null && GameManeger.Instance != null)
        {
            scoreText.text = "X " + GameManeger.Instance.score;
        }
    }
}