using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPortal : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
    }

    //Both old & new Input Manager enabled
    void Update()
    {
      
    }

    public void OnCollisionEnter(Collision other)
    {
        if (gameManager.isCurrentPortalActive())
        {
            Debug.Log("next level");
            gameManager.nextLevel();
        }

    }
}
