using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MultiProjects
{
    public class FramedTextPage : ContentPage
    {
        public FramedTextPage()
        {
            Padding = new Thickness(20);
            //Padding = new Thickness(5, Device.OnPlatform(20, 5, 5), 5, 5);
            Padding = new OnPlatform<Thickness> { iOS = new Thickness(0, 20, 0, 0), Android = new Thickness(5), WinPhone = new Thickness(5) };
            Content = new Frame
            {
                //OutlineColor = Color.Accent,
                OutlineColor = Color.Default,
                Content = new Label
                {
                    Text = "I've been framed!",
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                }
            };

            
        }
    }
}
