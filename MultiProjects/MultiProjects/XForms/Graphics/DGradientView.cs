using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace MultiProjects.XForms.Graphics
{
    [Preserve(AllMembers = true)]
    [DesignTimeVisible(true)]
    public class DGradientView : View
    {
        public static readonly BindableProperty BackgroundBrushProperty = BindableProperty.Create(nameof(BackgroundBrush), typeof(DGradientBrush), typeof(DGradientView), (object)null, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DGradientView.OnBackgroundBrushPropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);

        public DGradientBrush BackgroundBrush
        {
            get
            {
                return (DGradientBrush)this.GetValue(DGradientView.BackgroundBrushProperty);
            }
            set
            {
                this.SetValue(DGradientView.BackgroundBrushProperty, (object)value);
            }
        }

        private static void OnBackgroundBrushPropertyChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            (bindable as DGradientView).BackgroundBrushPropertyChanged(oldValue as DGradientBrush, newValue as DGradientBrush);
        }

        private void BackgroundBrushPropertyChanged(DGradientBrush oldValue, DGradientBrush newValue)
        {
            if (oldValue != null)
                oldValue.Parent = (Element)null;
            if (newValue == null)
                return;
            newValue.Parent = (Element)this;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (this.BackgroundBrush == null)
                return;
            BindableObject.SetInheritedBindingContext((BindableObject)this.BackgroundBrush, this.BindingContext);
        }
    }
}
