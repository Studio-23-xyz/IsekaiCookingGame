using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class DialogueUIBehaviour : MonoBehaviour
{
    
    
    [SerializeField] private Image characterImage;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Button interactionWithDialogue;
    [SerializeField] private TextMeshProUGUI coinText;

    private void Awake()
    {
        interactionWithDialogue.onClick.AddListener(delegate { DialogueManager.Instance.MoveToNextState(); });
    }

    public void ShowCharacter(Sprite image)
    {
        characterImage.sprite = image;
        characterImage.color = new Color(1f, 1f, 1f, 0f);
        characterImage.DOFade(2, 0.5f);
    }

    private bool _isInteractable; 
    public void ShowDialogue(string dialogue, string buttonText = "CONTINUE", bool isInteractable = true)
    {
        interactionWithDialogue.interactable = false;
        _isInteractable = isInteractable;
        StartCoroutine(TypeDialogue(dialogue));
        interactionWithDialogue.GetComponentInChildren<TextMeshProUGUI>().text = buttonText;
       
    }

    private IEnumerator TypeDialogue(string dialogue)
    {
        dialogueText.text = "";
        foreach (char letter in dialogue.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        interactionWithDialogue.interactable = _isInteractable;
    }

    public void PlayBGM(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.loop = true;
        audioSource.Play();
    }

   
    private bool _tartShowCoinTextRunning;
    private float _count = 0;
    private float _duration = 10f;
    public void ShowCoinText(float amount)
    {
      
       
        if (_tartShowCoinTextRunning)
        {
            _count = _duration;
        }
        
        StartCoroutine( StartShowCoinText(amount));
    }
    IEnumerator StartShowCoinText(float amount)
    {
        coinText.text = $"YOU EARN ${amount}";
        _tartShowCoinTextRunning = true;
        while (_count < _duration)
        {
            _count += Time.deltaTime;
            
            yield return null;
        }

        _count = 0;
        _tartShowCoinTextRunning = false;
        coinText.text = "";
    }
    
}