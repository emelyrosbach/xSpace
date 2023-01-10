using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
        private GameManager gameManager;
        public Text ScoreTxt;

    // Start is called before the first frame update
    void Start()
    {
       gameManager = GameManager.Instance; 
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.getCurrentLevel() >= 1)
        {
            int score = gameManager.getTotalScore();
            ScoreTxt.text = "You have " + score + " points!";
        }
    }
}
