using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
   
    public AudioSource currentAudio;
    public AudioSource[] audioSources;

    public void Play(AudioSource current)
    {
        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource == current)
            {
                audioSource.Play();
            }
            else 
            {
                audioSource.Stop();
            }
               
             
        }
    }
}
