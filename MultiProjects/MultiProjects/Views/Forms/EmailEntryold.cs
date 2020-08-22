using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;


namespace MultiProjects.Views.Forms
{
    /// <summary>
    /// View used to show the email entry with validation status.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmailEntryold
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailEntry" /> class.
        /// </summary>
        public EmailEntryold()
        {
            InitializeComponent();
        }
    }

    //[global::Xamarin.Forms.Xaml.XamlFilePathAttribute("Views\\Forms\\EmailEntry.xaml")]
    //public partial class EmailEntry : global::Xamarin.Forms.ContentView
    //{

    //    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    //    private global::MultiProjects.Controls.BorderlessEntry Email;

    //    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    //    private global::Xamarin.Forms.Label ValidationLabel;

    //    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    //    private void InitializeComponent()
    //    {
    //        global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(EmailEntry));
    //        Email = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::MultiProjects.Controls.BorderlessEntry>(this, "Email");
    //        ValidationLabel = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Label>(this, "ValidationLabel");
    //    }
    //}
}
