using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Instance;
    private Dictionary<int, string> scenes;
    private int currentScene;
    public bool currentPortalActive;
    public GameObject playerPrefabObject;

    void Start()
    {
        currentScene = 1;
        scenes = new Dictionary<int, string>();
        scenes.Add(0, "Start");
        scenes.Add(1, "PortalRoom");
        scenes.Add(2, "End");
        scenes.Add(3, "Quiz");
        /*scenes.Add(0, "PortalRoom");
        scenes.Add(1, "PortalRoom");
        scenes.Add(2, "Moon");
        scenes.Add(3, "Mars");
        scenes.Add(4, "Jupiter");
        scenes.Add(5, "End");
        scenes.Add(6, "Quiz");*/
        currentPortalActive = true;
        Debug.Log("Create Player");
        PhotonNetwork.Instantiate(this.playerPrefabObject.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
        Debug.Log("Teilnehmer-Anzahl: " + PhotonNetwork.CurrentRoom.PlayerCount);
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
        //SceneManager.LoadScene(scenes[6]);
        SceneManager.LoadScene(scenes[3]);
    }

    public void endQuiz()
    {
        SceneManager.LoadScene(scenes[currentScene]);
    }

    public bool isCurrentPortalActive()
    {
        return currentPortalActive;
    }
    public void OnLeaveButtonClicked()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(scenes[0]);
    }
}