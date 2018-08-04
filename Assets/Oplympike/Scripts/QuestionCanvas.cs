using Quiz;
using UnityEngine;
using UnityEngine.UI;

public class QuestionCanvas : MonoBehaviour {

    #region Serielized Fields
    [SerializeField]
    Text textScore = null;

    [SerializeField]
    Text textTitle = null;

    [SerializeField]
    Text textQuestion = null;

    [SerializeField]
    ButtonOption alternative1 = null;

    [SerializeField]
    ButtonOption alternative2 = null;

    [SerializeField]
    ButtonOption alternative3 = null;

    [SerializeField]
    ButtonOption alternative4 = null;

    [SerializeField]
    GameObject successFeedback = null;

    [SerializeField]
    GameObject failureFeedback = null;
    #endregion

    public void HideFeedback()
    {
        successFeedback.SetActive(false);
        failureFeedback.SetActive(false);
        Debug.Log("HideFeedback");
    }

    public void Success()
    {
        successFeedback.SetActive(true);
    }

    public void Failure()
    {
        failureFeedback.SetActive(true);
    }

    public void SetQuestion(Question question, int questionNumber)
    {
        if (textQuestion)
            textQuestion.text = question.question; // Set question text.

        if (textTitle)
            textTitle.text = "Question " + (questionNumber + 1); // Set question number.

        if (alternative1)
        {
            alternative1.SetText(question.correct_answer); // Set alternative 1.
            alternative1.isCorrect = true;
        }

        if (alternative2)
        {
            alternative2.SetText(question.incorrect_answers[0]); // Set alternative 2.
            alternative2.isCorrect = false;
        }

        if (alternative3)
        {
            if(question.incorrect_answers.Count > 2)
            {
                alternative3.SetText(question.incorrect_answers[1]); // Set alternative 3.
                alternative3.isCorrect = false;
            }
            
        }

        if (alternative4)
        {
            if(question.incorrect_answers.Count > 2)
            {
                alternative4.SetText(question.incorrect_answers[2]); // Set alternative 4.
                alternative4.isCorrect = false;
            }
        }
    }
}
