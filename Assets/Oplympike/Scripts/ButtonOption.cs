using UnityEngine;
using UnityEngine.UI;

public class ButtonOption : MonoBehaviour {

    [SerializeField]
    private Text textAlternative = null;

    public bool isCorrect = false;

    public void SetText(string text)
    {
        if (textAlternative)
            textAlternative.text = text;
    }

    public void OnAlternativeSelected()
    {
        QuizManager.Instance.Respond(this);
    }
}
