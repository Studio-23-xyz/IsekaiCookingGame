using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DialogueUIBehaviour : MonoBehaviour
{
    [SerializeField] private Image characterImage;
    [SerializeField] private Text dialogueText;
    [SerializeField] private AudioSource audioSource;

    public void ShowCharacter(Sprite image)
    {
        characterImage.sprite = image;
        characterImage.color = new Color(1f, 1f, 1f, 0f);
        characterImage.DOFade(1f, 0.5f);
    }

    public void ShowDialogue(string dialogue)
    {
        StartCoroutine(TypeDialogue(dialogue));
    }

    private IEnumerator TypeDialogue(string dialogue)
    {
        dialogueText.text = "";
        foreach (char letter in dialogue.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void PlayBGM(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}