using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CutscenePlayer : MonoBehaviour
{
    public UnityEvent OnCutSceneEnd;
    public void StartCutscene(CutsceneData cutsceneData)
    {
       GameManager.Instance.currentCutscene = cutsceneData;
       
       GameManager.Instance.CutsceneEndAction= () =>
        {
            SceneManager.UnloadSceneAsync("CutScenePlayer"); 
            OnEndCutscene();
        };
        GameManager.Instance.sceneLoader.LoadCutScene();
    }

    public void OnEndCutscene()
    {
        OnCutSceneEnd?.Invoke();

    }
}
