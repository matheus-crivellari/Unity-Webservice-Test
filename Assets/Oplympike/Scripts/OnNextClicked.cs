using UnityEngine;
using UnityEngine.UI;

public class OnNextClicked : MonoBehaviour {

    private Button button = null;

    private void Start()
    {
        button = GetComponent<Button>();
    }

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
