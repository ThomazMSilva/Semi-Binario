using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAudioPoemas : MonoBehaviour
{
    [SerializeField] AudioSource musica;
    private float volumeOriginalMusica;
    private Coroutine controleVolumeCoroutine;

    void Start()
    {
        if (musica != null)
        {
            volumeOriginalMusica = musica.volume;
        }
    }

    public void PlayNoAudio(AudioSource audioPoema)
    {
        if (controleVolumeCoroutine != null)
        {
            StopCoroutine(controleVolumeCoroutine);
        }
        controleVolumeCoroutine = StartCoroutine(ControlarVolumeDuranteAudio(audioPoema));
    }

    private IEnumerator ControlarVolumeDuranteAudio(AudioSource audioPoema)
    {
        if (musica != null)
        {
            musica.volume = volumeOriginalMusica * 0.3f; 
        }
        
        audioPoema.Play();
        
        while (audioPoema.isPlaying)
        {
            yield return null;
        }
        
        if (musica != null)
        {
            musica.volume = volumeOriginalMusica;
        }
    }
}