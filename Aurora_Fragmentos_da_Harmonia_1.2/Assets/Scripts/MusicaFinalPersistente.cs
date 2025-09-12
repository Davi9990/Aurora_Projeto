using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicaFinalPersistente : MonoBehaviour
{
    [Header("�udio")]
    public AudioClip musica;
    [Range(0f, 1f)] public float volume = 1f;

    [Header("Cenas em que a m�sica deve continuar")]
    [Tooltip("Adicione aqui os nomes das cenas onde essa m�sica deve permanecer tocando.")]
    public List<string> cenasPermitidas = new List<string>();

    private static MusicaFinalPersistente instancia;
    private AudioSource audioSrc;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);

            audioSrc = GetComponent<AudioSource>();
            if (audioSrc == null)
                audioSrc = gameObject.AddComponent<AudioSource>();

            audioSrc.clip = musica;
            audioSrc.volume = volume;
            audioSrc.loop = true;
            audioSrc.Play();

            SceneManager.sceneLoaded += AoCarregarCena;
        }
        else
        {
            // Se j� existe outra inst�ncia, destr�i esta
            Destroy(gameObject);
        }
    }

    private void AoCarregarCena(Scene cena, LoadSceneMode modo)
    {
        // Se a cena n�o est� na lista, parar a m�sica
        if (!cenasPermitidas.Contains(cena.name))
        {
            if (audioSrc.isPlaying)
                audioSrc.Stop();
        }
        else
        {
            // Se est� permitida mas n�o est� tocando, volta a tocar
            if (!audioSrc.isPlaying)
                audioSrc.Play();
        }
    }
}
