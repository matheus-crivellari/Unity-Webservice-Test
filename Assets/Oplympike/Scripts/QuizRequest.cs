using System;
using System.Collections;

using UnityEngine;
using UnityEngine.Networking;

using Quiz;

public class QuizRequest : MonoBehaviour {

    [SerializeField]
    /*
     * Base webservice url.
     */
    private string baseUrl = "https://opentdb.com/api.php";

    [SerializeField]
    /**
     * Desired question amount to be returnd;
     */
    private int questionAmount = 10;

    /**
     * Stores a success callback to be called later.
     */
    private Action<Response> successCallback = null;

    /**
     * Stores an error callback to be called later.
     */
    private Action<Error> errorCallback = null;

    #region Private Methods
    /**
     * Performs a web resquest to retrieve the quiz.
     */
    private IEnumerator RequestQuiz()
    {
        string url = baseUrl + "?amount=" + questionAmount.ToString();
        UnityWebRequest req = UnityWebRequest.Get(url);

        yield return req.SendWebRequest();

        if (req.isNetworkError || req.isHttpError)
        {
            OnError(req.responseCode, req.error);
        }
        else
        {
            byte[] byteResponse = req.downloadHandler.data;
            Success(ToText(byteResponse));
        }
    }

    /**
     * Called when web request returns an error.
     */
    private void OnError(long statusCode, string errorMessage)
    {
        Error error = new Error
        {
            statusCode = statusCode,
            errorMessage = errorMessage
        };
        errorCallback(error);
    }

    /**
     * Called when web request returns a success.
     */
    private void Success(string response)
    {
        Response res = JsonUtility.FromJson<Response>(response);
        successCallback(res);
    }
    #endregion

    #region Public Interface
    /**
     * Converts simples binary data byte[] to string.
     */
    public static string ToText(byte[] bytes)
    {
        return System.Text.Encoding.Default.GetString(bytes);
    }

    /**
     * Performs the request and assigns success and error callbacks.
     * Similar to jQuery's Ajax implementation.
     */
    public void Request(Action<Response> successCallback, Action<Error> errorCallback)
    {
        this.successCallback = successCallback;
        this.errorCallback = errorCallback;
        StartCoroutine(RequestQuiz());
    }
    #endregion
}