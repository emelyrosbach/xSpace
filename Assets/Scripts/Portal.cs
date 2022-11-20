using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://stackoverflow.com/questions/35890932/unity-game-manager-script-works-only-one-time

public class Portal : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
    }

    //Both old & new Input Manager enabled
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameManager.nextScene();
        }
    }
}