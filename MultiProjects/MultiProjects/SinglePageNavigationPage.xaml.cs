
using MultiProjects.Data;
using MultiProjects.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using Xamarin.Forms;

using Xamarin.Forms.Xaml;

namespace MultiProjects
{
    public class Quiz
    {
        public string Id { get; set; }
        public string name { get; set; }
     
        public string description { get; set; }
    }

    //https://www.c-sharpcorner.com/article/working-with-json-string-in-C-Sharp/
    //visit issue case later
   

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SinglePageNavigationPage : ContentPage
    {
        static int count = 0;
        static bool firstPageAppeared = false;
        static readonly string separator = new string('-', 20);

       static TimerViewModel _timerViewModel;

     
        

        async void OnTimeoutPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (_timerViewModel!=null && !_timerViewModel.IsVisiblePrevNavButton)
            {
                // _timerViewModel.StartTime = TimeSpan.FromSeconds(0);
                _timerViewModel = null;
                count = 0;
                firstPageAppeared = false;
                Application.Current.Properties["TimerStatus"] = string.Empty;
                await Navigation.PushAsync(new SummaryResult());
            }
        }

        public SinglePageNavigationPage()
        {

            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            Resources["ButtonStyle"] = Resources["answerStyle"];

            Resources["FlagButtonStyle"] = Resources["flagDefaultStyle"];

            // Set Title to zero-based instance of this class.
            int questionNumber = (count++) +1;

           
            if ((bool)Application.Current.Properties["IsNewQuiz"])
            {
                var subject = Application.Current.Properties["subject"] + ".json";
                QuestionData.InitialiseQuestions(subject);           
                Application.Current.Properties["IsNewQuiz"] = false;
            }           


            IDictionary<string, object> properties = Application.Current.Properties;
            if (properties.ContainsKey("TimerStatus") && (string)properties["TimerStatus"] == "Started")
            {
                //timer has started
            }
            else {
                //reset
                QuestionData.GetQuestions.Reset();                   
                _timerViewModel = new TimerViewModel();               
                _timerViewModel.IsVisiblePrevNavButton = true;
                //_timerViewModel.IsVisibleFinishButton = false;
                Application.Current.Properties["TimerStatus"] = "Started";
            }
            var numberOfQuestions = QuestionData.GetQuestions.questions.Count;
            Title = "Q" + questionNumber + " of " + numberOfQuestions;
            BindingContext = _timerViewModel;
          
        }

        async void OnGoToModelessFinishClicked(object sender, EventArgs args)
        {

            // _timerViewModel.StartTime = TimeSpan.FromSeconds(0);
            _timerViewModel = null;
            count = 0;
            firstPageAppeared = false;
            Application.Current.Properties["TimerStatus"] = string.Empty;
            await Navigation.PushAsync(new SummaryResult());           
            
        }

        async void OnGoToModelessClicked(object sender, EventArgs args)
        {
            SinglePageNavigationPage newPage = new SinglePageNavigationPage();
            Debug.WriteLine(separator);
            Debug.WriteLine("Calling PushAsync from {0} to {1}", this, newPage);
            await Navigation.PushAsync(newPage);
            Debug.WriteLine("PushAsync completed");

            // Display the page stack information on this page.
            newPage.DisplayInfo();
        }


     
        
        async void OnGoBackModelessClicked(object sender, EventArgs args)
        {
            Debug.WriteLine(separator);
            Debug.WriteLine("Calling PopAsync from {0}", this);
            Page page = await Navigation.PopAsync();
            count--;
            Debug.WriteLine("PopAsync completed and returned {0}", page);

            // Display the page stack information on the page being returned to.
            NavigationPage navPage = (NavigationPage)App.Current.MainPage;
            ((SinglePageNavigationPage)navPage.CurrentPage).DisplayInfo();
        }

        //async void OnAnswer3(object sender, EventArgs args)
        //{
        //    Button button = (Button)sender;

        //    if (button.BackgroundColor == Color.Blue)
        //    {
        //        button.Resources["ButtonStyle"] = Resources["selectedAnswerStyle"];
        //    }
        //    else
        //    {

        //        button.Resources["ButtonStyle"] = Resources["answerStyle"];
        //    }
        //}

        //async void OnAnswer2(object sender, EventArgs args)
        //{
        //    Button button = (Button)sender;         
                                 
        //        if (button.BackgroundColor == Color.Blue)
        //        {
        //            button.Resources["ButtonStyle"] = Resources["selectedAnswerStyle"];
        //        }
        //        else {

        //            button.Resources["ButtonStyle"] = Resources["answerStyle"];
        //        }
                
           
        //}

        void OnClickedHomePage(object sender, EventArgs args)
        {
            count = 0;
            _timerViewModel = null;
            Application.Current.Properties["TimerStatus"] = string.Empty;
            firstPageAppeared = false;
            App.Current.MainPage = new NavigationPage(new QuizPage());
        }

        async void OnFlagged(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            if (button.BackgroundColor == Color.LightGray)
            {
                button.Resources["FlagButtonStyle"] = Resources["flagQuestionStyle"];
            }
            else
            {

                button.Resources["FlagButtonStyle"] = Resources["flagDefaultStyle"];
            }

        }

        async void OnAnswer1(object sender, EventArgs args)
        {

            Button button = (Button)sender;

            if (button.BackgroundColor == Color.Purple)
            {
                button.Resources["ButtonStyle"] = Resources["selectedAnswerStyle"];
            }
            else
            {

                button.Resources["ButtonStyle"] = Resources["answerStyle"];
            }
            //saving in transient data
            //Application.Current.Properties["displayLabelText"] = displayLabel.Text;

            //Retrieving saved data
            //IDictionary<string, object>  properties = Application.Current.Properties;
            //if (properties.ContainsKey("displayLabelText")) { displayLabel.Text = properties["displayLabelText"] as string;
            //backspaceButton.IsEnabled = displayLabel.Text.Length > 0; }


            //other tips 
            // different buttons but same command pg 525
            //different buttons but same event handler 118
        }
        

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Debug.WriteLine("{0} OnAppearing", Title);

            if (!firstPageAppeared)
            {
                DisplayInfo();
                firstPageAppeared = true;
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Debug.WriteLine("{0} OnDisappearing", Title);
        }

        // Identify each instance by its Title.
        public override string ToString()
        {
            return Title;
        }

        public void DisplayInfo()
        {
            // Get the NavigationPage and display its CurrentPage property.
            NavigationPage navPage = (NavigationPage)App.Current.MainPage;

            //currentPageLabel.Text = String.Format("NavigationPage.CurrentPage = {0}",
            //                                      navPage.CurrentPage);
           var  questions = QuestionData.GetQuestions.questions.ToArray();

            if (count < 1)
            {
                return;
            }


            var whichQuestion = questions[count -1];
            _timerViewModel.Id = whichQuestion.Id;
           questionLabel.Text = whichQuestion.Name;

            answer1.Text = whichQuestion.Options[0].Name;
            answer1.CommandParameter = whichQuestion.Options[0].Id;

            if (whichQuestion.Options[0].IsSelected)
            {
                answer1.Resources["ButtonStyle"] = Resources["selectedAnswerStyle"];
            }          

            answer1.Command = answer2.Command=answer3.Command= answer4.Command =_timerViewModel.ProcessAnswerCommand;

            flagQuestion.Command = _timerViewModel.FlagQuestionCommand;
            flagQuestion.CommandParameter = whichQuestion.Id;

            answer2.Text = whichQuestion.Options[1].Name;
            answer2.CommandParameter = whichQuestion.Options[1].Id;

            if (whichQuestion.Options[1].IsSelected)
            {
                answer2.Resources["ButtonStyle"] = Resources["selectedAnswerStyle"];
            }

            answer3.Text = whichQuestion.Options[2].Name;
            answer3.CommandParameter = whichQuestion.Options[2].Id;

            if (whichQuestion.Options[2].IsSelected)
            {
                answer3.Resources["ButtonStyle"] = Resources["selectedAnswerStyle"];
            }

            answer4.Text = whichQuestion.Options[3].Name;
            answer4.CommandParameter = whichQuestion.Options[3].Id;


            if (whichQuestion.Options[3].IsSelected)
            {
                answer4.Resources["ButtonStyle"] = Resources["selectedAnswerStyle"];
            }

            // Get the navigation stacks from the NavigationPage.
            IReadOnlyList<Page> navStack = navPage.Navigation.NavigationStack;
            IReadOnlyList<Page> modStack = navPage.Navigation.ModalStack;

            // Display the counts and contents of these stack.
            int modelessCount = navStack.Count;
            int modalCount = modStack.Count;

            //modelessStackLabel.Text = String.Format("NavigationStack has {0} page{1}{2}",
            //                                        modelessCount,
            //                                        modelessCount == 1 ? "" : "s",
            //                                        ShowStack(navStack));

            //modalStackLabel.Text = String.Format("ModalStack has {0} page{1}{2}",
            //                                     modalCount,
            //                                     modalCount == 1 ? "" : "s",
            //                                     ShowStack(modStack));

            // Enable and disable buttons based on the counts.
            bool noModals = modalCount == 0 || (modalCount == 1 && modStack[0] is NavigationPage);

           // modelessGoToButton.IsEnabled = noModals;
            modelessBackButton.IsEnabled = modelessCount > 1 && noModals; //not a perfect line for now
            //modalBackButton.IsEnabled = !noModals;
         
                // modelessGoToButton.IsVisible = count < questions.Length;
            _timerViewModel.IsVisibleNextNavButton = count < questions.Length;
           
               
           // modelessGoToButton.IsEnabled = count < questions.Length;
            //finishButton.IsVisible = count == questions.Length;
           // _timerViewModel.IsVisibleFinishButton = count == questions.Length; 
        }

        string ShowStack(IReadOnlyList<Page> pageStack)
        {
            if (pageStack.Count == 0)
                return "";

            StringBuilder builder = new StringBuilder();

            foreach (Page page in pageStack)
            {
                builder.Append(builder.Length == 0 ? " (" : ", ");
                builder.Append(StripNamespace(page));
            }

            builder.Append(")");
            return builder.ToString();
        }

        string StripNamespace(Page page)
        {
            string pageString = page.ToString();

            if (pageString.Contains("."))
                pageString = pageString.Substring(pageString.LastIndexOf('.') + 1);

            return pageString;
        }

    
    }
}