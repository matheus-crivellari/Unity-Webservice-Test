using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnNextClicked : MonoBehaviour {

    public void OnNextButtonClicked()
    {
        QuizManager.Instance.NextQuestion();
        QuizManager.Instance.HideFeedback();
    }
}
