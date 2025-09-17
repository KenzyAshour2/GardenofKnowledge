using UnityEngine;

public class QuestionManager : Singleton<QuestionManager>
{
    public QuestionUI question;
    private QuizGameManager quizGameManager;
    public string LessonName;

    private void OnEnable()
    {
        quizGameManager = QuizGameManager.Instance;
        LoadNextQuestion();
    }
    void LoadNextQuestion()
    {
        var newQuestion = quizGameManager.GetQuestionForLesson(LessonName);
        if (newQuestion != null) 
        {
            question.PopulateQuestion(newQuestion);
        }

    }
}
