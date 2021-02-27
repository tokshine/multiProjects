using MultiProjects.ControlTemplate;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)] 
//commented this to avoid conflict with Assemblyinfo

namespace MultiProjects
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new MainPageView();
            //MainPage = new ContentPageView();

            //Navigation methods

            //MainPage = new NavigationPage(new NavigationPageView());
            //MainPage = new TabbedPageView();//icons are visible
            //MainPage = new CarouselPageView();//use case list of images ??
            //MainPage = new MasterDetailPageView();handburger approach

            // MainPage = new ModalPageView();
            // MainPage = new LoginWithStackLayout(); //login sample

            //  MainPage = new NestedGridLayoutPage();
            // MainPage = new FlexLayoutPage(); //WidthRequest="125" switches the imagelist 3 in a row

            //Listview in action
            // MainPage = new  NavigationPage(new PieOverview());

            //MainPage = new LoginPageWithStyling();//with different kind of styling |remember to enable styling in app.xaml --- DynamicResource

            //  MainPage = new ShivonetLogin();
            // MainPage = new RoundEdges();
            MainPage = new NavigationPage(new QuizPage())
            {
                BarBackgroundColor = Color.Gray
            };

            //   MainPage = new MaterialLogin(); //probably best graphic
            // MainPage = new MainShell();//Removing the any default navigation bar and using shell


            //MainPage = new NavigationPage(new SinglePageNavigationPage())
            //{
            //    BarBackgroundColor = Color.Gray
            //};

            // MainPage = new FramedTextPage();

            //MainPage = new Cards();
            //use of control template ,template was applied to Cards page https://www.youtube.com/watch?v=oah-Q1kPOyI
            //note CardViewControlTemplate is not in use yet
            //my template is directly in cards.xaml
            //TODO:it would be good to separate the template into a file is it possible ??

            // In fact, the TemplateBinding markup extension creates a Binding whose Source is RelativeBindingSource.TemplatedParent
            //TemplateBinding is an alternative for  RelativeBindingSource.TemplatedParent
            //MainPage = new RoundEdges();//lovely working using custom renderer
            //  MainPage = new TriggerEntryValidation(); //chapter 23
            // MainPage = new CardBindToViewModel();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
