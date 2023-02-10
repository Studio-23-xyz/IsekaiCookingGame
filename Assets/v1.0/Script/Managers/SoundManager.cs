using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
   
     
    public AudioSource audioSources;

    public void Play(AudioClip clip)
    {

        audioSources.clip = clip;
        audioSources.Play();
         
    }
    public void Stop()
    {
        audioSources.Stop();
         
    }
}
