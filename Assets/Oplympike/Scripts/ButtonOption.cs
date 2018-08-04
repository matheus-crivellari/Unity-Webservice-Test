using UnityEngine;
using UnityEngine.UI;

public class ButtonOption : MonoBehaviour {

    /**
     * Text value corresponding to the current quiz option/alternative.
     */
    [SerializeField]
    private Text textAlternative = null;

    /**
     * Tells if this is the correct option.
     */
    public bool isCorrect = false;

    /**
     * Assigns the text to button's Text component.
     */
    public void SetText(string text)
    {
        if (textAlternative)
            textAlternative.text = text;
    }

    /**
     * Fired when an alternative is selected.
     */
    public void OnAlternativeSelected()
    {
        QuizManager.Instance.Respond(this);
    }
}
