using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public GameObject quizManagerObject;
    public QuizManager quizManager;
    // Start is called before the first frame update
    void Start()
    {
        quizManager = quizManagerObject.GetComponent<QuizManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision other)
    {
        quizManager.showQuiz();
    }

    public void OnMouseDown()
    {
        quizManager.showQuiz();
    }
}
