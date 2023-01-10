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
    public GameObject Quiz;
    public GameObject QuizContainer;
    public GameObject Quizpanel;
    public GameObject GoPanel;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
        hideQuiz();
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
            options[i].GetComponent<AnswerScript>().setNeutral();
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
            gameManager.setCurrentPortal(true);
            gameManager.setPlayerScoreGM(score);
        }
    }

    public void retry()
    {
        showQuiz();
    }

    public void close()
    {
        hideQuiz();
    }

    public void showQuiz()
    {
        switch (gameManager.getCurrentLevel())
        {
            case 0:
                QuizContainer.transform.position = new Vector3(-2.62298346f, 5.0301981f, 3.74675226f);
                break;
            case 1:
                QuizContainer.transform.position = new Vector3(-75.8899994f, -190.529999f, 348.01001f);
                break;
            default:
                QuizContainer.transform.position = new Vector3(-2.62298346f, 5.0301981f, 3.74675226f);
                break;
             
        }
        Quiz.SetActive(true);
        GoPanel.SetActive(false);
        Quizpanel.SetActive(true);
        setUp();
        totoalQuestions = QnA.Count;
        score = 0;
        generateQuestion();
    }

    public void hideQuiz()
    {
        Quiz.SetActive(false);
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

        switch (gameManager.getCurrentLevel())
        {
            case 0:
                question1 = "What is the gravity of the moon?";
                answers1 = new string[] { "1.625 m/s2", "9.255 m/s2", "3.547 m/s2", "7.881 m/s2" };
                correct1 = 1;
                questionAndAnswers1 = new QuestionsAndAnswers(question1, answers1, correct1);

                question2 = "What is the moon made out of";
                answers2 = new string[] { "cheese", "icy materials – water, methane and ammonia", "mostly gas like many other planets", "anorthosite, a calcium rich rock" };
                correct2 = 4;
                questionAndAnswers2 = new QuestionsAndAnswers(question2, answers2, correct2);

                question3 = "What does moon dust smell like?";
                answers3 = new string[] { "roses", "gun powder", "acid", "dish soap" };
                correct3 = 2;
                questionAndAnswers3 = new QuestionsAndAnswers(question3, answers3, correct3);

                quiz1.Add(questionAndAnswers1);
                quiz1.Add(questionAndAnswers2);
                quiz1.Add(questionAndAnswers3);
                QnA = quiz1;
                break;

            case 1:
                question1 = "What is the gravity on mars?";
                answers1 = new string[] { "9.644 m/s2", "3.721 m/s2", "2.437 m/s2", "8.169 m/s2" };
                correct1 = 2;
                questionAndAnswers1 = new QuestionsAndAnswers(question1, answers1, correct1);

                question2 = "Why is the mars red? ";
                answers2 = new string[] { "due to the plants hot temperature", "because it's made up of red phosphorus compounds", "because it's made up of oxidized iron", "due to the sun bleaching out the planets surface" };
                correct2 = 3;
                questionAndAnswers2 = new QuestionsAndAnswers(question2, answers2, correct2);

                question3 = "How many moons does the mars have?";
                answers3 = new string[] { "2", "1", "7", "none" };
                correct3 = 1;
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