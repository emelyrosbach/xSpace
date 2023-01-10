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
        StartCoroutine(wait());
    }

    public void setNeutral()
    {
        Image w = GetComponent<Image>();
        w.material = neutral;
        Debug.Log("neutral");
    }

    IEnumerator wait()
    {
        Debug.Log("wait");
        if (isCorrect)
        {
            Image g = GetComponent<Image>();
            g.material = green;
            Debug.Log("Correct");
             yield return new WaitForSeconds(1);
            quizManager.correct();
        }
        else
        {
            Image r = GetComponent<Image>();
            r.material = red;
            Debug.Log("Wrong");
             yield return new WaitForSeconds(0.25f);
            quizManager.wrong();
        }
    }
}
