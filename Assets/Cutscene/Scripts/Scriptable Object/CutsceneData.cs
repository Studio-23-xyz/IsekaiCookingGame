using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cutscene", menuName = "ScriptableObjects/Cutscene")]
public class CutsceneData : ScriptableObject
{
    public List<CutscenePanelData> cutscenePanels;
    public AudioClip BackgroundMusic;
}

[Serializable]
public class CutscenePanelData
{
    public Sprite comicImage;
    [Range(1,3)]
    public int columnSpan = 1;
    public AudioClip PageSFX;
}
