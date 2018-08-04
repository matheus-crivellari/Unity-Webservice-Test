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
    private int score = 0;
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

    /**
     * Tells if the current question is the last.
     */
    public bool IsLastQuestion
    {
        get
        {
            Debug.Log(questions.Count + ", " + currentQuestion);
            return questions.Count-1  == currentQuestion;
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

                    if(canvas)
                        canvas.HideFeedback();

                }),
                new Action<Error>((Error error) => { // Error callback.

                    Debug.Log(error.statusCode + ", " + error.errorMessage);

                })
            );
        }

        _instance = this;
	}

    /**
     * Renders a question on the screen.
     */
    public void RenderQuestion()
    {
        Question q = questions[currentQuestion]; // Gets the current question.

        if (canvas)
        {
            canvas.SetQuestion(q, currentQuestion); // Assigns correct question.
        }
    }

    /**
     * Requests next question to be rendered on screen.
     */
    public void NextQuestion()
    {
        if (currentQuestion < questions.Count)
        {
            currentQuestion++;
            RenderQuestion();
        }
    }

    /**
     * Requests Finished Quiz panel to be displayed.
     */
    public void FinishedQuiz()
    {
        if(canvas)
            canvas.FinishedQuiz();
    }

    /**
     * Requests all feedback panel to be hidden.
     */
    public void HideFeedback()
    {
        if(canvas)
            canvas.HideFeedback();
    }

    /**
     * Responds current question with selected option.
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

        ScoreUp();
        canvas.SetScore(score);
    }

    /**
     * Fails on question.
     */
    public void Failure()
    {
        Debug.Log("Wrong!");
        canvas.Failure();

    }

    /**
     * Scores up. Increse the acumulated value by 10.
     */
    public void ScoreUp()
    {
        score += 10;
    }
}
