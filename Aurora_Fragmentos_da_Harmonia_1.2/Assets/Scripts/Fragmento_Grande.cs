using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fragmento_Grande : MonoBehaviour
{
    private SpriteRenderer sprite_Cristal;
    public Inventario inventario;
    public Dialogo dialogo;
    public TextMeshProUGUI text;

    void Start()
    {
        sprite_Cristal = GetComponent<SpriteRenderer>();
        sprite_Cristal.color = Color.white;
    }

    private void OnMouseEnter()
    {
        sprite_Cristal.color = Color.white;
    }

    private void OnMouseExit()
    {
        sprite_Cristal.color = Color.white;
    }

    public void OnMouseDown()
    {
        if (gameObject.CompareTag("Cristal"))
        {
            // Incrementa o índice do cristal no inventário
            inventario.Index_Cristais += 1;

            // Chama o novo método do Dialogo
            if (dialogo != null)
                dialogo.AbrirDialogoCristal(inventario.Index_Cristais);
            else
                Debug.LogWarning("Dialogo não está atribuído no Inspector!");

            // Incrementa o placar global (só o cristal final faz isso!)
            if (GameManeger.Instance != null)
                GameManeger.Instance.AddScore(1);

            Destroy(gameObject);
            Debug.Log("Cristal destruído e pontuação adicionada!");
        }
    }
}