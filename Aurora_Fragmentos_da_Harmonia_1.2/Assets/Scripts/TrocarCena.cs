using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{
    public string nomeCena;

    public void CarragarCena()
    {
        if(!string.IsNullOrEmpty(nomeCena))
        {
            SceneManager.LoadScene(nomeCena);
        }
        else
        {
            Debug.LogWarning("Nenhum nome de cena foi definido no Inspector!");
        }
    }
}