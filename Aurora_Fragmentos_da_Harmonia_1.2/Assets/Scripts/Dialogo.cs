using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class Fala
{
    public string nome;
    [TextArea(2, 5)]
    public string texto;
}

public class Dialogo : MonoBehaviour
{
    [Header("Componentes do diálogo")]
    public GameObject caixaDialogo;
    public Image[] kidsDialogos;
    public TextMeshProUGUI textoUI;
    public TextMeshProUGUI nomeUI;

    [Header("Aurora (imagens)")]
    public Image[] auroraImagens;   // [0] = triste, [1] = feliz

    [Header("Inventário")]
    public Inventario inventario;

    [Header("Fal falas (com nome + texto)")]
    public Fala[] falasIniciais;
    public Fala[] falasCristal1;
    public Fala[] falasCristal2;
    public Fala[] falasCristal3;
    public Fala[] falasCristal4;

    [Header("Cena ao finalizar diálogo")]
    public string nomeCena;

    [Header("Objetos do cenário")]
    public GameObject cristalGrande;
    public GameObject[] cristaisPequenos;
    public GameObject cenarioDescolorido;
    public GameObject cenarioColorido;

    private int indexFala = 0;
    private Fala[] falasAtuais;
    private int cristalAtual = 0;
    private bool trocarCena = false;

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

        // deixa só a Aurora triste visível
        AtualizarAurora(0);

        IniciarDialogo(falasIniciais);
    }

    private void AtualizarAurora(int indice)
    {
        if (auroraImagens == null || auroraImagens.Length == 0) return;

        for (int i = 0; i < auroraImagens.Length; i++)
            if (auroraImagens[i] != null)
                auroraImagens[i].enabled = (i == indice);
    }

    private void DesativarCristais()
    {
        foreach (var cristal in cristaisPequenos)
            if (cristal != null) cristal.SetActive(false);

        if (cristalGrande != null)
            cristalGrande.SetActive(false);
    }

    private void AtivarCristais(int index)
    {
        foreach (var cristal in cristaisPequenos)
            if (cristal != null) cristal.SetActive(true);

        if (index == 3 && cristalGrande != null)
            cristalGrande.SetActive(true);
    }

    public void IniciarDialogo(Fala[] falas, bool cenaNoFinal = false)
    {
        if (falas == null || falas.Length == 0) return;

        caixaDialogo.SetActive(true);
        falasAtuais = falas;
        indexFala = 0;
        trocarCena = cenaNoFinal;
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

            if (trocarCena && !string.IsNullOrEmpty(nomeCena))
                SceneManager.LoadScene(nomeCena);
        }
    }

    private void MostrarFalaAtual()
    {
        if (falasAtuais == null || indexFala >= falasAtuais.Length) return;

        textoUI.text = falasAtuais[indexFala].texto;
        if (nomeUI != null)
            nomeUI.text = falasAtuais[indexFala].nome;
    }

    public void AbrirDialogoCristal(int indexCristal)
    {
        caixaDialogo.SetActive(true);
        cristalAtual = indexCristal;

        foreach (var kid in kidsDialogos)
            kid.enabled = false;

        DesativarCristais();

        // por padrão mostra Aurora triste (índice 0)
        AtualizarAurora(0);

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

                // No terceiro diálogo Aurora feliz (índice 1)
                AtualizarAurora(1);

                IniciarDialogo(falasCristal3);
                break;
            case 4:
                kidsDialogos[1].enabled = true;
                cenarioColorido.SetActive(true);
                cenarioDescolorido.SetActive(false);
                IniciarDialogo(falasCristal4, true);
                AtualizarAurora(1);
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
