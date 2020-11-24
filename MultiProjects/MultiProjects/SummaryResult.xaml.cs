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
	public partial class SummaryResult : ContentPage
	{
		public SummaryResult ()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent ();
            Result();
        }

        private void Result()
        {
           var questions =   QuestionData.GetQuestions.questions;

            var answered = questions.Where(x => x.IsCorrect).Count();

            var notAnswered = questions.Count - answered;

            var flagged = questions.Where(x => x.IsFlagged).Count();

            lblCorrect.Text = string.Format("Correct: {0}/{1}",answered,questions.Count);

            lblIncorrect.Text = string.Format("Incorrect: {0}/{1}", notAnswered, questions.Count);

            lblFlagged.Text = string.Format("Flagged: {0}", flagged);
        }

        async void OnReviewClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ReviewPage());
        }

        private void OnMainMenuClicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new NavigationPage(new QuizPage());            
        }
    }
}