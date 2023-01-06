using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    public Material red;
    public Material green;
    public Material neutral;


    public void Answer()
    {
        Debug.Log("do");
        if (isCorrect)
        {
            Debug.Log("Correct");
            quizManager.correct();

            Image r = GetComponent<Image>();
            r.material = green;
        }
        else
        {
            Debug.Log("Wrong");
            quizManager.wrong();

            Image r = GetComponent<Image>();
            r.material = red;
        }
    }

    public void setNeutral()
    {
        Image r = GetComponent<Image>();
        r.material = neutral;
    }
}
