using System;
using Raylib_cs;
public class Question : QuizManager
{
    public string question;
    public string[] allAnswers = new string[4];
    public string selectedAnswer;
    public Question(string question, string[] answers)
    {
        this.question = question;
        this.allAnswers = answers;
        QuizManager.allQuestions.Add(this);
    }
}