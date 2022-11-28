using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class EndScenePrep : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerControls playerObject;
    public Text scoreTxt;

    void Start()
    {
        gameManager = GameManager.Instance;
        playerObject = gameManager.GetCurrentPlayer();
        int score = playerObject.getPlayerScore();
        string name = playerObject.name;
        scoreTxt.text = name + " you have " + score + " points";
        Debug.Log(score);
        Debug.Log(name);
    }
}
