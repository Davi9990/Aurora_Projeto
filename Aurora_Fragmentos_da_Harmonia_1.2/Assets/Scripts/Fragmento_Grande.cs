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
            inventario.Index_Cristais += 1;
            dialogo.AbrirDialogoDireto(inventario.Index_Cristais);

            //Incrementa o placar global (só o cristal final faz isso!)
            GameManeger.Instance.AddScore(1);

            Destroy(gameObject);
            Debug.Log("Cristal destruido e pontuação adicionada!");
        }
    }
}
