[System.Serializable]

public class QuestionsAndAnswers
{
    public string Question;
    public string[] Answers;
    public int CorrectAnswer;

    public QuestionsAndAnswers(string q, string[] a, int correctA)
    {
        Question = q;
        Answers = a;
        CorrectAnswer = correctA;
    }
}
