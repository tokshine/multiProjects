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
	public partial class QuizSelected : ContentPage
	{
		public QuizSelected(string subject)
		{
			InitializeComponent ();

            if (subject == "csharp")
            {
                selectedQuiz.Text = "Welcome to C# Quiz";
            }
            if (subject == "aspnet")
            {
                selectedQuiz.Text = "Welcome to ASP.NET Quiz";
            }
            if (subject == "designpatterns")
            {
                selectedQuiz.Text = "Welcome to Design Patterns Quiz";
            }
            Application.Current.Properties["subject"] = subject;
            Application.Current.Properties["IsNewQuiz"] = true;
        }

        //private async void OnStartClicked(object sender, EventArgs args)
        private   void OnStartClicked(object sender, EventArgs args)
        {

            Application.Current.Properties["TimerStatus"] = "";
            //change page root


            //method 1
            //NavigationPage navPage = (NavigationPage)App.Current.MainPage;
            //IReadOnlyList<Page> navStack = navPage.Navigation.NavigationStack;

            //navPage.Navigation.RemovePage(
            //        navStack[navStack.Count - 2]);//remove QuizPage

            //Navigation.InsertPageBefore(new SinglePageNavigationPage(), this);//the two lines help remove QuizCategoryInfo page           
            //await Navigation.PopAsync(); //..and then the mainpage becomes  SinglePageNavigationPage


            //method 2

             App.Current.MainPage = new NavigationPage(new SinglePageNavigationPage());

            //await Navigation.PushAsync(new NavigationPage(new SinglePageNavigationPage()));


        }
    }
}