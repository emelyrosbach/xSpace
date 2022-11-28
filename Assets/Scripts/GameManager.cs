using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Instance;
    private Dictionary<int, string> scenes;
    private int currentScene;
    public bool currentPortalActive;
    //public GameObject playerPrefabObject;
    public GameObject playerPrefabObject;
    public PlayerControls currentPlayer;
    private int tempScore = 0;

    void Start()
    {
        //PortalRoom = scene 1 in build settings
        currentScene = 1;
        scenes = new Dictionary<int, string>();
        scenes.Add(0, "Start");
        scenes.Add(1, "PortalRoom");
        scenes.Add(2, "Moon");
        scenes.Add(3, "Mars");
        scenes.Add(4, "Jupiter");
        scenes.Add(5, "End");
        scenes.Add(6, "Quiz");
        currentPortalActive = true;
        //PhotonNetwork.Instantiate(this.playerPrefabObject.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
        playerPrefabObject = PhotonNetwork.Instantiate(this.playerPrefabObject.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
        currentPlayer = playerPrefabObject.GetComponent<PlayerControls>();
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
        PhotonNetwork.LoadLevel(scenes[currentScene]);
    }

    public void nextScene()
    {
        if (currentPortalActive)
        {
            if (currentScene >1 && currentScene <5)
            {
                currentPlayer.updatePlayerScore(tempScore);
            }
            currentScene++;
            PhotonNetwork.LoadLevel(scenes[currentScene]);
            currentPortalActive = false;
        }
    }

    public void startQuiz()
    {
        //last scene in build settings
        PhotonNetwork.LoadLevel("Quiz");
    }

    public void endQuiz(int score)
    {
        tempScore = score;
        PhotonNetwork.LoadLevel(scenes[currentScene]);
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
        PhotonNetwork.LoadLevel("Start");
    }

    public PlayerControls GetCurrentPlayer()
    {
        return currentPlayer;
    }
}
      