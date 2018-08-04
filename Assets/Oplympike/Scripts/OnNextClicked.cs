using UnityEngine;
using UnityEngine.UI;

public class OnNextClicked : MonoBehaviour {

    /**
     * Fired when "Next" Button is clicked.
     */
    public void OnNextButtonClicked()
    {
        if (!QuizManager.Instance.IsLastQuestion)
        {
            QuizManager.Instance.NextQuestion();
            QuizManager.Instance.HideFeedback();
        }
        else
        {
            QuizManager.Instance.FinishedQuiz();
        }
    }
}
