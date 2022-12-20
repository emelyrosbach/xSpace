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


    public void Answer()
    {
        Debug.Log("do");
        if (isCorrect)
        {
            Debug.Log("Correct");
            quizManager.correct();

            Image r = GetComponent<Image>();
            r.material = green;

            /*ColorBlock cb =  GetComponent<Button>().maetial.colors;
            cb.pressedColor = Color.green;
            GetComponent<Button>().colors = cb;**/

            //this.gameObject.GetComponent<Image>().color = Color.green;
            //this.gameObject.GetComponent<Image>().color = Color.white;
        }
        else
        {
            Debug.Log("Wrong");
            quizManager.wrong();
            //this.gameObject.GetComponent<Image>().color = Color.red;
            //this.gameObject.GetComponent<Image>().color = Color.white;
        }
    }
}
