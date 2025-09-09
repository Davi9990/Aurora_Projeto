using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogo : MonoBehaviour
{
    [Header("Componentes do di�logo")]
    public GameObject Caixa_de_dialogo;
    public Image[] KidsDialogos;
    public TextMeshProUGUI text;

    [Header("Refer�ncia ao invent�rio")]
    public Inventario inventario;

    [Header("Textos de cada di�logo")]
    public string[] textosDialogos; // definir manualmente pelo Inspector

    [Header("Textos Iniciais da Protagonista")]
    public string[] falasIniciais; // Definir manualmente pelo inspector
    private int indexFala = 0;
    private string[] falasAtuais;

    [Header("Textos Iniciais da Protagonista")]
    public string[] falasCristal1;
    public string[] falasCristal2;
    public string[] falasCristal3;
    public string[] falasCristal4;

    [Header("Troca de cena")]
    public string nomecena;
    private bool trocarCenaNoProximoClique = false;

    private bool dialogoAberto = false;
    private bool dialogoInicialAtivo = false;

    [Header("Objetos do cen�rio")]
    public GameObject Cristal_Grande;
    public GameObject[] Cristais_Pequenos;
    public GameObject Cenario_Descolorido;
    public GameObject Cenario_Colorido;

    private int cristalAtual = 0;

    void Start()
    {
        // Desativa todos os Kids e a caixa
        foreach (var kid in KidsDialogos)
            kid.enabled = false;

        if (Caixa_de_dialogo == null)
            Caixa_de_dialogo = gameObject;

        Caixa_de_dialogo.SetActive(false);

        Cristal_Grande.SetActive(false);

        Cenario_Colorido.SetActive(false);

        DesativarCristais();

        IniciarDialogosExtra(falasIniciais);
    }

    private void DesativarCristais()
    {
        foreach(var cristal in Cristais_Pequenos)
        {
            if(cristal != null)
            {
                cristal.SetActive(false);
            }
        }

        if (Cristal_Grande != null)
        {
            Cristal_Grande.SetActive(false);
        }
    }

    private void AtivarCristais(int indexCristal)
    {
        foreach(var cristal in Cristais_Pequenos)
        {
            if(cristal != null)
            {
                cristal.SetActive(true);
            }
        }

        if(indexCristal == 3 && Cristal_Grande != null)
        {
            Cristal_Grande.SetActive(true);
        }
    }


    //Di�logos Iniciais
    public void IniciarDialogosExtra(string[] falas)
    {
        if (falas == null || falas.Length == 0) return;

        Caixa_de_dialogo.SetActive(true);
        dialogoAberto = true;
        dialogoInicialAtivo = true;

        falasAtuais = falas;
        indexFala = 0;

        DesativarCristais();

        MostrarFalaAtual();
    }

    public void ProximaDialogo()
    {
        if (!dialogoInicialAtivo)
        {
            FecharDialogo();
            return;
        }

        indexFala++;

        if (falasAtuais != null && indexFala < falasAtuais.Length)
        {
            MostrarFalaAtual();
        }
        else
        {
            // Chegou ao final do di�logo atual
            dialogoInicialAtivo = false;
            FecharDialogo();

            // Trocar de cena somente se for o di�logo 4
            if (falasAtuais == falasCristal4)
            {
                SceneManager.LoadScene(nomecena);
            }
        }
    }

    private void MostrarFalaAtual()
    {
        if(falasAtuais != null && indexFala < falasAtuais.Length)
        {
            text.text = falasAtuais[indexFala];
        }
    }

    // Abre o di�logo dependendo do Index_Cristais
    public void AbrirDialogoDireto(int indexCristal)
    {
        //if (dialogoAberto) return;

        Caixa_de_dialogo.SetActive(true);

        if (indexCristal != 4 && dialogoAberto)
            return;

        dialogoAberto = true;
        cristalAtual = indexCristal;

        // Desativa todas as imagens
        for (int i = 0; i < KidsDialogos.Length; i++)
            KidsDialogos[i].enabled = false;

        DesativarCristais();

        // Aqui voc� escolhe qual imagem mostrar dependendo do di�logo
        if (indexCristal == 1)
        {
            KidsDialogos[0].enabled = true;
            IniciarDialogosExtra(falasCristal1);
        }
        else if (indexCristal == 2)
        {
            KidsDialogos[0].enabled = true;
            IniciarDialogosExtra(falasCristal2);
        }
        else if (indexCristal == 3)
        {
            KidsDialogos[1].enabled = true;
            KidsDialogos[0].enabled = false;
            Cristal_Grande.SetActive(true);
            IniciarDialogosExtra(falasCristal3);
        }
        else if (indexCristal == 4)
        {
            KidsDialogos[1].enabled = true;

            Cenario_Colorido.SetActive(true);
            Cenario_Descolorido.SetActive(false);
            IniciarDialogosExtra(falasCristal4);

            //Marca que o pr�ximo clique ap�s o �ltimo di�logo vai trocar de cena
            trocarCenaNoProximoClique = true;
        }
    }

    // Chamado pelo bot�o para fechar
    public void FecharDialogo()
    {
        Caixa_de_dialogo.SetActive(false);

        // Desativa todas as imagens
        for (int i = 0; i < KidsDialogos.Length; i++)
            KidsDialogos[i].enabled = false;

        dialogoAberto = false;

        AtivarCristais(cristalAtual);
    }
}
