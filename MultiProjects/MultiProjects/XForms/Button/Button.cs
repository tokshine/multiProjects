using MultiProjects.XForms.Border;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using MultiProjects.XForms.Graphics;
using System.CodeDom.Compiler;
using Xamarin.Forms.Xaml;
using static MultiProjects.XForms.Border.DBorder;

namespace MultiProjects.XForms.Button
{
    [DesignTimeVisible(true)]
    [Preserve(AllMembers = true)]
    public class DButton : DBorder, IParentThemeElement, IThemeElement
    {
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(double), typeof(DButton), (object)DButton.GetDefaultTextFontSize(), BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.OnFontSizePropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(DButton), (object)string.Empty, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.OnFontFamilyPropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty FontAttributesProperty = BindableProperty.Create(nameof(FontAttributes), typeof(FontAttributes), typeof(DButton), (object)FontAttributes.None, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.OnFontAttributesPropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(DButton), (object)Color.White, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.OnTextColorPropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public new static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(DButton), (object)Color.Accent, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.OnBackgroundColorPropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public new static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(DButton), (object)Color.Transparent, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.OnBorderColorPropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public new static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(nameof(BorderWidth), typeof(double), typeof(DButton), (object)DButton.GetDefaultBorderWidth(), BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.OnBorderWidthPropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty PressedBackgroundColorProperty = BindableProperty.Create(nameof(PressedBackgroundColor), typeof(Color), typeof(DButton), (object)Color.FromHex("#26000000"), BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty HorizontalTextAlignmentProperty = BindableProperty.Create(nameof(HorizontalTextAlignment), typeof(TextAlignment), typeof(DButton), (object)TextAlignment.Center, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.OnHorizontalTextAlignmentPropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty VerticalTextAlignmentProperty = BindableProperty.Create(nameof(VerticalTextAlignment), typeof(TextAlignment), typeof(DButton), (object)TextAlignment.Center, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.OnVerticalTextAlignmentPropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty BackgroundImageProperty = BindableProperty.Create(nameof(BackgroundImage), typeof(ImageSource), typeof(DButton), (object)null, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.OnBackgroundImagePropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty ShowIconProperty = BindableProperty.Create(nameof(ShowIcon), typeof(bool), typeof(DButton), (object)false, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.OnImageSourcePropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty IsCheckableProperty = BindableProperty.Create(nameof(IsCheckable), typeof(bool), typeof(DButton), (object)false, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(DButton), (object)false, BindingMode.TwoWay, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.OnCheckedPropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(ImageSource), typeof(DButton), (object)null, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.OnImageSourcePropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public new static readonly BindableProperty PaddingProperty = BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(DButton), (object)new Thickness(0.0), BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.OnPaddingPropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(DButton), (object)string.Empty, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.OnTextPropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty ImageAlignmentProperty = BindableProperty.Create(nameof(ImageAlignment), typeof(Alignment), typeof(DButton), (object)Alignment.Start, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.OnImageSourcePropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public new static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(View), typeof(DButton), (object)null, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.OnContentPropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(DButton), (object)null, BindingMode.OneWay, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.OnCommandPropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(DButton), (object)null, BindingMode.OneWay, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.OnCommandParameterPropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty ImageWidthProperty = BindableProperty.Create(nameof(ImageWidth), typeof(int), typeof(DButton), (object)32, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.ArrangeChildren), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        internal static readonly BindableProperty ShowCloseButtonProperty = BindableProperty.Create(nameof(ShowCloseButton), typeof(bool), typeof(DButton), (object)false, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.OnShowCloseButtonPropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        internal static readonly BindableProperty ShowSelectionIndicatorProperty = BindableProperty.Create(nameof(ShowSelectionIndicator), typeof(bool), typeof(DButton), (object)false, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.OnShowSelectionIndicatorPropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        internal static readonly BindableProperty CloseButtonAlignmentProperty = BindableProperty.Create(nameof(CloseButtonAlignment), typeof(Alignment), typeof(DButton), (object)Alignment.End, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.ArrangeChildren), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        internal static readonly BindableProperty SelectionIndicatorAlignmentProperty = BindableProperty.Create(nameof(SelectionIndicatorAlignment), typeof(Alignment), typeof(DButton), (object)Alignment.Start, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.ArrangeChildren), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        internal static readonly BindableProperty CloseButtonColorProperty = BindableProperty.Create(nameof(CloseButtonColor), typeof(Color), typeof(DButton), (object)Color.FromHex("#6b6b6b"), BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.OnCloseButtonColorPropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        internal static readonly BindableProperty SelectionIndicatorColorProperty = BindableProperty.Create(nameof(SelectionIndicatorColor), typeof(Color), typeof(DButton), (object)Color.FromHex("#6b6b6b"), BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.OnSelectionIndicatorColorPropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty BackgroundGradientProperty = BindableProperty.Create(nameof(BackgroundGradient), typeof(DGradientBrush), typeof(DButton), (object)null, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, new BindableProperty.BindingPropertyChangedDelegate(DButton.OnGradientColorPropertyChanged), (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        internal int closeButtonPosition = 3;
        private readonly int defaultPadding = 4;
        private readonly int buttonTextPadding = -4;
        private readonly int defaultSelectionRightPadding = 2;
        private readonly int defaultIconFontSize = 18;
        private readonly int defaultSelectionTickIconFontSize = 16;
        private readonly string selectionIndicatorText = Device.RuntimePlatform == "UWP" || Device.RuntimePlatform == "WPF" ? "\xE8FB" : "\xE745";
        private readonly string closeButtonText = Device.RuntimePlatform == "UWP" || Device.RuntimePlatform == "WPF" ? "\xEB90" : "\xE742";
        private readonly int defaultSelectionIndicatorWidth = 26;
        private readonly int defaultCloseButtonWidth = 28;
        private readonly Color disabledBackgroundColor = Color.FromHex("#E0E0E0");
        private readonly Color disabledBorderColor = Color.FromHex("#E0E0E0");
        private readonly Color disabledTextColor = Color.FromHex("#A3A3A3");
        private readonly Color disabledPressedBackgroundColor = Color.FromHex("#D1D1D1");
        private readonly Color disabledPressedTextColor = Color.FromHex("#949494");
        private IVisual actualVisual = VisualMarker.Default;
        private List<View> viewCollection = new List<View>();
        internal Grid buttonLayout;
        private Grid mainGrid;
        private DLabel buttonContent;
        private CustomLabel closeButton;
        private Image imageView;
        private CustomLabel selectionButton;
        private Image backgroundImageView;
        private Grid contentGrid;
        private Grid selectionIndicatorGrid;
        private Grid closeButtonGrid;
        private Grid imageViewGrid;
        private TouchEffect touchEffect;
        private View oldContent;
        private DGradientView gradientView;

        public DButton()
        {
           // ThemeElement.InitializeThemeResources((Element)this, "SyncfusionTheme");
           //this.ValidateLicense();
            this.Initialize();
        }

        public event EventHandler<EventArgs> Clicked;

        internal event EventHandler<EventArgs> CloseButtonClicked;

        private void RaiseClicked(EventArgs args)
        {
            if (!this.IsEnabled)
                return;
            this.Command?.Execute(this.CommandParameter);
            EventHandler<EventArgs> clicked = this.Clicked;
            if (clicked == null)
                return;
            clicked((object)this, EventArgs.Empty);
        }

        private void RaiseCloseButtonClicked(EventArgs args)
        {
            if (this.CloseButtonClicked == null)
                return;
            this.CloseButtonClicked((object)this, args);
        }

        [System.ComponentModel.TypeConverter(typeof(FontSizeConverter))]
        public double FontSize
        {
            get
            {
                return (double)this.GetValue(DButton.FontSizeProperty);
            }
            set
            {
                this.SetValue(DButton.FontSizeProperty, (object)value);
            }
        }

        public string FontFamily
        {
            get
            {
                return (string)this.GetValue(DButton.FontFamilyProperty);
            }
            set
            {
                this.SetValue(DButton.FontFamilyProperty, (object)value);
            }
        }

        public FontAttributes FontAttributes
        {
            get
            {
                return (FontAttributes)this.GetValue(DButton.FontAttributesProperty);
            }
            set
            {
                this.SetValue(DButton.FontAttributesProperty, (object)value);
            }
        }

        public Color TextColor
        {
            get
            {
                return (Color)this.GetValue(DButton.TextColorProperty);
            }
            set
            {
                this.SetValue(DButton.TextColorProperty, (object)value);
            }
        }

        public new Color BackgroundColor
        {
            get
            {
                return (Color)this.GetValue(DButton.BackgroundColorProperty);
            }
            set
            {
                this.SetValue(DButton.BackgroundColorProperty, (object)value);
            }
        }

        public new Color BorderColor
        {
            get
            {
                return (Color)this.GetValue(DButton.BorderColorProperty);
            }
            set
            {
                this.SetValue(DButton.BorderColorProperty, (object)value);
            }
        }

        public new double BorderWidth
        {
            get
            {
                return (double)this.GetValue(DButton.BorderWidthProperty);
            }
            set
            {
                this.SetValue(DButton.BorderWidthProperty, (object)value);
            }
        }

        public Color PressedBackgroundColor
        {
            get
            {
                return (Color)this.GetValue(DButton.PressedBackgroundColorProperty);
            }
            set
            {
                this.SetValue(DButton.PressedBackgroundColorProperty, (object)value);
            }
        }

        public TextAlignment HorizontalTextAlignment
        {
            get
            {
                return (TextAlignment)this.GetValue(DButton.HorizontalTextAlignmentProperty);
            }
            set
            {
                this.SetValue(DButton.HorizontalTextAlignmentProperty, (object)value);
            }
        }

        public TextAlignment VerticalTextAlignment
        {
            get
            {
                return (TextAlignment)this.GetValue(DButton.VerticalTextAlignmentProperty);
            }
            set
            {
                this.SetValue(DButton.VerticalTextAlignmentProperty, (object)value);
            }
        }

        public ImageSource BackgroundImage
        {
            get
            {
                return (ImageSource)this.GetValue(DButton.BackgroundImageProperty);
            }
            set
            {
                this.SetValue(DButton.BackgroundImageProperty, (object)value);
            }
        }

        public bool ShowIcon
        {
            get
            {
                return (bool)this.GetValue(DButton.ShowIconProperty);
            }
            set
            {
                this.SetValue(DButton.ShowIconProperty, (object)value);
            }
        }

        public bool IsCheckable
        {
            get
            {
                return (bool)this.GetValue(DButton.IsCheckableProperty);
            }
            set
            {
                this.SetValue(DButton.IsCheckableProperty, (object)value);
            }
        }

        public bool IsChecked
        {
            get
            {
                return (bool)this.GetValue(DButton.IsCheckedProperty);
            }
            set
            {
                this.SetValue(DButton.IsCheckedProperty, (object)value);
            }
        }

        public string Text
        {
            get
            {
                return (string)this.GetValue(DButton.TextProperty);
            }
            set
            {
                this.SetValue(DButton.TextProperty, (object)value);
            }
        }

        public ImageSource ImageSource
        {
            get
            {
                return (ImageSource)this.GetValue(DButton.ImageSourceProperty);
            }
            set
            {
                this.SetValue(DButton.ImageSourceProperty, (object)value);
            }
        }

        public new Thickness Padding
        {
            get
            {
                return (Thickness)this.GetValue(DButton.PaddingProperty);
            }
            set
            {
                this.SetValue(DButton.PaddingProperty, (object)value);
            }
        }

        public Alignment ImageAlignment
        {
            get
            {
                return (Alignment)this.GetValue(DButton.ImageAlignmentProperty);
            }
            set
            {
                this.SetValue(DButton.ImageAlignmentProperty, (object)value);
            }
        }

        public new View Content
        {
            get
            {
                return (View)this.GetValue(DButton.ContentProperty);
            }
            set
            {
                this.SetValue(DButton.ContentProperty, (object)value);
            }
        }

        public ICommand Command
        {
            get
            {
                return (ICommand)this.GetValue(DButton.CommandProperty);
            }
            set
            {
                this.SetValue(DButton.CommandProperty, (object)value);
            }
        }

        public object CommandParameter
        {
            get
            {
                return this.GetValue(DButton.CommandParameterProperty);
            }
            set
            {
                this.SetValue(DButton.CommandParameterProperty, value);
            }
        }

        public int ImageWidth
        {
            get
            {
                return (int)this.GetValue(DButton.ImageWidthProperty);
            }
            set
            {
                this.SetValue(DButton.ImageWidthProperty, (object)value);
            }
        }

        public DGradientBrush BackgroundGradient
        {
            get
            {
                return (DGradientBrush)this.GetValue(DButton.BackgroundGradientProperty);
            }
            set
            {
                this.SetValue(DButton.BackgroundGradientProperty, (object)value);
            }
        }

        internal bool ShowCloseButton
        {
            get
            {
                return (bool)this.GetValue(DButton.ShowCloseButtonProperty);
            }
            set
            {
                this.SetValue(DButton.ShowCloseButtonProperty, (object)value);
            }
        }

        internal bool ShowSelectionIndicator
        {
            get
            {
                return (bool)this.GetValue(DButton.ShowSelectionIndicatorProperty);
            }
            set
            {
                this.SetValue(DButton.ShowSelectionIndicatorProperty, (object)value);
            }
        }

        internal Alignment CloseButtonAlignment
        {
            get
            {
                return (Alignment)this.GetValue(DButton.CloseButtonAlignmentProperty);
            }
            set
            {
                this.SetValue(DButton.CloseButtonAlignmentProperty, (object)value);
            }
        }

        internal Alignment SelectionIndicatorAlignment
        {
            get
            {
                return (Alignment)this.GetValue(DButton.SelectionIndicatorAlignmentProperty);
            }
            set
            {
                this.SetValue(DButton.SelectionIndicatorAlignmentProperty, (object)value);
            }
        }

        internal Color CloseButtonColor
        {
            get
            {
                return (Color)this.GetValue(DButton.CloseButtonColorProperty);
            }
            set
            {
                this.SetValue(DButton.CloseButtonColorProperty, (object)value);
            }
        }

        internal Color SelectionIndicatorColor
        {
            get
            {
                return (Color)this.GetValue(DButton.SelectionIndicatorColorProperty);
            }
            set
            {
                this.SetValue(DButton.SelectionIndicatorColorProperty, (object)value);
            }
        }

        internal CustomLabel CloseButton
        {
            get
            {
                return this.closeButton;
            }
            set
            {
                if (this.closeButton == value)
                    return;
                this.closeButton = value;
                if (this.closeButton == null)
                    return;
                this.SetCloseButtonAutomationId();
            }
        }

        internal IVisual ActualVisual
        {
            get
            {
                return this.actualVisual;
            }
            set
            {
                if (this.actualVisual == value)
                    return;
                this.actualVisual = value;
            }
        }

        internal virtual void SetCloseButtonAutomationId()
        {
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName == "Content" && Device.RuntimePlatform == "UWP")
                return;
            base.OnPropertyChanged(propertyName);
            if (propertyName == "IsEnabled")
                this.OnEnabledPropertyChanged();
            if (propertyName == "FlowDirection")
            {
                this.ArrangeChildren();
            }
            else
            {
                if (!(propertyName == "AutomationId") || this.touchEffect.AutomationId != null)
                    return;
                this.touchEffect.AutomationId = this.AutomationId;
            }
        }

        protected override SizeRequest OnMeasure(
          double widthConstraint,
          double heightConstraint)
        {
            SizeRequest sizeRequest = base.OnMeasure(widthConstraint, heightConstraint);
            if (this.Parent is StackLayout)
            {
                if (double.IsNaN(widthConstraint) || double.IsInfinity(widthConstraint))
                    widthConstraint = sizeRequest.Request.Width;
                if (double.IsNaN(heightConstraint) || double.IsInfinity(heightConstraint))
                    heightConstraint = sizeRequest.Request.Height;
                sizeRequest = new SizeRequest(new Size(widthConstraint, heightConstraint));
            }
            else if (this.Parent is FlexLayout)
            {
                double height = sizeRequest.Request.Height;
                sizeRequest = base.OnMeasure(this.buttonLayout.Measure(widthConstraint, height, MeasureFlags.None).Request.Width, height);
            }
            return sizeRequest;
        }

        internal void SetBackgroundColor(Color color)
        {
            base.BackgroundColor = color;
        }

        internal void SetBorderColor(Color color)
        {
            base.BorderColor = color;
        }

        internal void SetTextColor(Color color)
        {
            if (this.buttonContent == null)
                return;
            this.buttonContent.TextColor = color;
        }

        internal static double GetDefaultVerticalPadding()
        {
            return Device.RuntimePlatform == "Android" || Device.RuntimePlatform == "iOS" ? 8.0 : 4.0;
        }

        private static double GetDefaultTextFontSize()
        {
            if (Device.RuntimePlatform == "Android")
                return 14.0;
            int num = Device.RuntimePlatform == "iOS" ? 1 : 0;
            return 15.0;
        }

        private static double GetDefaultBorderWidth()
        {
            return 1;
            //return Device.RuntimePlatform == "UWP" || Device.RuntimePlatform == "WPF" ? 2.0 : 0.0;
        }

        private static string GetDefaultFontFamily()
        {
            if (Device.RuntimePlatform == "Android")
                return "DButton.ttf#V1 Font Material icon";
            if (Device.RuntimePlatform == "iOS")
                return "DButton.ttf";
            return Device.RuntimePlatform == "WPF" ? "pack://application:,,,/Syncfusion.Buttons.XForms.WPF;component/Assets/#Segoe MDL2 Assets" : "/Assets/DButton_Segoe MDL2 Assets.ttf#Segoe MDL2 Assets";
        }

        private static void OnContentPropertyChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            (bindable as DButton).OnContentPropertyChanged();
        }

        private static void OnCommandPropertyChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            (bindable as DButton).OnCommandPropertyChanged();
        }

        private static void OnCommandParameterPropertyChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            (bindable as DButton).OnCommandParameterPropertyChanged();
        }

        private static void OnFontSizePropertyChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            DButton DButton = bindable as DButton;
            DButton.OnFontSizePropertyChanged();
            DButton.UpdateLayoutMeasure();
        }

        private static void OnTextColorPropertyChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            (bindable as DButton).OnTextColorPropertyChanged();
        }

        private static void OnBackgroundColorPropertyChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            (bindable as DButton).OnBackgroundColorPropertyChanged();
        }

        private static void OnBorderColorPropertyChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            (bindable as DButton).OnBorderColorPropertyChanged();
        }

        private static void OnBorderWidthPropertyChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            (bindable as DButton).OnBorderWidthPropertyChanged();
        }

        private static void OnHorizontalTextAlignmentPropertyChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            (bindable as DButton).OnHorizontalTextAlignmentPropertyChanged();
        }

        private static void OnVerticalTextAlignmentPropertyChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            (bindable as DButton).OnVerticalTextAlignmentPropertyChanged();
        }

        private static void OnTextPropertyChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            DButton DButton = bindable as DButton;
            DButton.OnTextPropertyChanged();
            DButton.UpdateLayoutMeasure();
        }

        private static void OnFontFamilyPropertyChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            DButton DButton = bindable as DButton;
            DButton.OnFontFamilyPropertyChanged();
            DButton.UpdateLayoutMeasure();
        }

        private static void OnFontAttributesPropertyChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            DButton DButton = bindable as DButton;
            DButton.OnFontAttributesPropertyChanged();
            DButton.UpdateLayoutMeasure();
        }

        private static void OnBackgroundImagePropertyChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            (bindable as DButton).OnBackgroundImagePropertyChanged();
        }

        private static void OnImageSourcePropertyChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            (bindable as DButton).OnImageSourcePropertyChanged();
        }

        private static void OnPaddingPropertyChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            (bindable as DButton).OnPaddingPropertyChanged();
        }

        private static void OnCheckedPropertyChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            (bindable as DButton).OnCheckedPropertyChanged();
        }

        private static void OnCloseButtonColorPropertyChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            (bindable as DButton).OnCloseButtonColorPropertyChanged();
        }

        private static void OnSelectionIndicatorColorPropertyChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            (bindable as DButton).OnSelectionIndicatorColorPropertyChanged();
        }

        private static void OnShowCloseButtonPropertyChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            DButton DButton = bindable as DButton;
            if ((bool)newValue && DButton.closeButtonGrid == null)
            {
                DButton.buttonLayout.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = (GridLength)(double)DButton.defaultCloseButtonWidth
                });
                DButton.CreateCloseButtonView();
                DButton.buttonLayout.Children.Add((View)DButton.closeButtonGrid, DButton.buttonLayout.Children.Count, 0);
            }
            DButton.ArrangeChildren();
        }

        private static void OnShowSelectionIndicatorPropertyChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            DButton DButton = bindable as DButton;
            if ((bool)newValue && DButton.selectionIndicatorGrid == null)
            {
                DButton.buttonLayout.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = (GridLength)(double)DButton.defaultSelectionIndicatorWidth
                });
                DButton.CreateSelectionIndicator();
                DButton.buttonLayout.Children.Add((View)DButton.selectionIndicatorGrid, 0, 0);
            }
            DButton.ArrangeChildren();
        }

        private static void ArrangeChildren(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as DButton).ArrangeChildren();
        }

        private static void OnGradientColorPropertyChanged(
          BindableObject bindable,
          object oldValue,
          object newValue)
        {
            if (!(bindable is DButton DButton))
                return;
            DButton.OnGradientColorPropertyChanged();
        }

        private void OnContentPropertyChanged()
        {
            if (this.Content == base.Content)
                return;
            this.OnContentChanged();
        }

        private void OnFontSizePropertyChanged()
        {
            if (this.buttonContent == null)
                return;
            this.buttonContent.FontSize = this.FontSize;
        }

        private void OnTextColorPropertyChanged()
        {
            if (this.buttonContent == null)
                return;
            this.buttonContent.TextColor = this.TextColor;
        }

        private void OnBackgroundColorPropertyChanged()
        {
            base.BackgroundColor = this.BackgroundColor;
        }

        private void OnBorderColorPropertyChanged()
        {
            base.BorderColor = this.BorderColor;
        }

        private void OnBorderWidthPropertyChanged()
        {
            base.BorderWidth = this.BorderWidth;
        }

        private void OnHorizontalTextAlignmentPropertyChanged()
        {
            if (this.buttonContent == null)
                return;
            this.buttonContent.HorizontalTextAlignment = this.HorizontalTextAlignment;
        }

        private void OnVerticalTextAlignmentPropertyChanged()
        {
            if (this.buttonContent == null)
                return;
            this.buttonContent.VerticalTextAlignment = this.VerticalTextAlignment;
        }

        private void OnFontFamilyPropertyChanged()
        {
            if (this.buttonContent == null || this.Text == null)
                return;
            this.buttonContent.FontFamily = this.FontFamily;
        }

        private void OnTextPropertyChanged()
        {
            if (this.buttonContent == null)
                return;
            this.buttonContent.Text = this.Text;
        }

        private void OnFontAttributesPropertyChanged()
        {
            if (this.buttonContent == null || this.Text == null)
                return;
            this.buttonContent.FontAttributes = this.FontAttributes;
        }

        private void OnBackgroundImagePropertyChanged()
        {
            if (this.mainGrid == null)
                this.mainGrid = new Grid();
            if (this.BackgroundImage == null && this.backgroundImageView != null && this.mainGrid.Children.Contains((View)this.backgroundImageView))
            {
                this.mainGrid.Children.Remove((View)this.backgroundImageView);
                this.backgroundImageView = (Image)null;
            }
            else if (this.backgroundImageView == null && this.BackgroundImage != null)
                this.AddBackgroundImage();
            if (this.backgroundImageView == null)
                return;
            this.backgroundImageView.Source = this.BackgroundImage;
        }

        private void OnImageSourcePropertyChanged()
        {
            if (this.buttonLayout == null)
                this.CreateButtonLayout();
            if (this.ShowIcon && this.ImageSource != null)
            {
                if (this.imageView == null)
                {
                    this.buttonLayout.ColumnDefinitions.Add(new ColumnDefinition()
                    {
                        Width = (GridLength)(double)this.ImageWidth
                    });
                    this.CreateImageIcon();
                    this.buttonLayout.Children.Add((View)this.imageViewGrid, 0, 0);
                }
                if (this.imageView != null && (this.ImageAlignment == Alignment.Bottom || this.ImageAlignment == Alignment.Top) && this.buttonLayout.RowDefinitions.Count <= 0)
                {
                    this.buttonLayout.RowDefinitions.Add(new RowDefinition()
                    {
                        Height = (GridLength)(double)this.ImageWidth
                    });
                    this.buttonLayout.RowDefinitions.Add(new RowDefinition()
                    {
                        Height = new GridLength(0.0)
                    });
                }
                else if (this.ImageAlignment == Alignment.Start || this.ImageAlignment == Alignment.End)
                    this.buttonLayout.RowDefinitions.Clear();
                if (this.contentGrid == null)
                    this.CreateButtonContent();
                if (this.ImageAlignment == Alignment.Top)
                {
                    this.contentGrid.Padding = new Thickness((double)this.defaultPadding, 0.0, (double)this.defaultPadding, (double)this.defaultPadding);
                    this.imageViewGrid.Padding = new Thickness((double)this.defaultPadding, (double)this.defaultPadding, (double)this.defaultPadding, (double)this.defaultPadding);
                    this.buttonLayout.VerticalOptions = LayoutOptions.Center;
                }
                else if (this.ImageAlignment == Alignment.Bottom)
                {
                    this.buttonLayout.VerticalOptions = LayoutOptions.Center;
                    this.contentGrid.Padding = new Thickness((double)this.defaultPadding, (double)this.defaultPadding, (double)this.defaultPadding, 0.0);
                    this.imageViewGrid.Padding = new Thickness((double)this.defaultPadding, (double)this.defaultPadding, (double)this.defaultPadding, (double)this.defaultPadding);
                }
                else
                {
                    this.buttonLayout.VerticalOptions = LayoutOptions.Fill;
                    double num1 = Device.RuntimePlatform == "Android" ? 6.0 : DButton.GetDefaultVerticalPadding();
                    int num2 = Device.RuntimePlatform == "WPF" ? this.defaultPadding : 0;
                    this.contentGrid.Padding = new Thickness((double)this.defaultPadding, num1, (double)this.defaultPadding, num1);
                    this.imageViewGrid.Padding = new Thickness((double)this.defaultPadding, (double)num2, (double)this.defaultPadding, 0.0);
                }
                this.imageView.Source = this.ImageSource;
            }
            this.ArrangeChildren();
        }

        private void OnPaddingPropertyChanged()
        {
            this.UpdatePadding();
        }

        private void OnCheckedPropertyChanged()
        {
            if (this.touchEffect == null)
                return;
            this.touchEffect.IsChecked = this.IsChecked;
        }

        private void OnEnabledPropertyChanged()
        {
            if (this.IsEnabled)
            {
                base.BorderColor = this.BorderColor;
                if (this.buttonContent != null)
                    this.buttonContent.TextColor = this.TextColor;
                if (this.IsCheckable && this.IsChecked)
                    base.BackgroundColor = this.PressedBackgroundColor;
                else
                    base.BackgroundColor = this.BackgroundColor;
            }
            else
            {
                base.BorderColor = this.disabledBorderColor;
                if (this.IsCheckable && this.IsChecked)
                {
                    base.BackgroundColor = this.disabledPressedBackgroundColor;
                    if (this.buttonContent == null)
                        return;
                    this.buttonContent.TextColor = this.disabledPressedTextColor;
                }
                else
                {
                    base.BackgroundColor = this.disabledBackgroundColor;
                    if (this.buttonContent == null)
                        return;
                    this.buttonContent.TextColor = this.disabledTextColor;
                }
            }
        }

        private void OnCloseButtonColorPropertyChanged()
        {
            if (this.CloseButton == null)
                return;
            this.CloseButton.TextColor = this.CloseButtonColor;
        }

        private void OnSelectionIndicatorColorPropertyChanged()
        {
            if (this.selectionButton == null)
                return;
            this.selectionButton.TextColor = this.SelectionIndicatorColor;
        }

        private void OnCommandPropertyChanged()
        {
            if (this.Command != null)
            {
                this.Command.CanExecuteChanged -= new EventHandler(this.OnCommandCanExecuteChanged);
                this.Command.CanExecuteChanged += new EventHandler(this.OnCommandCanExecuteChanged);
                this.OnCommandCanExecuteChanged((object)this, EventArgs.Empty);
            }
            else
                this.IsEnabled = true;
        }

        private void OnGradientColorPropertyChanged()
        {
            if (this.mainGrid == null)
                this.mainGrid = new Grid();
            if (this.BackgroundGradient == null && this.gradientView != null && this.mainGrid.Children.Contains((View)this.gradientView))
            {
                this.mainGrid.Children.Remove((View)this.gradientView);
                this.gradientView = (DGradientView)null;
            }
            else if (this.gradientView == null && this.BackgroundGradient != null)
                this.AddGradientView();
            if (this.gradientView == null)
                return;
            this.gradientView.BackgroundBrush = this.BackgroundGradient;
        }

        private void OnCommandCanExecuteChanged(object sender, EventArgs e)
        {
            ICommand command = this.Command;
            if (command == null)
                return;
            this.IsEnabled = command.CanExecute(this.CommandParameter);
        }

        private void OnCommandParameterPropertyChanged()
        {
            this.OnCommandCanExecuteChanged((object)this, EventArgs.Empty);
        }

        private void UpdateLayoutMeasure()
        {
            if (this.buttonContent == null)
                return;
            this.buttonContent.InvalidateMeasureNonVirtual(InvalidationTrigger.MeasureChanged);
        }

        private void UpdatePadding()
        {
            if (this.Content != null)
            {
                if (this.mainGrid == null)
                    return;
                this.mainGrid.Padding = this.Padding;
            }
            else
            {
                if (this.contentGrid == null)
                    return;
                this.contentGrid.Padding = this.Padding;
            }
        }

        internal bool IsRTL()
        {
            return ((IVisualElementController)this).EffectiveFlowDirection == EffectiveFlowDirection.RightToLeft;
        }

        internal async void AnimateTextColor()
        {
            await Task.Delay(10);
            this.SetTextColor(this.TextColor.MultiplyAlpha(1.0));
        }

        private void ArrangeChildren()
        {
            if (this.ShowIcon && this.ImageSource != null && this.ImageWidth > 0)
            {
                if (this.ImageAlignment == Alignment.Start || this.ImageAlignment == Alignment.Left && !this.IsRTL() || this.ImageAlignment == Alignment.Right && this.IsRTL())
                    this.LayoutChildren((View)this.imageViewGrid, 0, 0);
                else if (this.ImageAlignment == Alignment.Top)
                    this.LayoutChildren((View)this.imageViewGrid, 0, 0);
                else if (this.ImageAlignment == Alignment.Bottom)
                    this.LayoutChildren((View)this.imageViewGrid, 0, 1);
                else
                    this.LayoutChildren((View)this.imageViewGrid, this.buttonLayout.Children.Count - 1, 0);
            }
            if (this.ShowSelectionIndicator)
            {
                if (this.SelectionIndicatorAlignment == Alignment.Start)
                {
                    this.buttonContent.Margin = new Thickness((double)this.buttonTextPadding, 0.0, 0.0, 0.0);
                    this.LayoutChildren((View)this.selectionIndicatorGrid, 0, 0);
                }
                else
                {
                    this.buttonContent.Margin = new Thickness(0.0, 0.0, (double)this.buttonTextPadding, 0.0);
                    this.LayoutChildren((View)this.selectionIndicatorGrid, this.buttonLayout.Children.Count - 1, 0);
                }
            }
            if (this.ShowCloseButton)
            {
                if (this.CloseButtonAlignment == Alignment.Start)
                    this.LayoutChildren((View)this.closeButtonGrid, 0, 0);
                else
                    this.LayoutChildren((View)this.closeButtonGrid, this.buttonLayout.Children.Count - 1, 0);
            }
            this.SetVisibility();
        }

        private void LayoutChildren(View currentColumn, int x, int y)
        {
            this.viewCollection.Clear();
            View view = (View)null;
            for (int index = 0; index < this.buttonLayout.Children.Count; ++index)
            {
                if (this.buttonLayout.Children[index] == currentColumn)
                    view = this.buttonLayout.Children[index];
                else
                    this.viewCollection.Add(this.buttonLayout.Children[index]);
            }
            this.viewCollection.Insert(x, view);
            this.buttonLayout.Children.Clear();
            for (int left = 0; left < this.viewCollection.Count; ++left)
            {
                if (this.ImageAlignment == Alignment.Top && this.viewCollection[left] == this.contentGrid)
                    this.buttonLayout.Children.Add(this.viewCollection[left], 0, 1);
                else if (this.ImageAlignment == Alignment.Bottom && this.viewCollection[left] == this.contentGrid)
                    this.buttonLayout.Children.Add(this.viewCollection[left], 0, 0);
                else
                    this.buttonLayout.Children.Add(this.viewCollection[left], left, y);
                if (this.ImageAlignment == Alignment.Top || this.ImageAlignment == Alignment.Bottom)
                    Grid.SetColumnSpan((BindableObject)this.viewCollection[left], 2);
            }
        }

        private void SetVisibility()
        {
            for (int index = 0; index < this.buttonLayout.Children.Count; ++index)
            {
                if (this.buttonLayout.Children[index] == this.selectionIndicatorGrid)
                {
                    if (this.ShowSelectionIndicator)
                    {
                        this.selectionIndicatorGrid.IsVisible = true;
                        this.buttonLayout.ColumnDefinitions[index].Width = new GridLength((double)this.defaultSelectionIndicatorWidth);
                    }
                    else
                    {
                        this.selectionIndicatorGrid.IsVisible = false;
                        this.buttonLayout.ColumnDefinitions[index].Width = new GridLength(0.0);
                    }
                }
                else if (this.buttonLayout.Children[index] == this.imageViewGrid)
                {
                    if (this.ShowIcon && this.ImageWidth > 0)
                    {
                        this.imageViewGrid.IsVisible = true;
                        this.buttonLayout.ColumnDefinitions[index].Width = new GridLength((double)this.ImageWidth);
                        if (this.buttonLayout.RowDefinitions.Count > 0)
                        {
                            if (this.ImageAlignment == Alignment.Top)
                                this.buttonLayout.RowDefinitions[index].Height = new GridLength((double)this.ImageWidth);
                            else if (this.ImageAlignment == Alignment.Bottom)
                                this.buttonLayout.RowDefinitions[index].Height = new GridLength(1.0, GridUnitType.Star);
                            else
                                this.buttonLayout.RowDefinitions[1].Height = new GridLength(0.0);
                        }
                    }
                    else
                    {
                        this.imageViewGrid.IsVisible = false;
                        this.buttonLayout.ColumnDefinitions[index].Width = new GridLength(0.0);
                    }
                }
                else if (this.buttonLayout.Children[index] == this.closeButtonGrid)
                {
                    if (this.ShowCloseButton)
                    {
                        this.closeButtonGrid.IsVisible = true;
                        this.buttonLayout.ColumnDefinitions[index].Width = new GridLength((double)this.defaultCloseButtonWidth);
                        this.closeButtonPosition = index;
                    }
                    else
                    {
                        this.closeButtonGrid.IsVisible = false;
                        this.buttonLayout.ColumnDefinitions[index].Width = new GridLength(0.0);
                    }
                }
                else
                {
                    this.buttonLayout.ColumnDefinitions[index].Width = new GridLength(1.0, GridUnitType.Star);
                    if (this.buttonLayout.RowDefinitions.Count > 0)
                    {
                        if (this.ImageAlignment == Alignment.Top)
                            this.buttonLayout.RowDefinitions[index].Height = new GridLength(1.0, GridUnitType.Star);
                        else if (this.ImageAlignment == Alignment.Bottom)
                            this.buttonLayout.RowDefinitions[index].Height = new GridLength((double)this.ImageWidth);
                    }
                }
            }
        }

        private void Initialize()
        {
            this.SetInitialBaseProperties();
            if (this.mainGrid == null)
                this.mainGrid = new Grid();
            this.mainGrid.SetValue(AutomationProperties.IsInAccessibleTreeProperty, (object)false);
            this.CreateButtonLayout();
            this.CreateButtonContent();
            this.AddButtonLayout();
            this.ArrangeChildren();
            this.mainGrid.Children.Add((View)this.buttonLayout);
            this.touchEffect = new TouchEffect(this);
            if (Device.RuntimePlatform == "UWP")
            {
                if (this.AutomationId != null)
                    this.touchEffect.AutomationId = this.AutomationId;
                this.touchEffect.SetBinding(AutomationProperties.IsInAccessibleTreeProperty, (BindingBase)new Binding()
                {
                    Path = "IsInAccessibleTree",
                    Source = (object)this
                });
                this.touchEffect.SetBinding(AutomationProperties.NameProperty, (BindingBase)new Binding()
                {
                    Path = "Name",
                    Source = (object)this
                });
            }
            this.touchEffect.IsChecked = this.IsChecked;
            this.mainGrid.Children.Add((View)this.touchEffect);
            base.Content = (View)this.mainGrid;
        }

        private void SetInitialBaseProperties()
        {
            base.BackgroundColor = this.BackgroundColor;
            base.BorderColor = this.BorderColor;
            base.BorderWidth = this.BorderWidth;
        }

        private void OnContentChanged()
        {
            if (this.Content == null)
            {
                this.mainGrid.Children.Remove(this.oldContent);
                this.mainGrid.Children.Insert(this.mainGrid.Children.IndexOf((View)this.touchEffect), (View)this.buttonLayout);
            }
            else
            {
                if (this.mainGrid == null)
                    this.mainGrid = new Grid();
                if (this.buttonLayout != null && this.mainGrid.Children.Contains((View)this.buttonLayout))
                    this.mainGrid.Children.Remove((View)this.buttonLayout);
                if (this.oldContent != null && this.mainGrid.Children.Contains(this.oldContent))
                    this.mainGrid.Children.Remove(this.oldContent);
                if (this.touchEffect != null && this.mainGrid.Children.Contains((View)this.touchEffect))
                    this.mainGrid.Children.Insert(this.mainGrid.Children.IndexOf((View)this.touchEffect), this.Content);
                else
                    this.mainGrid.Children.Add(this.Content);
                this.UpdatePadding();
                this.oldContent = this.Content;
            }
            if (this.touchEffect != null)
                this.touchEffect.IsChecked = this.IsChecked;
            base.Content = (View)this.mainGrid;
        }

        private void AddGradientView()
        {
            this.gradientView = new DGradientView();
            this.gradientView.SetValue(AutomationProperties.IsInAccessibleTreeProperty, (object)false);
            this.gradientView.BackgroundBrush = this.BackgroundGradient;
            this.mainGrid.Children.Insert(0, (View)this.gradientView);
        }

        private void AddBackgroundImage()
        {
            this.backgroundImageView = new Image();
            this.backgroundImageView.SetValue(AutomationProperties.IsInAccessibleTreeProperty, (object)false);
            this.backgroundImageView.Aspect = Aspect.Fill;
            if (this.BackgroundImage != null)
                this.backgroundImageView.Source = this.BackgroundImage;
            this.mainGrid.Children.Insert(this.gradientView == null ? 0 : 1, (View)this.backgroundImageView);
        }

        private void CreateButtonLayout()
        {
            if (this.buttonLayout != null)
                return;
            this.buttonLayout = new Grid();
            if (Device.RuntimePlatform == "WPF")
            {
                this.buttonLayout.HorizontalOptions = LayoutOptions.Center;
                this.buttonLayout.VerticalOptions = LayoutOptions.Center;
            }
            this.buttonLayout.SetValue(AutomationProperties.IsInAccessibleTreeProperty, (object)false);
            this.buttonLayout.Padding = new Thickness((double)this.defaultPadding, 0.0, (double)this.defaultPadding, 0.0);
            if (this.ShowSelectionIndicator)
                this.buttonLayout.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = (GridLength)(double)this.defaultSelectionIndicatorWidth
                });
            if (this.ShowIcon && this.ImageSource != null && this.ImageWidth > 0)
                this.buttonLayout.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = (GridLength)(double)this.ImageWidth
                });
            this.buttonLayout.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1.0, GridUnitType.Star)
            });
            if (this.ShowCloseButton)
                this.buttonLayout.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = (GridLength)(double)this.defaultCloseButtonWidth
                });
            this.buttonLayout.ColumnSpacing = 0.0;
            this.buttonLayout.RowSpacing = 0.0;
        }

        private void CreateButtonContent()
        {
            if (this.contentGrid != null)
                return;
            this.contentGrid = new Grid();
            this.contentGrid.SetValue(AutomationProperties.IsInAccessibleTreeProperty, (object)false);
            this.contentGrid.Padding = new Thickness((double)this.defaultPadding, DButton.GetDefaultVerticalPadding(), (double)this.defaultPadding, DButton.GetDefaultVerticalPadding());
            this.buttonContent = new DLabel();
            this.buttonContent.SetValue(AutomationProperties.IsInAccessibleTreeProperty, (object)false);
            this.buttonContent.Text = this.Text;
            this.buttonContent.TextColor = this.TextColor;
            this.buttonContent.LineBreakMode = Xamarin.Forms.LineBreakMode.NoWrap;
            this.buttonContent.FontSize = this.FontSize;
            this.buttonContent.HorizontalTextAlignment = this.HorizontalTextAlignment;
            this.buttonContent.VerticalTextAlignment = this.VerticalTextAlignment;
            this.buttonContent.FontAttributes = this.FontAttributes;
            this.buttonContent.FontFamily = this.FontFamily;
            this.contentGrid.Children.Add((View)this.buttonContent);
        }

        private void CreateCloseButtonView()
        {
            this.closeButtonGrid = new Grid();
            this.closeButtonGrid.Padding = new Thickness((double)this.defaultPadding, 0.0, (double)this.defaultPadding, 0.0);
            this.CloseButton = new CustomLabel();
            this.CloseButton.TextColor = this.CloseButtonColor;
            this.CloseButton.FontFamily = DButton.GetDefaultFontFamily();
            this.CloseButton.Text = this.closeButtonText;
            this.CloseButton.FontSize = (double)this.defaultIconFontSize;
            this.CloseButton.VerticalOptions = LayoutOptions.Center;
            this.CloseButton.HorizontalOptions = LayoutOptions.Center;
            this.CloseButton.VerticalTextAlignment = TextAlignment.Center;
            this.closeButtonGrid.Children.Add((View)this.CloseButton);
        }

        private void CreateImageIcon()
        {
            this.imageViewGrid = new Grid();
            this.imageViewGrid.SetValue(AutomationProperties.IsInAccessibleTreeProperty, (object)false);
            if (Device.RuntimePlatform == "WPF")
            {
                this.imageViewGrid.HorizontalOptions = LayoutOptions.Center;
                this.imageViewGrid.VerticalOptions = LayoutOptions.Center;
            }
            this.imageViewGrid.Padding = new Thickness((double)this.defaultPadding, Device.RuntimePlatform == "WPF" ? (double)this.defaultPadding : 0.0, (double)this.defaultPadding, 0.0);
            this.imageView = new Image();
            this.imageView.SetValue(AutomationProperties.IsInAccessibleTreeProperty, (object)false);
            this.imageView.Source = this.ImageSource;
            this.imageViewGrid.Children.Add((View)this.imageView);
        }

        private void CreateSelectionIndicator()
        {
            this.selectionIndicatorGrid = new Grid();
            this.selectionIndicatorGrid.SetValue(AutomationProperties.IsInAccessibleTreeProperty, (object)false);
            this.selectionIndicatorGrid.Padding = new Thickness((double)this.defaultPadding, 0.0, (double)this.defaultSelectionRightPadding, 0.0);
            this.selectionButton = new CustomLabel();
            this.selectionButton.SetValue(AutomationProperties.IsInAccessibleTreeProperty, (object)false);
            this.selectionButton.FontSize = (double)this.defaultSelectionTickIconFontSize;
            this.selectionButton.TextColor = this.SelectionIndicatorColor;
            this.selectionButton.VerticalOptions = LayoutOptions.Center;
            this.selectionButton.HorizontalOptions = LayoutOptions.Center;
            this.selectionButton.FontFamily = DButton.GetDefaultFontFamily();
            this.selectionButton.Text = this.selectionIndicatorText;
            this.selectionButton.VerticalTextAlignment = TextAlignment.Center;
            this.selectionIndicatorGrid.Children.Add((View)this.selectionButton);
        }

        private void AddButtonLayout()
        {
            if (this.ShowSelectionIndicator)
                this.buttonLayout.Children.Add((View)this.selectionIndicatorGrid, this.buttonLayout.Children.Count, 0);
            if (this.ShowIcon && this.imageViewGrid != null && this.ImageWidth > 0)
                this.buttonLayout.Children.Add((View)this.imageViewGrid, this.buttonLayout.Children.Count, 0);
            this.buttonLayout.Children.Add((View)this.contentGrid, this.buttonLayout.Children.Count, 0);
            if (!this.ShowCloseButton)
                return;
            this.buttonLayout.Children.Add((View)this.closeButtonGrid, this.buttonLayout.Children.Count, 0);
        }

        ResourceDictionary IParentThemeElement.GetThemeDictionary()
        {
            return (ResourceDictionary)new DButtonStyles();
        }

        void IThemeElement.OnControlThemeChanged(string oldTheme, string newTheme)
        {
        }

        void IThemeElement.OnCommonThemeChanged(string oldTheme, string newTheme)
        {
        }
    }

    [Preserve(AllMembers = true)]
    [XamlFilePath("ButtonControl\\DButtonStyles.xaml")]
    public class DButtonStyles : ResourceDictionary
    {
        public DButtonStyles()
        {
            this.InitializeComponent();
        }

        [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private void InitializeComponent()
        {
            this.LoadFromXaml<DButtonStyles>(typeof(DButtonStyles));
        }
    }

    internal class DLabel : Label
    {
    }

    internal class CustomLabel : Label
    {
    }

    [Preserve(AllMembers = true)]
    internal class TouchEffect : DEffectsView
    {
        internal static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(TouchEffect), (object)false, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        internal DButton DButton;

        public TouchEffect(DButton DButton)
        {
            this.DButton = DButton;
        }

        internal bool IsChecked
        {
            get
            {
                return (bool)this.GetValue(TouchEffect.IsCheckedProperty);
            }
            set
            {
                this.SetValue(TouchEffect.IsCheckedProperty, (object)value);
            }
        }
    }


    public class DEffectsView : ContentView, IParentThemeElement, IThemeElement
    {
        public static readonly BindableProperty RippleAnimationDurationProperty = BindableProperty.Create(nameof(RippleAnimationDuration), typeof(double), typeof(DEffectsView), (object)275.0, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty ScaleAnimationDurationProperty = BindableProperty.Create(nameof(ScaleAnimationDuration), typeof(double), typeof(DEffectsView), (object)150.0, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty RotationAnimationDurationProperty = BindableProperty.Create(nameof(RotationAnimationDuration), typeof(double), typeof(DEffectsView), (object)200.0, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(Thickness), typeof(DEffectsView), (object)new Thickness(0.0), BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty InitialRippleFactorProperty = BindableProperty.Create(nameof(InitialRippleFactor), typeof(double), typeof(DEffectsView), (object)0.25, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty ScaleFactorProperty = BindableProperty.Create(nameof(ScaleFactor), typeof(double), typeof(DEffectsView), (object)1.0, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty HighlightColorProperty = BindableProperty.Create(nameof(HighlightColor), typeof(Xamarin.Forms.Color), typeof(DEffectsView), (object)Xamarin.Forms.Color.Black, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty RippleColorProperty = BindableProperty.Create(nameof(RippleColor), typeof(Xamarin.Forms.Color), typeof(DEffectsView), (object)Xamarin.Forms.Color.Black, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty SelectionColorProperty = BindableProperty.Create(nameof(SelectionColor), typeof(Xamarin.Forms.Color), typeof(DEffectsView), (object)Xamarin.Forms.Color.Black, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty AngleProperty = BindableProperty.Create(nameof(Angle), typeof(int), typeof(DEffectsView), (object)0, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty FadeOutRippleProperty = BindableProperty.Create(nameof(FadeOutRipple), typeof(bool), typeof(DEffectsView), (object)false, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty TouchDownEffectsProperty = BindableProperty.Create(nameof(TouchDownEffects), typeof(DEffects), typeof(DEffectsView), (object)DEffects.Ripple, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty LongPressEffectsProperty = BindableProperty.Create(nameof(LongPressEffects), typeof(DEffects), typeof(DEffectsView), (object)DEffects.None, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty TouchUpEffectsProperty = BindableProperty.Create(nameof(TouchUpEffects), typeof(DEffects), typeof(DEffectsView), (object)DEffects.None, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(DEffectsView), (object)false, BindingMode.TwoWay, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty ShouldIgnoreTouchesProperty = BindableProperty.Create(nameof(ShouldIgnoreTouches), typeof(bool), typeof(DEffectsView), (object)false, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        internal static readonly BindableProperty ShouldApplyEffectsBehindContentProperty = BindableProperty.Create(nameof(ShouldApplyEffectsBehindContent), typeof(bool), typeof(DEffectsView), (object)false, BindingMode.Default, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        private readonly Lazy<PlatformConfigurationRegistry<DEffectsView>> platformConfigurationRegistry;
        private object nativeObject;

        public double RippleAnimationDuration
        {
            get
            {
                return (double)this.GetValue(DEffectsView.RippleAnimationDurationProperty);
            }
            set
            {
                this.SetValue(DEffectsView.RippleAnimationDurationProperty, (object)value);
            }
        }

        public double ScaleAnimationDuration
        {
            get
            {
                return (double)this.GetValue(DEffectsView.ScaleAnimationDurationProperty);
            }
            set
            {
                this.SetValue(DEffectsView.ScaleAnimationDurationProperty, (object)value);
            }
        }

        public double RotationAnimationDuration
        {
            get
            {
                return (double)this.GetValue(DEffectsView.RotationAnimationDurationProperty);
            }
            set
            {
                this.SetValue(DEffectsView.RotationAnimationDurationProperty, (object)value);
            }
        }

        public Thickness CornerRadius
        {
            get
            {
                return (Thickness)this.GetValue(DEffectsView.CornerRadiusProperty);
            }
            set
            {
                this.SetValue(DEffectsView.CornerRadiusProperty, (object)value);
            }
        }

        public double InitialRippleFactor
        {
            get
            {
                return (double)this.GetValue(DEffectsView.InitialRippleFactorProperty);
            }
            set
            {
                this.SetValue(DEffectsView.InitialRippleFactorProperty, (object)value);
            }
        }

        public double ScaleFactor
        {
            get
            {
                return (double)this.GetValue(DEffectsView.ScaleFactorProperty);
            }
            set
            {
                this.SetValue(DEffectsView.ScaleFactorProperty, (object)value);
            }
        }

        public Xamarin.Forms.Color HighlightColor
        {
            get
            {
                return (Xamarin.Forms.Color)this.GetValue(DEffectsView.HighlightColorProperty);
            }
            set
            {
                this.SetValue(DEffectsView.HighlightColorProperty, (object)value);
            }
        }

        public Xamarin.Forms.Color RippleColor
        {
            get
            {
                return (Xamarin.Forms.Color)this.GetValue(DEffectsView.RippleColorProperty);
            }
            set
            {
                this.SetValue(DEffectsView.RippleColorProperty, (object)value);
            }
        }

        public Xamarin.Forms.Color SelectionColor
        {
            get
            {
                return (Xamarin.Forms.Color)this.GetValue(DEffectsView.SelectionColorProperty);
            }
            set
            {
                this.SetValue(DEffectsView.SelectionColorProperty, (object)value);
            }
        }

        public int Angle
        {
            get
            {
                return (int)this.GetValue(DEffectsView.AngleProperty);
            }
            set
            {
                this.SetValue(DEffectsView.AngleProperty, (object)value);
            }
        }

        public bool FadeOutRipple
        {
            get
            {
                return (bool)this.GetValue(DEffectsView.FadeOutRippleProperty);
            }
            set
            {
                this.SetValue(DEffectsView.FadeOutRippleProperty, (object)value);
            }
        }

        public DEffects TouchDownEffects
        {
            get
            {
                return (DEffects)this.GetValue(DEffectsView.TouchDownEffectsProperty);
            }
            set
            {
                this.SetValue(DEffectsView.TouchDownEffectsProperty, (object)value);
            }
        }

        public DEffects LongPressEffects
        {
            get
            {
                return (DEffects)this.GetValue(DEffectsView.LongPressEffectsProperty);
            }
            set
            {
                this.SetValue(DEffectsView.LongPressEffectsProperty, (object)value);
            }
        }

        public DEffects TouchUpEffects
        {
            get
            {
                return (DEffects)this.GetValue(DEffectsView.TouchUpEffectsProperty);
            }
            set
            {
                this.SetValue(DEffectsView.TouchUpEffectsProperty, (object)value);
            }
        }

        public bool IsSelected
        {
            get
            {
                return (bool)this.GetValue(DEffectsView.IsSelectedProperty);
            }
            set
            {
                this.SetValue(DEffectsView.IsSelectedProperty, (object)value);
            }
        }

        public bool ShouldIgnoreTouches
        {
            get
            {
                return (bool)this.GetValue(DEffectsView.ShouldIgnoreTouchesProperty);
            }
            set
            {
                this.SetValue(DEffectsView.ShouldIgnoreTouchesProperty, (object)value);
            }
        }

        internal bool ShouldApplyEffectsBehindContent
        {
            get
            {
                return (bool)this.GetValue(DEffectsView.ShouldApplyEffectsBehindContentProperty);
            }
            set
            {
                this.SetValue(DEffectsView.ShouldApplyEffectsBehindContentProperty, (object)value);
            }
        }

        internal object NativeObject { get; set; }

        public DEffectsView()
        {
            //this.ValidateLicense();
           // ThemeElement.InitializeThemeResources((Element)this, "SfEffectsViewTheme");
            this.platformConfigurationRegistry = new Lazy<PlatformConfigurationRegistry<DEffectsView>>((Func<PlatformConfigurationRegistry<DEffectsView>>)(() => new PlatformConfigurationRegistry<DEffectsView>(this)));
        }

        public event EventHandler AnimationCompleted;

        public event EventHandler SelectionChanged;

        ResourceDictionary IParentThemeElement.GetThemeDictionary()
        {
            return (ResourceDictionary)new DEffectsViewStyles();
        }

        void IThemeElement.OnControlThemeChanged(string oldTheme, string newTheme)
        {
        }

        void IThemeElement.OnCommonThemeChanged(string oldTheme, string newTheme)
        {
        }

        public IPlatformElementConfiguration<T, DEffectsView> On<T>() where T : IConfigPlatform
        {
            return this.platformConfigurationRegistry.Value.On<T>();
        }

        public void Reset()
        {
            DependencyService.Get<IEffectsViewDependencyService>(DependencyFetchTarget.GlobalInstance).Reset(this.NativeObject);
        }

        public void ApplyEffects(
          DEffects effects = DEffects.Ripple,
          RippleStartPosition rippleStartPosition = RippleStartPosition.Default,
          System.Drawing.Point? rippleStartPoint = null,
          bool repeat = false)
        {
            DependencyService.Get<IEffectsViewDependencyService>(DependencyFetchTarget.GlobalInstance).ApplyEffects(effects, rippleStartPosition, rippleStartPoint, repeat, this.NativeObject);
        }

        internal void RaiseAnimationCompletedEvent(EventArgs eventArgs)
        {
            EventHandler animationCompleted = this.AnimationCompleted;
            if (animationCompleted == null)
                return;
            animationCompleted((object)this, eventArgs);
        }

        internal void RaiseSelectedEvent(EventArgs eventArgs)
        {
            EventHandler selectionChanged = this.SelectionChanged;
            if (selectionChanged == null)
                return;
            selectionChanged((object)this, eventArgs);
        }
    }

    [Flags]
    public enum DEffects
    {
        None = 1,
        Highlight = 2,
        Ripple = 4,
        Scale = 8,
        Selection = 16, // 0x00000010
        Rotation = 32, // 0x00000020
    }

    public enum Alignment
    {
        Start,
        End,
        Top,
        Bottom,
        Left,
        Right,
    }

    internal class PlatformConfigurationRegistry<TElement> : IElementConfiguration<TElement>
   where TElement : Element
    {
        private readonly Dictionary<Type, object> platformSpecifics = new Dictionary<Type, object>();
        private readonly TElement formsElement;

        internal PlatformConfigurationRegistry(TElement element)
        {
            this.formsElement = element;
        }

        public IPlatformElementConfiguration<T, TElement> On<T>() where T : IConfigPlatform
        {
            if (this.platformSpecifics.ContainsKey(typeof(T)))
                return (IPlatformElementConfiguration<T, TElement>)this.platformSpecifics[typeof(T)];
            Configuration<T, TElement> configuration = Configuration<T, TElement>.Create(this.formsElement);
            this.platformSpecifics.Add(typeof(T), (object)configuration);
            return (IPlatformElementConfiguration<T, TElement>)configuration;
        }
    }

    [XamlFilePath("Theme\\Resources\\DEffectsViewStyles.xaml")]
    public class DEffectsViewStyles : ResourceDictionary
    {
        public DEffectsViewStyles()
        {
            this.InitializeComponent();
        }

        [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private void InitializeComponent()
        {
            this.LoadFromXaml<DEffectsViewStyles>(typeof(DEffectsViewStyles));
        }
    }

    internal interface IEffectsViewDependencyService
    {
        void ApplyEffects(
          DEffects effects,
          RippleStartPosition rippleStartPosition,
          System.Drawing.Point? rippleStartPoint,
          bool repeat,
          object nativeObject);

        void Reset(object nativeObject);
    }

    [Flags]
    public enum RippleStartPosition
    {
        Left = 1,
        Top = 2,
        Right = 4,
        Bottom = 8,
        Default = 16, // 0x00000010
    }
}
