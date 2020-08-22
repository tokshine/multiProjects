using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MultiProjects.MyCustomControl
{
    public class SvEntry :Entry
    {
        //public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(SvEntry), Color.Gray);
        //, (object)Color.Blue, BindingMode.TwoWay, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);

        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(SvEntry), Device.OnPlatform<double>(6, 7, 7));

        public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(nameof(BorderWidth), typeof(int), typeof(SvEntry), Device.OnPlatform<int>(1, 2, 2));
        //, (object)new Thickness(40), BindingMode.TwoWay, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);


        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(SvEntry),Color.Black);


        public Color BorderColor
        {
            get
            {
                return (Color)this.GetValue(BorderColorProperty);
            }
            set
            {
                this.SetValue(BorderColorProperty, value);
            }
        }


        public double CornerRadius
        {
            get
            {
                return (double)this.GetValue(CornerRadiusProperty);
            }
            set
            {
                this.SetValue(CornerRadiusProperty, value);
            }
        }


        public int BorderWidth
        {
            get
            {
                return (int)this.GetValue(BorderWidthProperty);
            }
            set
            {
                this.SetValue(BorderWidthProperty, value);
            }
        }
    }
}
