using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loading_handler : MonoBehaviour
{
    AsyncOperation loadingOperation;
    public Slider progressBar;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        loadingOperation = SceneManager.LoadSceneAsync(1);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        progressBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
    }
}
