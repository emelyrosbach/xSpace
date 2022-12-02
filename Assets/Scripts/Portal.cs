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
      
    }

    public void OnCollisionEnter(Collision other) {
        Debug.Log("next level");
        gameManager.nextLevel();  
    }


}
