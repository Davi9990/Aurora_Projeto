using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public Image[] imagensOcupadas;
    public Image[] imagensDesocupadas;
    public int Index_Cristais;

    void Start()
    {
        for(int i = 0; i < imagensOcupadas.Length; i++)
        {
            imagensOcupadas[i].enabled = false;
            imagensDesocupadas[i].enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ColetarCristais();
    }

    public void ColetarCristais()
    {
       if(Index_Cristais >= 1 && Index_Cristais <= imagensDesocupadas.Length)
       {
            int i = Index_Cristais - 1;
            imagensOcupadas[i].enabled = true;
            imagensDesocupadas[i].enabled = false;
       }
       //else if(Index_Cristais > imagensOcupadas.Length)
       //{
       //     Debug.Log("Inventario cheio!");
       //     Index_Cristais = imagensOcupadas.Length;
       //}
    }
}
