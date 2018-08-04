using UnityEngine;
using UnityEngine.UI;

public class FinishedPanel : MonoBehaviour {

    [SerializeField]
    private Text finalScore = null;

    /**
     * Displays the final score at Finished panel.
     */
    public void SetFinalScore(int score)
    {
        finalScore.text = score.ToString("D4"); // Format score value to display with four leading zeroes.

    }
}
