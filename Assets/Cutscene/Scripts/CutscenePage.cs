 
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CutscenePage : MonoBehaviour
{




   
    private List<CutscenePanelData> PanelDatas=new List<CutscenePanelData>();



   
    [SerializeField]
    private Image[] strips;

    public bool PageFull => PanelDatas.Sum(r => r.columnSpan) == 3;

    private int numberOfStrips;
    private int currentStripNo = -1;



    public void AddPanel(CutscenePanelData panelData)
    {
        PanelDatas.Add(panelData);
    }

    public void Initialize()
    {
        for (int i = PanelDatas.Count; i < 3; i++)
        {
            strips[i].transform.parent.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);

        foreach(Image strip in strips)
        {
            strip.GetComponent<CanvasGroup>().alpha = 0f;
        }

        for (int i = 0; i < PanelDatas.Count; i++)
        {
            strips[i].sprite = PanelDatas[i].comicImage;
        }
        numberOfStrips = PanelDatas.Count;

    }



    public bool NextStrip()
    {
        currentStripNo++;
        if (currentStripNo == numberOfStrips)
        {
            return false;

        }

        if (PanelDatas[currentStripNo].PageSFX != null)
        {
         //AudioManager.Instance.PlayClipOnChannel(PanelDatas[currentStripNo].PageSFX,AudioManager.AudioChannel.Sfx);
        }

        strips[currentStripNo].GetComponent<CanvasGroup>().DOFade(1f, 1.5f);
        return true;


    }

    public void SetVisibility(bool isVisible)
    {
        gameObject.SetActive(isVisible);
    }


}
