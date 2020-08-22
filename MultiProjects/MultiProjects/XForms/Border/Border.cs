using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace MultiProjects.XForms.Border
{
    internal interface IParentThemeElement : IThemeElement
    {
        ResourceDictionary GetThemeDictionary();
    }

    internal interface IThemeElement
    {
        void OnControlThemeChanged(string oldTheme, string newTheme);

        void OnCommonThemeChanged(string oldTheme, string newTheme);
    }

    [Preserve(AllMembers = true)]
    [DesignTimeVisible(true)]
    public class DBorder : ContentView, IParentThemeElement, IThemeElement
    {
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(DBorder), (object)Color.Black, BindingMode.TwoWay, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(nameof(BorderWidth), typeof(double), typeof(DBorder), (object)1.0, BindingMode.TwoWay, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DBorder.OnBorderWidthChanged), (BindableProperty.BindingPropertyChangingDelegate)null, new BindableProperty.CoerceValueDelegate(DBorder.OnBorderWidthCoerceChanged), (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(Thickness), typeof(DBorder), (object)new Thickness(40), BindingMode.TwoWay, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public new static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(DBorder), (object)Color.Transparent, BindingMode.TwoWay, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty HasShadowProperty = BindableProperty.Create(nameof(HasShadow), typeof(bool), typeof(DBorder), (object)false, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DBorder.OhHasShadowChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty ShadowColorProperty = BindableProperty.Create(nameof(ShadowColor), typeof(Color), typeof(DBorder), (object)Color.FromRgba(0, 0, 0, 115), BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty DashArrayProperty = BindableProperty.Create(nameof(DashArray), typeof(double[]), typeof(DBorder), (object)new double[2], BindingMode.TwoWay, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DBorder.OnDashArrayChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        
        public DBorder()
        {
           //this.ValidateLicense();
           // ThemeElement.InitializeThemeResources((Element)this, "SfBorderTheme");
           // this.CornerRadius = 20;
            this.BorderWidth = 1;

            // this.ValidateLicense();
            //ThemeElement.InitializeThemeResources((Element)this, "SfBorderTheme");
            //this.CornerRadius = 20;
            //this.BorderWidth = 1;
            //base.LayoutChildren(1, 1, 2, 2);
            //base.BackgroundColor = this.BackgroundColor;
        }

        public Thickness CornerRadius
        {
            get
            {
                return (Thickness)this.GetValue(DBorder.CornerRadiusProperty);
            }
            set
            {
                this.SetValue(DBorder.CornerRadiusProperty, (object)value);
            }
        }

        public Color BorderColor
        {
            get
            {
                return (Color)this.GetValue(DBorder.BorderColorProperty);
            }
            set
            {
                this.SetValue(DBorder.BorderColorProperty, (object)value);
            }
        }

        public double BorderWidth
        {
            get
            {
                return (double)this.GetValue(DBorder.BorderWidthProperty);
            }
            set
            {
                this.SetValue(DBorder.BorderWidthProperty, (object)value);
            }
        }

        public new Color BackgroundColor
        {
            get
            {
                return (Color)this.GetValue(DBorder.BackgroundColorProperty);
            }
            set
            {
                this.SetValue(DBorder.BackgroundColorProperty, (object)value);
            }
        }

        public bool HasShadow
        {
            get
            {
                return (bool)this.GetValue(DBorder.HasShadowProperty);
            }
            set
            {
                this.SetValue(DBorder.HasShadowProperty, (object)value);
            }
        }

        public Color ShadowColor
        {
            get
            {
                return (Color)this.GetValue(DBorder.ShadowColorProperty);
            }
            set
            {
                this.SetValue(DBorder.ShadowColorProperty, (object)value);
            }
        }

        public double[] DashArray
        {
            get
            {
                return (double[])this.GetValue(DBorder.DashArrayProperty);
            }
            set
            {
                this.SetValue(DBorder.DashArrayProperty, (object)value);
            }
        }

        internal float BottomShadowHeight { get; set; } = 2f;

        internal float RightShadowWidth { get; set; } = 2f;

        internal float TopShadowHeight { get; set; }

        internal float LeftShadowWidth { get; set; }

        internal float ShadowOffset { get; set; } = 2f;

        internal float ShadowX { get; set; } = 1f;

        internal float ShadowY { get; set; } = 1f;

        ResourceDictionary IParentThemeElement.GetThemeDictionary()
        {
            return (ResourceDictionary)new DBorderStyles();
        }

        void IThemeElement.OnControlThemeChanged(string oldTheme, string newTheme)
        {
        }

        void IThemeElement.OnCommonThemeChanged(string oldTheme, string newTheme)
        {
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            double num1 = width;
            double num2 = height;
            double num3;
            double num4;
            if (this.HasShadow && Device.RuntimePlatform == "Android")
            {
                x += this.BorderWidth + (double)this.LeftShadowWidth;
                y += this.BorderWidth + (double)this.TopShadowHeight;
                num3 = num1 - (this.BorderWidth * 2.0 + (double)this.LeftShadowWidth + (double)this.RightShadowWidth);
                num4 = num2 - (this.BorderWidth * 2.0 + (double)this.TopShadowHeight + (double)this.BottomShadowHeight);
            }
            else
            {
                x += this.BorderWidth;
                y += this.BorderWidth;
                num3 = num1 - this.BorderWidth * 2.0;
                num4 = num2 - this.BorderWidth * 2.0;
            }
            double width1 = num3 < 0.0 ? 0.0 : num3;
            double height1 = num4 < 0.0 ? 0.0 : num4;
            base.LayoutChildren(x, y, width1, height1);
        }

        protected override SizeRequest OnMeasure(
          double widthConstraint,
          double heightConstraint)
        {
            SizeRequest sizeRequest = new SizeRequest();
            double widthRequest = this.WidthRequest;
            double heightRequest = this.HeightRequest;
            if ((widthRequest == -1.0 || heightRequest == -1.0) && this.Content != null)
                sizeRequest = this.Content.Measure(widthConstraint, heightConstraint, MeasureFlags.IncludeMargins);
            double num1 = this.BorderWidth * 2.0;
            double num2 = num1;
            if (this.HasShadow && Device.RuntimePlatform == "Android")
            {
                num1 += (double)this.RightShadowWidth + (double)this.LeftShadowWidth;
                num2 += (double)this.BottomShadowHeight + (double)this.TopShadowHeight;
            }
            return new SizeRequest()
            {
                Request = new Size()
                {
                    Width = widthRequest != -1.0 ? widthRequest : sizeRequest.Request.Width + num1,
                    Height = heightRequest != -1.0 ? heightRequest : sizeRequest.Request.Height + num2
                },
                Minimum = sizeRequest.Minimum
            };
        }

        private static void OhHasShadowChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            DBorder DBorder = (DBorder)bindable;
            DBorder.InvalidateMeasureNonVirtual(InvalidationTrigger.SizeRequestChanged);
            DBorder.ForceLayout();
        }

        private static void OnDashArrayChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            DBorder DBorder = (DBorder)bindable;
            DBorder.InvalidateMeasureNonVirtual(InvalidationTrigger.SizeRequestChanged);
            DBorder.ForceLayout();
        }

        private static void OnBorderWidthChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            DBorder DBorder = (DBorder)bindable;
           // DBorder.InvalidateMeasureNonVirtual(InvalidationTrigger.SizeRequestChanged);
            DBorder.ForceLayout();
        }

        private static object OnBorderWidthCoerceChanged(BindableObject bindable, object value)
        {
            double num = (double)value;
            if (num < 0.0)
                num = 0.0;
            return (object)num;
        }

        internal static class ThemeElement
        {
            public static BindableProperty CommonThemeProperty = BindableProperty.Create("CommonTheme", typeof(string), typeof(IThemeElement), (object)"Default", BindingMode.OneWay, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(ThemeElement.OnCommonThemePropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
            public static BindableProperty ControlThemeProperty = BindableProperty.Create("ControlTheme", typeof(string), typeof(IThemeElement), (object)"Default", BindingMode.OneWay, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(ThemeElement.OnControlThemeChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
            public static BindableProperty PrimaryColorProperty = BindableProperty.Create("PrimaryColor", typeof(Color), typeof(IThemeElement), (object)Color.Default, BindingMode.OneWay, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
            public static BindableProperty PrimaryLightColorProperty = BindableProperty.Create("PrimaryLightColor", typeof(Color), typeof(IThemeElement), (object)Color.Default, BindingMode.OneWay, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
            public static BindableProperty PrimaryDarkColorProperty = BindableProperty.Create("PrimaryDarkColor", typeof(Color), typeof(IThemeElement), (object)Color.Default, BindingMode.OneWay, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
            public static BindableProperty PrimaryForegroundColorProperty = BindableProperty.Create("PrimaryForegroundColor", typeof(Color), typeof(IThemeElement), (object)Color.Default, BindingMode.OneWay, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
            public static BindableProperty PrimaryLightForegroundColorProperty = BindableProperty.Create("PrimaryLightForegroundColor", typeof(Color), typeof(IThemeElement), (object)Color.Default, BindingMode.OneWay, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
            public static BindableProperty PrimaryDarkForegroundColorProperty = BindableProperty.Create("PrimaryDarkForegroundColor", typeof(Color), typeof(IThemeElement), (object)Color.Default, BindingMode.OneWay, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
            public static BindableProperty SuccessColorProperty = BindableProperty.Create("SuccessColor", typeof(Color), typeof(IThemeElement), (object)Color.Default, BindingMode.OneWay, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
            public static BindableProperty ErrorColorProperty = BindableProperty.Create("ErrorColor", typeof(Color), typeof(IThemeElement), (object)Color.Default, BindingMode.OneWay, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
            public static BindableProperty WarningColorProperty = BindableProperty.Create("WarningColor", typeof(Color), typeof(IThemeElement), (object)Color.Default, BindingMode.OneWay, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
            public static BindableProperty InfoColorProperty = BindableProperty.Create("InfoColor", typeof(Color), typeof(IThemeElement), (object)Color.Default, BindingMode.OneWay, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
            private static readonly Dictionary<string, WeakReference<ResourceDictionary>> ControlThemeCache = new Dictionary<string, WeakReference<ResourceDictionary>>();
            private static readonly List<WeakReference<ResourceDictionary>> StyleTargetDictionaries = new List<WeakReference<ResourceDictionary>>();
            private static BindableProperty controlKeyProperty = BindableProperty.Create("ControlKey", typeof(string), typeof(IThemeElement), (object)string.Empty, BindingMode.OneWay, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
            private static BindableProperty implicitStyleProperty = BindableProperty.Create("ImplicitStyle", typeof(Style), typeof(IThemeElement), (object)null, BindingMode.OneWay, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(ThemeElement.OnImplicitStyleChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
            private static Dictionary<ResourceDictionary, List<ResourceDictionary>> pendingDictionariesToMerge = new Dictionary<ResourceDictionary, List<ResourceDictionary>>();
            private static bool isScheduled = false;

            internal static void InitializeThemeResources(Element element, string controlKey)
            {
                if (element == null)
                    throw new ArgumentNullException(nameof(element));
                Type type = element.GetType();
                //element.SetValue(ThemeElement.controlKeyProperty, (object)controlKey);
                //element.SetDynamicResource(ThemeElement.CommonThemeProperty, "SyncfusionTheme");
                //element.SetDynamicResource(ThemeElement.ControlThemeProperty, controlKey);
                //element.SetDynamicResource(ThemeElement.PrimaryColorProperty, "SyncPrimaryColor");
                //element.SetDynamicResource(ThemeElement.PrimaryDarkColorProperty, "SyncPrimaryDarkColor");
                //element.SetDynamicResource(ThemeElement.PrimaryLightColorProperty, "SyncPrimaryLightColor");
                //element.SetDynamicResource(ThemeElement.PrimaryForegroundColorProperty, "SyncPrimaryForegroundColor");
                //element.SetDynamicResource(ThemeElement.PrimaryDarkForegroundColorProperty, "SyncPrimaryDarkForegroundColor");
                //element.SetDynamicResource(ThemeElement.PrimaryLightForegroundColorProperty, "SyncPrimaryLightForegroundColor");
                //element.SetDynamicResource(ThemeElement.SuccessColorProperty, "SyncSuccessColor");
                //element.SetDynamicResource(ThemeElement.ErrorColorProperty, "SyncErrorColor");
                //element.SetDynamicResource(ThemeElement.WarningColorProperty, "SyncWarningColor");
                //element.SetDynamicResource(ThemeElement.InfoColorProperty, "SyncInfoColor");
                if (element is VisualElement)
                    return;
                string fullName = type.FullName;
                element.SetDynamicResource(ThemeElement.implicitStyleProperty, fullName);
            }

            internal static void AddStyleDictionary(ResourceDictionary resourceDictionary)
            {
                if (resourceDictionary == null)
                    throw new ArgumentNullException(nameof(resourceDictionary));
                ThemeElement.StyleTargetDictionaries.Add(new WeakReference<ResourceDictionary>(resourceDictionary));
            }

            private static void MergePendingDictionaries()
            {
                if (ThemeElement.pendingDictionariesToMerge != null)
                {
                    foreach (KeyValuePair<ResourceDictionary, List<ResourceDictionary>> keyValuePair in ThemeElement.pendingDictionariesToMerge)
                    {
                        ResourceDictionary key = keyValuePair.Key;
                        foreach (ResourceDictionary resourceDictionary in keyValuePair.Value)
                            key.MergedDictionaries.Add(resourceDictionary);
                        keyValuePair.Value.Clear();
                    }
                    ThemeElement.pendingDictionariesToMerge.Clear();
                }
                ThemeElement.isScheduled = false;
            }

            private static void OnImplicitStyleChanged(
              BindableObject bindable,
              object oldValue,
              object newValue)
            {
                Style style = newValue as Style;
                if (!(bindable is Element element) || style == null)
                    return;
                foreach (Setter setter in (IEnumerable<Setter>)style.Setters)
                {
                    if (setter.Value is DynamicResource dynamicResource)
                        element.SetDynamicResource(setter.Property, dynamicResource.Key);
                    else
                        element.SetValue(setter.Property, setter.Value);
                }
            }

            private static void OnCommonThemePropertyChanged(
              BindableObject bindable,
              object oldValue,
              object newValue)
            {
                if (!(bindable is IThemeElement themeElement))
                    return;
                themeElement.OnCommonThemeChanged((string)oldValue, (string)newValue);
            }

            private static void MergeThemeDictionary(string key, ResourceDictionary themeDictionary)
            {
                if (themeDictionary == null)
                    return;
                for (int index = ThemeElement.StyleTargetDictionaries.Count - 1; index >= 0; --index)
                {
                    ResourceDictionary target;
                    ThemeElement.StyleTargetDictionaries[index].TryGetTarget(out target);
                    if (target != null && target.TryGetValue(key, out object _) && !target.MergedDictionaries.Contains(themeDictionary))
                    {
                        List<ResourceDictionary> resourceDictionaryList;
                        if (!ThemeElement.pendingDictionariesToMerge.ContainsKey(target))
                        {
                            resourceDictionaryList = new List<ResourceDictionary>();
                            ThemeElement.pendingDictionariesToMerge.Add(target, resourceDictionaryList);
                        }
                        else
                            resourceDictionaryList = ThemeElement.pendingDictionariesToMerge[target];
                        resourceDictionaryList.Add(themeDictionary);
                        if (!ThemeElement.isScheduled)
                        {
                            Device.BeginInvokeOnMainThread(new Action(ThemeElement.MergePendingDictionaries));
                            ThemeElement.isScheduled = true;
                        }
                    }
                }
            }

            private static bool TryGetThemeDictionary(
              VisualElement element,
              out ResourceDictionary resourceDictionary)
            {
                resourceDictionary = (ResourceDictionary)null;
                if (element != null)
                {
                    string key = (string)element.GetValue(ThemeElement.controlKeyProperty);
                    WeakReference<ResourceDictionary> weakReference = (WeakReference<ResourceDictionary>)null;
                    if (ThemeElement.ControlThemeCache.TryGetValue(key, out weakReference) && weakReference.TryGetTarget(out resourceDictionary))
                        return true;
                    if (ThemeElement.ControlThemeCache.ContainsKey(key))
                        ThemeElement.ControlThemeCache.Remove(key);
                    if (element is IParentThemeElement parentThemeElement)
                    {
                        resourceDictionary = parentThemeElement.GetThemeDictionary();
                        if (resourceDictionary != null)
                        {
                            weakReference = new WeakReference<ResourceDictionary>(resourceDictionary);
                            ThemeElement.ControlThemeCache.Add(key, weakReference);
                            return true;
                        }
                    }
                }
                return false;
            }

            private static void OnControlThemeChanged(
              BindableObject bindable,
              object oldValue,
              object newValue)
            {
                IThemeElement themeElement = bindable as IThemeElement;
                if (bindable == null)
                    return;
                string key = (string)bindable.GetValue(ThemeElement.controlKeyProperty);
                if (bindable is VisualElement element)
                {
                    List<WeakReference<ResourceDictionary>> targetDictionaries = ThemeElement.StyleTargetDictionaries;
                    ResourceDictionary resourceDictionary;
                    // ISSUE: explicit non-virtual call
                    //if ((targetDictionaries != null ? (__nonvirtual(targetDictionaries.Count) > 0 ? 1 : 0) : 0) != 0 && ThemeElement.TryGetThemeDictionary(element, out resourceDictionary))
                        ThemeElement.TryGetThemeDictionary(element, out resourceDictionary);
                        ThemeElement.MergeThemeDictionary(key, resourceDictionary);
                }
                themeElement.OnControlThemeChanged((string)oldValue, (string)newValue);
            }
        }
    }


    [Preserve(AllMembers = true)]
    [XamlFilePath("Border\\DBorderStyles.xaml")]
    public class DBorderStyles : ResourceDictionary
    {
        public DBorderStyles()
        {
            this.InitializeComponent();
        }

        [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private void InitializeComponent()
        {
            this.LoadFromXaml<DBorderStyles>(typeof(DBorderStyles));
        }
    }
}
