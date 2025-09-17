using UnityEngine;
using System.Collections.Generic;
using System.Collections;   
using System.Linq;
public class QuizGameManager : Singleton<QuizGameManager>
{
    public UnitModel Science;
    public QuestionModel GetQuestionForLesson (string unitName)
    {
        LessonsModel lessonModel = Science.Lessons.FirstOrDefault(lesson => lesson.LessonTitle == unitName);
        if (lessonModel != null)
        {
            return lessonModel.Question[0];
        }
        return null;
    }



}
