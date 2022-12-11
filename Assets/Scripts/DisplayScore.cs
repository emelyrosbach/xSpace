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
        int score = gameManager.getTotalScore();
        ScoreTxt.text = "You have " + score + " points!";
    }
}
