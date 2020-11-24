using MultiProjects.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MultiProjects
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReviewPage : ContentPage
	{
		public ReviewPage ()
		{
			InitializeComponent ();
           
            allButton.Resources["ButtonStyle"] = Resources["highLightStyle"];

            AddButtonAllQuestions();



        }

        private void OnClickedCorrectQuestions(object sender, EventArgs args)
        {
                Button button = (Button)sender;
            ResetButtons();
            var questions = QuestionData.GetQuestions.questions.Where(x=>x.IsCorrect);

                AddButtonQuestionsStack(questions,Color.Blue);

                button.Resources["ButtonStyle"] = Resources["highLightStyle"];
                
         
        }

        private void OnClickedAllQuestions(object sender, EventArgs args)
        {
                Button button = (Button)sender;
            ResetButtons();

            AddButtonAllQuestions();

                button.Resources["ButtonStyle"] = Resources["highLightStyle"];

         
        }

        private void OnClickedInCorrectQuestions(object sender, EventArgs args)
        {
                Button button = (Button)sender;
            ResetButtons();
            var questions = QuestionData.GetQuestions.questions.Where(x => !x.IsCorrect);

                AddButtonQuestionsStack(questions,Color.Red);

                button.Resources["ButtonStyle"] = Resources["highLightStyle"];

           
        }


        private void OnClickedFlaggedQuestions(object sender, EventArgs args)
        {
                Button button = (Button)sender;

                ResetButtons();
                var questions = QuestionData.GetQuestions.questions.Where(x => x.IsFlagged);

                AddButtonQuestionsStack(questions,Color.Green);

                button.Resources["ButtonStyle"] = Resources["highLightStyle"];

        }

        private void ResetButtons()
        {
            allButton.Resources["ButtonStyle"] = Resources["DefaultStyle"];
            flagButton.Resources["ButtonStyle"] = Resources["DefaultStyle"];
            InCorrectButton.Resources["ButtonStyle"] = Resources["DefaultStyle"];
            correctButton.Resources["ButtonStyle"] = Resources["DefaultStyle"];


        }

        private void AddButtonAllQuestions()
        {

            var questions = QuestionData.GetQuestions.questions;
            foreach (var q in questions)
            {
                var color = Color.Red;
                if (q.IsCorrect)
                {
                    color = Color.Blue;
                }
                Button digitButton = new Button
                {
                    Text = q.Name,
                    //FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                    CornerRadius = 10,
                    BackgroundColor = color,
                    StyleId = q.Id.ToString()
                };
                stackQuestions.Children.Add(digitButton);
            }
        }

        private void AddButtonQuestionsStack(IEnumerable<Question> questions,Color color)
        {

            stackQuestions.Children.Clear();
            foreach (var q in questions)
            {

                Button digitButton = new Button
                {  // Text = "Question " + num.ToString(),
                    Text = q.Name,
                    //FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                    CornerRadius = 10,
                    BackgroundColor = color,
                    StyleId = q.Id.ToString()
                };
                stackQuestions.Children.Add(digitButton);
            }

        }

        private void OnMainMenuClicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new NavigationPage(new QuizPage());
        }
    }
}