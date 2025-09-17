using TMPro;
using UnityEngine;

public class QuestionUI : MonoBehaviour
{
    public TextMeshProUGUI questionlabel;

    public TextMeshProUGUI answer1Texts;

    public TextMeshProUGUI answer2Texts;
    public TextMeshProUGUI answer3Texts;
    public TextMeshProUGUI answer4Texts;

    public void PopulateQuestion(QuestionModel questionModel)
    {
        questionlabel.text = questionModel.Question;
        answer1Texts.text = questionModel.Answer1;
        answer2Texts.text = questionModel.Answer2;
        answer3Texts.text = questionModel.Answer3;
        answer4Texts.text = questionModel.Answer4;
    }
    
}

           