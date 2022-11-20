using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    Dictionary<int, string> scenes;
    public int currentScene;

    void Start()
    {
        currentScene = 0;
        scenes = new Dictionary<int, string>();
        scenes.Add(0, "PortalRoom");
        scenes.Add(1, "Moon");
        scenes.Add(2, "Quiz");
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

    public void loadCurrentScene()
    {
        SceneManager.LoadScene(scenes[currentScene]);
    }

    public void nextScene()
    {
        Debug.Log("nextScene");
        currentScene++;
        SceneManager.LoadScene(scenes[currentScene]);
    }

    public void startQuiz()
    {
        SceneManager.LoadScene(scenes[2]);
    }

    public void endQuiz()
    {
        SceneManager.LoadScene(scenes[currentScene]);
    }
}