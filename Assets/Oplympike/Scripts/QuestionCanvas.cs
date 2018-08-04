using Quiz;
using System.Text;
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

    [SerializeField]
    GameObject panelLoading = null;

    [SerializeField]
    GameObject panelFinished = null;
    #endregion

    /**
     * Hides all feedback panels.
     */
    public void HideFeedback()
    {
        if(successFeedback)
            successFeedback.SetActive(false);

        if(failureFeedback)
            failureFeedback.SetActive(false);

        if(panelLoading)
            panelLoading.SetActive(false);

        if (panelFinished)
            panelFinished.SetActive(false);
    }

    /**
     * Displays Success feedback panel.
     */
    public void Success()
    {
        if(successFeedback)
            successFeedback.SetActive(true);
    }

    /**
     * Displays Failure feedback panel.
     */
    public void Failure()
    {
        if(failureFeedback)
            failureFeedback.SetActive(true);
    }

    /**
     * Sets score display value.
     */
    public void SetScore(int score)
    {
        if (textScore)
            textScore.text = score.ToString("D4"); // Format score value to display with four leading zeroes.
    }

    /**
     * Displays Finished feedback panel.
     */
    public void FinishedQuiz()
    {
        if (panelFinished)
            panelFinished.SetActive(true);
    }

    /**
     * Displays a new question on the screen.
     */
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
