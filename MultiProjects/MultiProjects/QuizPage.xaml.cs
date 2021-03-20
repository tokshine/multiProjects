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
	public partial class QuizPage : ContentPage
	{
		public QuizPage ()
		{
			InitializeComponent ();           
        }

        private async void OnQuestionCategoryClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;            
            await Navigation.PushAsync(new QuizSelected(button.StyleId));
               
        }
    }
}