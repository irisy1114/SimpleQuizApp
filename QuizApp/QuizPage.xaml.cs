using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizPage : ContentPage
    {
        public QuizPage()
        {
            InitializeComponent();
            LoadQuestions();
        }        

        List<Question> questions = new List<Question>()
        { new Question("I love to meet new people."),
          new Question("I like to try out new things."),
          new Question("I would rather spend time with a bunch of people than one close friend."),
          new Question("I describe my emotional experiences vividly."),
          new Question("I am the life of the party.")
        };

        List<string> truePersonalities = new List<string>()
        {
            "Couragous", "Brave", "Open", "Outgoing", "Cheerful"
        };

        List<string> falsePersonalities = new List<string>()
        {
            "Introverted", "Conservative", "Sensative", "Vulnerable", "Shy"
        };

        int falseCount = 0;
        int trueCount = 0;
        List<int> questionList = new List<int>();

        void True_Clicked(object sender, EventArgs e)
        {
            trueCount++;
            CheckQuestions();
        }
        void False_Clicked(object sender, EventArgs e)
        {
            falseCount++;
            CheckQuestions();
        }

        void Restart_Clicked(object sender, EventArgs e)
        {
            //reset true/false count, questionList
            trueCount = 0;
            falseCount = 0;
            questionList = new List<int>();
            RestartButton.IsVisible = false;
            TrueButton.IsVisible = true;
            FalseButton.IsVisible = true;
            LoadQuestions();           
        }

        void LoadQuestions()
        {
            var index = GenerateUniqueNumber(5, questionList);
            question.Text = questions[index].QuestionTitle;                        
        }

        void CheckQuestions()
        {
            int questionCount = trueCount + falseCount;
            if(questionCount == 5)
            {
                TrueButton.IsVisible = false;
                FalseButton.IsVisible = false;

                GeneratePersonality();
            }
            else
            {
                LoadQuestions();
            }
        }
        void GeneratePersonality()
        {
            string personality = "";
            for(int i = 0; i < trueCount; i++)
            {
                int number = GenerateUniqueNumber(5, new List<int>());
                personality += (truePersonalities[number] + ", ");
            }

            for (int i = 0; i < falseCount; i++)
            {
                int number = GenerateUniqueNumber(5, new List<int>());
                personality += (falsePersonalities[number] + ", ");
            }
            question.Text = "You are a " + personality + " person.";
            RestartButton.IsVisible = true;
        }
        int GenerateUniqueNumber(int range, List<int> numbers)
        {
            // generate unique random number
            Random random = new Random();
            int number;
            do
            {
                number = random.Next(range);
            } while (numbers.Contains(number));
            numbers.Add(number);
            return number;
        }
    }
}