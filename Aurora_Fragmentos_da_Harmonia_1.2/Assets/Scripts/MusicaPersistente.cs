using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MusicaPersistente : MonoBehaviour
{
    [Header("Configuração")]
    [Tooltip("Arraste aqui o AudioSource com a música que deve persistir.")]
    public AudioSource musica;

    [Tooltip("Lista de nomes de cenas onde a música que deve persistir.")]
    public List<string> cenasComMusica = new List<string>();

    private static MusicaPersistente instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += AoCarregarCena;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        VerificarCena(SceneManager.GetActiveScene().name);
    }

    private void AoCarregarCena(Scene cena, LoadSceneMode mode)
    {
        VerificarCena(cena.name);
    }

    private void VerificarCena(string nomeCena)
    {
        if(cenasComMusica.Contains(nomeCena))
        {
            if(!musica.isPlaying)
            {
                musica.Play();
            }
        }
        else
        {
            if(musica.isPlaying)
            {
                musica.Stop();
            }
        }
    }
}
