using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MultiProjects.ControlTemplate
{
    public class CardView : ContentView
    {
        public static readonly BindableProperty CardTitleProperty = BindableProperty.Create(nameof(CardTitle), typeof(string), typeof(CardView), string.Empty);
        public static readonly BindableProperty CardDescriptionProperty = BindableProperty.Create(nameof(CardDescription), typeof(string), typeof(CardView), string.Empty);
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(string), typeof(CardView),string.Empty);

        public static readonly BindableProperty IconBackgroundColorProperty = BindableProperty.Create(nameof(IconBackgroundColor), typeof(string), typeof(CardView), string.Empty);
        public static readonly BindableProperty IconImageSourceProperty = BindableProperty.Create(nameof(IconImageSource), typeof(string), typeof(CardView), string.Empty);

        public string IconBackgroundColor
        {
            get => (string)GetValue(IconBackgroundColorProperty);
            set => SetValue(IconBackgroundColorProperty, value);
        }

        public string IconImageSource
        {
            get => (string)GetValue(IconImageSourceProperty);
            set => SetValue(IconImageSourceProperty, value);
        }
        public string BorderColor
        {
            get
            {
                return (string)this.GetValue(BorderColorProperty);
            }
            set
            {
                this.SetValue(BorderColorProperty, value);
            }
        }

        public string CardTitle
        {
            get => (string)GetValue(CardTitleProperty);
            set => SetValue(CardTitleProperty, value);
        }

        public string CardDescription
        {
            get => (string)GetValue(CardDescriptionProperty);
            set => SetValue(CardDescriptionProperty, value);
        }      
    }
}
