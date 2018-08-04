using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTryAgainClicked : MonoBehaviour {

    /**
     * Fired when Try Again Button is clicked.
     */
	public void OnTryAgainButtonClicked()
    {
        QuizManager.Instance.Restart();
    }
}
