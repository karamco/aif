using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelLoader : MonoBehaviour {

    public GameObject LoadingScren;
    public Slider slider;
    public Text ProgressText;

	public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        LoadingScren.SetActive(true);
        while(!operation.isDone)
        {
            float Progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = Progress;
            ProgressText.text = Progress * 100f + "%";
            yield return null;
        }
    } 
}
