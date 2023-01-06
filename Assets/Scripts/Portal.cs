using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private GameManager  gameManager;
    public GameObject portalLiquid;
    public Material open;
    public Material closed;

    void Start()
    {
        gameManager = GameManager.Instance;
    }

    //Both old & new Input Manager enabled
    void Update()
    {
        if (gameManager.isCurrentPortalActive())
        {
            portalLiquid.GetComponent<Renderer>().material = open;
        }
        else
        {
            portalLiquid.GetComponent<Renderer>().material = closed;
        }
    }

    public void OnCollisionEnter(Collision other) {
        if (gameManager.isCurrentPortalActive()) {
            Debug.Log("next level");
            gameManager.nextLevel();  
        }
        
    }
}
