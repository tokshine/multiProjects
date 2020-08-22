using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
namespace MultiProjects.XForms.Graphics
{
    [Preserve(AllMembers = true)]
    public class DGradientStop : Element
    {
        public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(DGradientStop), (object)Color.Default, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty OffsetProperty = BindableProperty.Create(nameof(Offset), typeof(double), typeof(DGradientStop), (object)0.0, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);

        public Color Color
        {
            get
            {
                return (Color)this.GetValue(DGradientStop.ColorProperty);
            }
            set
            {
                this.SetValue(DGradientStop.ColorProperty, (object)value);
            }
        }

        public double Offset
        {
            get
            {
                return (double)this.GetValue(DGradientStop.OffsetProperty);
            }
            set
            {
                this.SetValue(DGradientStop.OffsetProperty, (object)value);
            }
        }
    }

    [ComVisible(false)]
    public class GradientStopCollection : ObservableCollection<DGradientStop>
    {
    }

    public abstract class DGradientBrush : Element
    {
        public static readonly BindableProperty GradientStopsProperty = BindableProperty.Create(nameof(GradientStops), typeof(GradientStopCollection), typeof(DGradientBrush), (object)null, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DGradientBrush.OnGradientStopsPropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);

        public GradientStopCollection GradientStops
        {
            get
            {
                return (GradientStopCollection)this.GetValue(DGradientBrush.GradientStopsProperty);
            }
            set
            {
                this.SetValue(DGradientBrush.GradientStopsProperty, (object)value);
            }
        }

        private static void OnGradientStopsPropertyChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            (bindable as DGradientBrush).GradientStopsPropertyChanged(oldValue as GradientStopCollection, newValue as GradientStopCollection);
        }

        private void GradientStopsPropertyChanged(
          GradientStopCollection oldValue,
          GradientStopCollection newValue)
        {
            if (oldValue != null)
            {
                foreach (Element element in (Collection<DGradientStop>)oldValue)
                    element.Parent = (Element)null;
                oldValue.CollectionChanged -= new NotifyCollectionChangedEventHandler(this.GradientStops_CollectionChanged);
            }
            if (newValue == null)
                return;
            foreach (Element element in (Collection<DGradientStop>)newValue)
                element.Parent = (Element)this;
            newValue.CollectionChanged += new NotifyCollectionChangedEventHandler(this.GradientStops_CollectionChanged);
        }

        private void GradientStops_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (Element oldItem in (IEnumerable)e.OldItems)
                    oldItem.Parent = (Element)null;
            }
            if (e.NewItems == null)
                return;
            foreach (Element newItem in (IEnumerable)e.NewItems)
                newItem.Parent = (Element)this;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            foreach (BindableObject gradientStop in (Collection<DGradientStop>)this.GradientStops)
                BindableObject.SetInheritedBindingContext(gradientStop, this.BindingContext);
        }
    }

    [Preserve(AllMembers = true)]
    public class DLinearGradientBrush : DGradientBrush
    {
        public static readonly BindableProperty StartPointProperty = BindableProperty.Create(nameof(StartPoint), typeof(Point), typeof(DLinearGradientBrush), (object)new Point(0.0, 0.0), BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty EndPointProperty = BindableProperty.Create(nameof(EndPoint), typeof(Point), typeof(DLinearGradientBrush), (object)new Point(1.0, 1.0), BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);

        public DLinearGradientBrush()
        {
            this.GradientStops = new GradientStopCollection();
        }

        public Point StartPoint
        {
            get
            {
                return (Point)this.GetValue(DLinearGradientBrush.StartPointProperty);
            }
            set
            {
                this.SetValue(DLinearGradientBrush.StartPointProperty, (object)value);
            }
        }

        public Point EndPoint
        {
            get
            {
                return (Point)this.GetValue(DLinearGradientBrush.EndPointProperty);
            }
            set
            {
                this.SetValue(DLinearGradientBrush.EndPointProperty, (object)value);
            }
        }
    }

}