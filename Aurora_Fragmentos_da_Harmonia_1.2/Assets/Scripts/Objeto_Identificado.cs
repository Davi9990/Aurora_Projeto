using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto_Identificado : MonoBehaviour
{
    private SpriteRenderer sprite_Cristal;
    public Inventario inventario;
    public Dialogo dialogo;

    public AudioSource audioSource;
    public AudioClip cristalColetado;

    public ParticleSystem brilhoCristal;

    void Start()
    {
        sprite_Cristal = GetComponent<SpriteRenderer>();
        sprite_Cristal.color = Color.clear;

        if(brilhoCristal != null)
        {
            brilhoCristal.Stop();
            brilhoCristal.Clear();
        }
    }

    private void OnMouseEnter()
    {
        sprite_Cristal.color = Color.white;
        if(audioSource != null) audioSource.Play();

        if(brilhoCristal != null) brilhoCristal.Play();
    }

    private void OnMouseExit()
    {
        sprite_Cristal.color = Color.clear;
        if(audioSource != null) audioSource.Stop();

        if(brilhoCristal != null) brilhoCristal.Stop();
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

            if(cristalColetado != null)
            {
                AudioSource.PlayClipAtPoint(cristalColetado, transform.position);
            }
            
            if(brilhoCristal != null)
            {
                brilhoCristal.Stop();
            }

            Destroy(gameObject);
            Debug.Log("Cristal destruído!");
        }
    }

}
