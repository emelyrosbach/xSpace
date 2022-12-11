using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private GameManager  gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
    }

    //Both old & new Input Manager enabled
    void Update()
    {
        if (gameManager.isCurrentPortalActive())
        {
           // GetComponent<Renderer>().material.color = new Color(0, 255, 0);
        }
        else
        {
           // GetComponent<Renderer>().material.color = new Color(255, 0, 0);
        }
    }

    public void OnCollisionEnter(Collision other) {
        if (gameManager.isCurrentPortalActive()) {
            Debug.Log("next level");
            gameManager.nextLevel();  
        }
        
    }
}
