using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InformationHolder : MonoBehaviour
{
    public string currentScene;
    int creation;
    // called first
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "DeadScreen")
            currentScene = scene.name;
    }

    // called when the game is terminated
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Awake()
    {
        creation = FindObjectsOfType<InformationHolder>().Length-1;
        Debug.Log("creation: " + creation);
        if (creation > 0)
            DestroyImmediate(this.gameObject);
        else
            DontDestroyOnLoad(this.gameObject);
    }
}
