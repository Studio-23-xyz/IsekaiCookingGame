using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAudio : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    
   

    private void Start()
    {
        if(_audioClip)
          GameManager.Instance.SoundManager.Play(_audioClip);
        else
        {
            GameManager.Instance.SoundManager.Stop();
        }
    }
}