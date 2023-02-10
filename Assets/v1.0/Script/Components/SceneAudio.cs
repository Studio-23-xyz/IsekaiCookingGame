using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAudio : MonoBehaviour
{
    public AudioSource sceneAudio;

    private void Awake()
    {
        if(sceneAudio)  GameManager.Instance.SoundManager.Play(sceneAudio);
    }
}