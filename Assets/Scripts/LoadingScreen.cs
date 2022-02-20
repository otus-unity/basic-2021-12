using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public Image progressBar;
    private CanvasGroup canvasGroup;

    public static LoadingScreen instance { get; private set; }
    
    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        canvasGroup = GetComponentInChildren<CanvasGroup>();
        Utility.SetCanvasGroupEnabled(canvasGroup, false);
    }

    IEnumerator LoadingCoroutine(string name)
    {
        Utility.SetCanvasGroupEnabled(canvasGroup, true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(name);
        while (!operation.isDone)
        {
            progressBar.fillAmount = operation.progress;
            yield return null;
        }
        
        Utility.SetCanvasGroupEnabled(canvasGroup, false);
    }

    public void LoadScene(string name)
    {
        StartCoroutine(LoadingCoroutine(name));
    }
}
