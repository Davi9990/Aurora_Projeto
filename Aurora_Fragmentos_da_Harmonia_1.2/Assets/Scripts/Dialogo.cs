using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dialogo : MonoBehaviour
{
    [Header("Componentes do diálogo")]
    public GameObject caixaDialogo;
    public Image[] kidsDialogos;
    public TextMeshProUGUI textoUI;

    [Header("Inventário")]
    public Inventario inventario;

    [Header("Textos de diálogo")]
    public string[] textosDialogos; // padrão
    public string[] falasIniciais;
    public string[] falasCristal1;
    public string[] falasCristal2;
    public string[] falasCristal3;
    public string[] falasCristal4;

    [Header("Cena ao finalizar diálogo")]
    public string nomeCena; // preencha no Inspector

    [Header("Objetos do cenário")]
    public GameObject cristalGrande;
    public GameObject[] cristaisPequenos;
    public GameObject cenarioDescolorido;
    public GameObject cenarioColorido;

    private int indexFala = 0;
    private string[] falasAtuais;
    private int cristalAtual = 0;

    void Start()
    {
        foreach (var kid in kidsDialogos)
            kid.enabled = false;

        if (caixaDialogo == null)
            caixaDialogo = gameObject;

        caixaDialogo.SetActive(false);
        cristalGrande.SetActive(false);
        cenarioColorido.SetActive(false);
        DesativarCristais();

        IniciarDialogo(falasIniciais);
    }

    private void DesativarCristais()
    {
        foreach (var cristal in cristaisPequenos)
            if (cristal != null) cristal.SetActive(false);

        if (cristalGrande != null) cristalGrande.SetActive(false);
    }

    private void AtivarCristais(int index)
    {
        foreach (var cristal in cristaisPequenos)
            if (cristal != null) cristal.SetActive(true);

        if (index == 3 && cristalGrande != null)
            cristalGrande.SetActive(true);
    }

    public void IniciarDialogo(string[] falas)
    {
        if (falas == null || falas.Length == 0) return;

        caixaDialogo.SetActive(true);
        falasAtuais = falas;
        indexFala = 0;
        DesativarCristais();
        MostrarFalaAtual();
    }

    public void ProximoDialogo()
    {
        indexFala++;

        if (falasAtuais != null && indexFala < falasAtuais.Length)
        {
            MostrarFalaAtual();
        }
        else
        {
            FecharDialogo();

            // Troca de cena automaticamente
            if (!string.IsNullOrEmpty(nomeCena))
                SceneManager.LoadScene(nomeCena);
        }
    }

    private void MostrarFalaAtual()
    {
        if (falasAtuais != null && indexFala < falasAtuais.Length)
            textoUI.text = falasAtuais[indexFala];
    }

    public void AbrirDialogoCristal(int indexCristal)
    {
        caixaDialogo.SetActive(true);
        cristalAtual = indexCristal;

        foreach (var kid in kidsDialogos)
            kid.enabled = false;

        DesativarCristais();

        switch (indexCristal)
        {
            case 1:
                kidsDialogos[0].enabled = true;
                IniciarDialogo(falasCristal1);
                break;
            case 2:
                kidsDialogos[0].enabled = true;
                IniciarDialogo(falasCristal2);
                break;
            case 3:
                kidsDialogos[1].enabled = true;
                kidsDialogos[0].enabled = false;
                cristalGrande.SetActive(true);
                IniciarDialogo(falasCristal3);
                break;
            case 4:
                kidsDialogos[1].enabled = true;
                cenarioColorido.SetActive(true);
                cenarioDescolorido.SetActive(false);
                IniciarDialogo(falasCristal4);
                break;
        }
    }

    public void FecharDialogo()
    {
        caixaDialogo.SetActive(false);

        foreach (var kid in kidsDialogos)
            kid.enabled = false;

        AtivarCristais(cristalAtual);
    }
}