using System;
using System.Collections.Generic;

namespace Quiz
{
    [Serializable]
    public class Question
    {
        public string category;
        public string type;
        public string difficulty;
        public string question;
        public string correct_answer;
        public List<string> incorrect_answers;
    }

    [Serializable]
    public class Response
    {
        public int response_code;
        public List<Question> results;
    }
}
