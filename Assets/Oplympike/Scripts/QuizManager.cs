using System;
using System.Collections.Generic;

using UnityEngine;
using Quiz;

public class QuizManager : MonoBehaviour {

    #region Static Field
    private static QuizManager _instance = null;
    #endregion

    #region Serialized Fields
    /**
     * Receives the api.
     */
    [SerializeField]
    private QuizRequest api = null;

    [SerializeField]
    private QuestionCanvas canvas = null;
    #endregion

    #region Private Fields
    private List<Question> questions;
    private int currentQuestion = 0;
    #endregion

    #region Public Properties
    /**
     * Singleton getter.
     * Readonly.
     */
    public static QuizManager Instance
    {
        get
        {
            return _instance;
        }
    }
    #endregion

    void Start () {
        if (api) // Checks if the api is present.
        {
            /**
             * Request quize's questions.
             */
            api.Request(
                new Action<Response>((Response response) => { // Success callback.

                    questions = response.results;

                    RenderQuestion();

                }),
                new Action<Error>((Error error) => { // Error callback.

                    Debug.Log(error.statusCode + ", " + error.errorMessage);

                })
            );
        }

        _instance = this;
	}

    public void RenderQuestion()
    {
        Question q = questions[currentQuestion]; // Gets the current question.

        if (canvas)
        {
            canvas.SetQuestion(q, currentQuestion); // Assigns correct question.
        }
    }

    public void NextQuestion()
    {
        if (currentQuestion < questions.Count)
            currentQuestion++;

        RenderQuestion();
    }

    public void HideFeedback()
    {
        canvas.HideFeedback();
    }

    /**
     * Respond current question with selected option.
     */
    public void Respond(ButtonOption selectedOption)
    {
        if (selectedOption.isCorrect)
        {
            Success();
        }
        else
        {
            Failure();
        }
    }

    /**
     * Succeed on question.
     */
    public void Success()
    {
        Debug.Log("Correct!");
        canvas.Success();
    }

    /**
     * Fails on question.
     */
    public void Failure()
    {
        Debug.Log("Wrong!");
        canvas.Failure();

    }
}
