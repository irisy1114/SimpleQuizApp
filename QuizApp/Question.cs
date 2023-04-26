using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp
{
    class Question
    {
        public string QuestionTitle { get; set; }
        public Question(string title)
        {
            this.QuestionTitle = title;
        }
    }    
}
