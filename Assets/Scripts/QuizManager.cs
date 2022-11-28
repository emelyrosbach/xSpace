using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public Text QuestionTxt;
    public Text scoreTxt;
    //gets passed to GM
    public int score;
    public int totoalQuestions = 0;
    public GameObject Quizpanel;
    public GameObject GoPanel;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
        setUp();
        totoalQuestions = QnA.Count;
        score = 0;
        GoPanel.SetActive(false);
        generateQuestion();
    }

    private void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = UnityEngine.Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            setAnswers();
        }
        else
        {
            Debug.Log("out of questions");
            GameOver();
        }
    }

    private void setAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    public void correct()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        scoreTxt.text = score + "/" + totoalQuestions;

        int compValue = (int)Math.Round(totoalQuestions * 0.6);
        if (score >= compValue)
        {
            gameManager.currentPortalActive = true;
        }
    }

    public void retry()
    {
        gameManager.startQuiz();
    }

    public void close()
    {
        int currentScore = (int)score;
        gameManager.endQuiz(score);
    }

    private void setUp()
    {
        string question1;
        string[] answers1;
        int correct1;
        QuestionsAndAnswers questionAndAnswers1;

        string question2;
        string[] answers2;
        int correct2;
        QuestionsAndAnswers questionAndAnswers2;

        string question3;
        string[] answers3;
        int correct3;
        QuestionsAndAnswers questionAndAnswers3;

        List<QuestionsAndAnswers> quiz1 = new List<QuestionsAndAnswers>();

        switch (gameManager.getCurrentScene())
        {
            case 2:
                question1 = "Are you on the moon?";
                answers1 = new string[] { "no", "no", "yes", "no" };
                correct1 = 3;
                questionAndAnswers1 = new QuestionsAndAnswers(question1, answers1, correct1);

                question2 = "Do you like the moon?";
                answers2 = new string[] { "yes", "no", "no", "no" };
                correct2 = 1;
                questionAndAnswers2 = new QuestionsAndAnswers(question2, answers2, correct2);

                question3 = "Do you like sweets?";
                answers3 = new string[] { "no", "no", "no", "yes" };
                correct3 = 4;
                questionAndAnswers3 = new QuestionsAndAnswers(question3, answers3, correct3);

                quiz1.Add(questionAndAnswers1);
                quiz1.Add(questionAndAnswers2);
                quiz1.Add(questionAndAnswers3);
                QnA = quiz1;
                break;

            case 3:
                question1 = "Are you on mars?";
                answers1 = new string[] { "no", "no", "yes", "no" };
                correct1 = 3;
                questionAndAnswers1 = new QuestionsAndAnswers(question1, answers1, correct1);

                question2 = "Do you like mars? ";
                answers2 = new string[] { "yes", "no", "no", "no" };
                correct2 = 1;
                questionAndAnswers2 = new QuestionsAndAnswers(question2, answers2, correct2);

                question3 = "Do you like sweets?";
                answers3 = new string[] { "no", "no", "no", "yes" };
                correct3 = 4;
                questionAndAnswers3 = new QuestionsAndAnswers(question3, answers3, correct3);

                quiz1.Add(questionAndAnswers1);
                quiz1.Add(questionAndAnswers2);
                quiz1.Add(questionAndAnswers3);
                QnA = quiz1;
                break;

            case 4:
                question1 = "Are you on jupier?";
                answers1 = new string[] { "no", "no", "yes", "no" };
                correct1 = 3;
                questionAndAnswers1 = new QuestionsAndAnswers(question1, answers1, correct1);

                question2 = "Do you like jupiter? ";
                answers2 = new string[] { "yes", "no", "no", "no" };
                correct2 = 1;
                questionAndAnswers2 = new QuestionsAndAnswers(question2, answers2, correct2);

                question3 = "Do you like sweets?";
                answers3 = new string[] { "no", "no", "no", "yes" };
                correct3 = 4;
                questionAndAnswers3 = new QuestionsAndAnswers(question3, answers3, correct3);

                quiz1.Add(questionAndAnswers1);
                quiz1.Add(questionAndAnswers2);
                quiz1.Add(questionAndAnswers3);
                QnA = quiz1;
                break;

            default:
                break;
        }
    }
}