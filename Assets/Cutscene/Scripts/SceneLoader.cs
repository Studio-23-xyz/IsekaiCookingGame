using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;



/*
 CentralMap
 CutScenePlayer
 Home
 Kitchen
 Restaurant
 Shop
 */

public class SceneLoader : MonoBehaviour
{
    public bool HideCommonUI = false;


    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    void Awake()
    {
       // UIManager.instance?.ShowCommonButtons(!HideCommonUI);
    }

    public void HideObjectiveUI()
    {
       //UIManager.instance.ObjectiveController.HideObjective();
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        yield return null;
      // UIManager.instance.GoToMainMenuButton.SetActive(sceneName != "MainMenu");

        var asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            if (asyncOperation.progress >= 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    public void LoadCutScene()
    {
        if(CutsceneController.Instance!=null)return;
        SceneManager.LoadScene("CutScenePlayer",LoadSceneMode.Additive);  
    }
    
    public void QuitGame()
    {
       GameManager.Instance.QuitGame();
    }
    
}