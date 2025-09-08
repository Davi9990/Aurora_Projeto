using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogoSimples : MonoBehaviour
{
    [Header("Componentes do diálogo")]
    public GameObject CaixaDeDialogo;
    public TextMeshProUGUI textoUI;

    [Header("Configuração das falas")]
    [TextArea(2, 5)]
    public string[] falas; // Definido no Inspector
    private int indexFala = 0;

    [Header("Cena ao terminar o diálogo")]
    public string nomeCena;

    void Start()
    {
        // Já ativa a caixa e inicia o diálogo
        if (falas.Length > 0)
        {
            CaixaDeDialogo.SetActive(true);
            indexFala = 0;
            MostrarFalaAtual();
        }
    }

    // Chamado pelo botão
    public void ProximoDialogo()
    {
        indexFala++;

        if (indexFala < falas.Length)
        {
            MostrarFalaAtual();
        }
        else
        {
            // Quando acaba as falas -> troca de cena
            if (!string.IsNullOrEmpty(nomeCena))
            {
                SceneManager.LoadScene(nomeCena);
            }
            else
            {
                Debug.LogWarning("Nenhuma cena definida no Inspector!");
            }
        }
    }

    private void MostrarFalaAtual()
    {
        if (indexFala < falas.Length)
        {
            textoUI.text = falas[indexFala];
        }
    }
}
