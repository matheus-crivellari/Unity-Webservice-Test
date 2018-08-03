using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

using Quiz;

public class QuizRequest : MonoBehaviour {

    [SerializeField]
    private string baseUrl = "https://opentdb.com/api.php";

	void Start () {
        StartCoroutine(RequestQuiz());
	}
	
	IEnumerator RequestQuiz()
    {
        List<IMultipartFormSection> form = new List<IMultipartFormSection>();

        UnityWebRequest req = UnityWebRequest.Get(baseUrl + "?amount=10");

        yield return req.SendWebRequest();

        if (req.isNetworkError || req.isHttpError)
        {
            
            OnError(req.responseCode, req.error);
        }
        else
        {
            byte[] byteResponse = req.downloadHandler.data;
            Success(QuizRequest.ToText(byteResponse));
        }
    }

    public static string ToText(byte[] bytes)
    {
        return System.Text.Encoding.Default.GetString(bytes);
    }

    public void OnError(long statusCode, string errorMessage)
    {

    }

    public void Success(string response)
    {
        Response res = JsonUtility.FromJson<Response>(response);
        Debug.Log(res.results[0].incorrect_answers[0]);

        foreach(Question q in res.results)
        {
            Debug.Log(q.category);
        }
    }
}