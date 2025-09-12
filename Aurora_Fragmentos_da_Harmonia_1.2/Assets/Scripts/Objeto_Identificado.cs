using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto_Identificado : MonoBehaviour
{
    private SpriteRenderer sprite_Cristal;
    public Inventario inventario;
    public Dialogo dialogo;

    public AudioSource audioSource;

    void Start()
    {
        sprite_Cristal = GetComponent<SpriteRenderer>();
        sprite_Cristal.color = Color.clear;

        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseEnter()
    {
        sprite_Cristal.color = Color.white;
        audioSource.Play();
    }

    private void OnMouseExit()
    {
        sprite_Cristal.color = Color.clear;
        audioSource.Stop();
    }

    public void OnMouseDown()
    {
        if (gameObject.CompareTag("Cristal"))
        {
            // Incrementa o índice do cristal no inventário
            inventario.Index_Cristais += 1;

            // Chama o método atualizado do Dialogo
            if (dialogo != null)
                dialogo.AbrirDialogoCristal(inventario.Index_Cristais);
            else
                Debug.LogWarning("Dialogo não está atribuído no Inspector!");

            Destroy(gameObject);
            Debug.Log("Cristal destruído!");
        }
    }
}
