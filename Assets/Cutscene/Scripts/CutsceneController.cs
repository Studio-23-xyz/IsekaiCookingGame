using System;
using System.Collections;
using System.Collections.Generic;
 
using UnityEngine;
using UnityEngine.Events;

public class CutsceneController : MonoBehaviour
{
    public static CutsceneController Instance;


    public CutsceneData CutsceneData;

    
    public GameObject cutscenePagePrefab;



   // [Title("Config")] 
    public bool autoPlay = true;
    public float autoPlaySpeed = 0.5f;

    


   // [Title("Data")] 
    private int currentPageIndex;
    private int totalNumberOfPages;
    [SerializeField] private List<CutscenePage> Pages;
    private CutscenePage currentPage;

    public UnityEvent OnCutsceneFinished;
    public bool CutScenePlaying;

    private void Start()
    {
        Instance = this;
        Initialize();
    }

    private void Initialize()
    {
        CutScenePlaying = true;
       // UIManager.instance.ShowCommonButtons(false);
       CutsceneData = GameManager.Instance.currentCutscene;
        List<CutscenePanelData> cutscenePanels = CutsceneData.cutscenePanels;

        GameObject Currentpage=null;
        foreach (var panelData in cutscenePanels)
        {
            if (Currentpage == null)
            {
                Currentpage = Instantiate(cutscenePagePrefab, transform);
            }
          
            var page = Currentpage.GetComponent<CutscenePage>();
            page.AddPanel(panelData);
            if (page.PageFull)
            {
                page.Initialize();
                Pages.Add(page);
                Currentpage = null;
            }
            
        }
      OnCutsceneFinished.AddListener(GameManager.Instance.CutsceneEndAction.Invoke);
        totalNumberOfPages = Pages.Count;
        currentPageIndex = 0;
        ShowNext();

      //  AudioManager.Instance.PlayClipOnChannel(CutsceneData.BackgroundMusic,AudioManager.AudioChannel.Bgm);



        if (autoPlay) StartCoroutine(AutoPlayCutscene());
    }

    private IEnumerator AutoPlayCutscene()
    {
        while (currentPageIndex < totalNumberOfPages)
        {
            yield return new WaitForSeconds(autoPlaySpeed);
            ShowNext();
        }
    }


    // TO DO Code Improve
    public void ShowNext()
    {
        if (autoPlay)
        {
            StopAllCoroutines();
            StartCoroutine(AutoPlayCutscene());
        }

        currentPage = Pages[currentPageIndex];
        currentPage.SetVisibility(true);
        if (!currentPage.NextStrip())
        {
            currentPage.SetVisibility(false);
            currentPageIndex++;
            if (currentPageIndex == totalNumberOfPages)
            {
                CutScenePlaying = false;
                OnCutsceneFinished?.Invoke();
              //  AudioManager.Instance.FadeOutChannel(AudioManager.AudioChannel.Bgm);
              //  UIManager.instance.ShowCommonButtons(true);
               
                return;
            }

            currentPage = Pages[currentPageIndex];
        }
        
    }
}