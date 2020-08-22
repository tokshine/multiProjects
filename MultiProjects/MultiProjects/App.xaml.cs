using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
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

           MainPage = new ShivonetLogin();

            //MainPage = new RoundEdges();//lovely working using custom renderer
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
