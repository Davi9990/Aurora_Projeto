using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto_Identificado : MonoBehaviour
{
    private SpriteRenderer sprite_Cristal;
    public Inventario inventario;
    public Dialogo dialogo;

    void Start()
    {
        sprite_Cristal = GetComponent<SpriteRenderer>();
        sprite_Cristal.color = Color.clear;
    }

    private void OnMouseEnter()
    {
        sprite_Cristal.color = Color.white;
    }

    private void OnMouseExit()
    {
        sprite_Cristal.color = Color.clear;
    }

    public void OnMouseDown()
    {
        if (gameObject.CompareTag("Cristal"))
        {
            inventario.Index_Cristais += 1;
            dialogo.AbrirDialogoDireto(inventario.Index_Cristais);
            Destroy(gameObject);
            Debug.Log("Cristal destruido!");
        }
    }
}
