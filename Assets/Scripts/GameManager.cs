using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private Dictionary<int, string> scenes;
    private int currentScene;
    public bool currentPortalActive;

    void Start()
    {
        currentScene = 0;
        scenes = new Dictionary<int, string>();
        scenes.Add(0, "PortalRoom");
        scenes.Add(1, "Moon");
        scenes.Add(2, "Mars");
        scenes.Add(3, "Jupiter");
        scenes.Add(4, "End");
        scenes.Add(5, "Quiz");
        currentPortalActive = true;
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int getCurrentScene()
    {
        return currentScene;
    }

    public void loadCurrentScene()
    {
        SceneManager.LoadScene(scenes[currentScene]);
    }

    public void nextScene()
    {
        if (currentPortalActive)
        {
            currentScene++;
            SceneManager.LoadScene(scenes[currentScene]);
            currentPortalActive = false;
        }
    }

    public void startQuiz()
    {
        //last scene in build settings
        SceneManager.LoadScene(scenes[5]);
    }

    public void endQuiz()
    {
        SceneManager.LoadScene(scenes[currentScene]);
    }

    public bool isCurrentPortalActive()
    {
        return currentPortalActive;
    }
}