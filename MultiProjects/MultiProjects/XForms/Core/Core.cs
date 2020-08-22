using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MultiProjects.XForms.Core
{
    internal interface IRuntimePlatform<T>
    {
        T GetValue(OnPlatformOrientation<T> values);
    }

    public abstract class OnPlatformOrientation<T> : IMarkupExtension, INotifyPropertyChanged
    {
        private BindableProperty targetProperty;
        private BindableObject targetObject;
        private T defaultValue;
        private T portrait;
        private T landscape;
        private T phonePortrait;
        private T phoneLandscape;
        private T tabletPortrait;
        private T tabletLandscape;
        private T phone;
        private T tablet;
        private T desktop;
        private T android;
        private T ios;
        private T uwp;
        private T androidPhonePortrait;
        private T androidPhoneLandscape;
        private T iosPhonePortrait;
        private T iosPhoneLandscape;
        private T androidTabletPortrait;
        private T androidTabletLandscape;
        private T iosTabletPortrait;
        private T iosTabletLandscape;
        private readonly IRuntimePlatform<T> runtimePlatform;
        private T bindingValue;
        private bool isPortrait;

        internal bool IsDefaultSet { get; set; }

        internal bool IsPortraitSet { get; set; }

        internal bool IsLandscapeSet { get; set; }

        internal bool IsPhonePortraitSet { get; set; }

        internal bool IsPhoneLandscapeSet { get; set; }

        internal bool IsTabletPortraitSet { get; set; }

        internal bool IsTabletLandscapeSet { get; set; }

        internal bool IsPhoneSet { get; set; }

        internal bool IsTabletSet { get; set; }

        internal bool IsDesktopSet { get; set; }

        internal bool IsAndroidSet { get; set; }

        internal bool IsiOSSet { get; set; }

        internal bool IsUWPSet { get; set; }

        internal bool IsAndroidPhonePortraitSet { get; set; }

        internal bool IsAndroidPhoneLandscapeSet { get; set; }

        internal bool IsiOSPhonePortraitSet { get; set; }

        internal bool IsiOSPhoneLandscapeSet { get; set; }

        internal bool IsAndroidTabletPortraitSet { get; set; }

        internal bool IsAndroidTabletLandscapeSet { get; set; }

        internal bool IsiOSTabletPortraitSet { get; set; }

        internal bool IsiOSTabletLandscapeSet { get; set; }

        public T Default
        {
            get
            {
                return this.defaultValue;
            }
            set
            {
                this.defaultValue = value;
                this.IsDefaultSet = true;
            }
        }

        public T Portrait
        {
            get
            {
                return this.portrait;
            }
            set
            {
                this.portrait = value;
                this.IsPortraitSet = true;
            }
        }

        public T Landscape
        {
            get
            {
                return this.landscape;
            }
            set
            {
                this.landscape = value;
                this.IsLandscapeSet = true;
            }
        }

        public T PhonePortrait
        {
            get
            {
                return this.phonePortrait;
            }
            set
            {
                this.phonePortrait = value;
                this.IsPhonePortraitSet = true;
            }
        }

        public T PhoneLandscape
        {
            get
            {
                return this.phoneLandscape;
            }
            set
            {
                this.phoneLandscape = value;
                this.IsPhoneLandscapeSet = true;
            }
        }

        public T TabletPortrait
        {
            get
            {
                return this.tabletPortrait;
            }
            set
            {
                this.tabletPortrait = value;
                this.IsTabletPortraitSet = true;
            }
        }

        public T TabletLandscape
        {
            get
            {
                return this.tabletLandscape;
            }
            set
            {
                this.tabletLandscape = value;
                this.IsTabletLandscapeSet = true;
            }
        }

        public T Phone
        {
            get
            {
                return this.phone;
            }
            set
            {
                this.phone = value;
                this.IsPhoneSet = true;
            }
        }

        public T Tablet
        {
            get
            {
                return this.tablet;
            }
            set
            {
                this.tablet = value;
                this.IsTabletSet = true;
            }
        }

        public T Desktop
        {
            get
            {
                return this.desktop;
            }
            set
            {
                this.desktop = value;
                this.IsDesktopSet = true;
            }
        }

        public T Android
        {
            get
            {
                return this.android;
            }
            set
            {
                this.android = value;
                this.IsAndroidSet = true;
            }
        }

        public T iOS
        {
            get
            {
                return this.ios;
            }
            set
            {
                this.ios = value;
                this.IsiOSSet = true;
            }
        }

        public T UWP
        {
            get
            {
                return this.uwp;
            }
            set
            {
                this.uwp = value;
                this.IsUWPSet = true;
            }
        }

        public T AndroidPhonePortrait
        {
            get
            {
                return this.androidPhonePortrait;
            }
            set
            {
                this.androidPhonePortrait = value;
                this.IsAndroidPhonePortraitSet = true;
            }
        }

        public T iOSPhonePortrait
        {
            get
            {
                return this.iosPhonePortrait;
            }
            set
            {
                this.iosPhonePortrait = value;
                this.IsiOSPhonePortraitSet = true;
            }
        }

        public T AndroidPhoneLandscape
        {
            get
            {
                return this.androidPhoneLandscape;
            }
            set
            {
                this.androidPhoneLandscape = value;
                this.IsAndroidPhoneLandscapeSet = true;
            }
        }

        public T iOSPhoneLandscape
        {
            get
            {
                return this.iosPhoneLandscape;
            }
            set
            {
                this.iosPhoneLandscape = value;
                this.IsiOSPhoneLandscapeSet = true;
            }
        }

        public T AndroidTabletPortrait
        {
            get
            {
                return this.androidTabletPortrait;
            }
            set
            {
                this.androidTabletPortrait = value;
                this.IsAndroidTabletPortraitSet = true;
            }
        }

        public T iOSTabletPortrait
        {
            get
            {
                return this.iosTabletPortrait;
            }
            set
            {
                this.iosTabletPortrait = value;
                this.IsiOSTabletPortraitSet = true;
            }
        }

        public T AndroidTabletLandscape
        {
            get
            {
                return this.androidTabletLandscape;
            }
            set
            {
                this.androidTabletLandscape = value;
                this.IsAndroidTabletLandscapeSet = true;
            }
        }

        public T iOSTabletLandscape
        {
            get
            {
                return this.iosTabletLandscape;
            }
            set
            {
                this.iosTabletLandscape = value;
                this.IsiOSTabletLandscapeSet = true;
            }
        }

        public bool UseBinding { get; set; }

        public T BindingValue
        {
            get
            {
                return this.bindingValue;
            }
            internal set
            {
                this.bindingValue = value;
                this.NotifyPropertyChanged(nameof(BindingValue));
            }
        }

        internal bool IsPortrait
        {
            get
            {
                return this.isPortrait;
            }
            private set
            {
                this.isPortrait = value;
                this.UpdateBindingPath();
            }
        }

        protected OnPlatformOrientation()
        {
            MessagingCenter.Subscribe<object>((object)this, "InvalidateDeviceOrientation", new Action<object>(this.OnOrientationChanged), (object)null);
            switch (Device.RuntimePlatform)
            {
                case nameof(Android):
                    if (Device.Idiom == TargetIdiom.Phone)
                    {
                        this.runtimePlatform = (IRuntimePlatform<T>)new AndroidPhonePlatform<T>();
                        break;
                    }
                    if (Device.Idiom != TargetIdiom.Tablet)
                        break;
                    this.runtimePlatform = (IRuntimePlatform<T>)new AndroidTabletPlatform<T>();
                    break;
                case nameof(iOS):
                    if (Device.Idiom == TargetIdiom.Phone)
                    {
                        this.runtimePlatform = (IRuntimePlatform<T>)new iOSPhonePlatform<T>();
                        break;
                    }
                    if (Device.Idiom != TargetIdiom.Tablet)
                        break;
                    this.runtimePlatform = (IRuntimePlatform<T>)new iOSTabletPlatform<T>();
                    break;
                case nameof(UWP):
                    this.runtimePlatform = (IRuntimePlatform<T>)new Desktop<T>();
                    break;
            }
        }

        private void OnOrientationChanged(object sender)
        {
            this.IsPortrait = DependencyService.Get<IDeviceOrientation>(DependencyFetchTarget.GlobalInstance).GetOrientation();
        }

        private void UpdateBindingPath()
        {
            T bindingValue = this.BindingValue;
            this.BindingValue = this.runtimePlatform.GetValue(this);
            if (this.targetProperty == null || !this.targetObject.GetValue(this.targetProperty).Equals((object)bindingValue))
                return;
            this.targetObject.SetValue(this.targetProperty, (object)this.BindingValue);
        }

        internal interface IDeviceOrientation
        {
            bool GetOrientation();
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            this.IsPortrait = DependencyService.Get<IDeviceOrientation>(DependencyFetchTarget.GlobalInstance).GetOrientation();
            IProvideValueTarget provideValueTarget1 = serviceProvider != null ? serviceProvider.GetService<IProvideValueTarget>() : (IProvideValueTarget)null;
            if (provideValueTarget1 == null)
                throw new ArgumentException();
            IProvideValueTarget provideValueTarget2 = provideValueTarget1;
            if (this.UseBinding)
                return (object)new Binding()
                {
                    Source = (object)this,
                    Path = "BindingValue"
                };
            if (provideValueTarget2.TargetObject is Setter)
                throw new NotSupportedException("The OnPlatform converters do not work with Setter.Value property");
            this.targetProperty = provideValueTarget2.TargetProperty as BindableProperty;
            this.targetObject = provideValueTarget2.TargetObject as BindableObject;
            return (object)this.BindingValue;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return this.ProvideValue(serviceProvider);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged == null)
                return;
            propertyChanged((object)this, new PropertyChangedEventArgs(propertyName));
        }
    }


    internal class AndroidTabletPlatform<T> : IRuntimePlatform<T>
    {
        public T GetValue(OnPlatformOrientation<T> values)
        {
            if (values.IsPortrait)
            {
                if (values.IsAndroidTabletPortraitSet)
                    return values.AndroidTabletPortrait;
                if (values.IsTabletPortraitSet)
                    return values.TabletPortrait;
                return !values.IsPortraitSet ? values.Default : values.Portrait;
            }
            if (values.IsAndroidTabletLandscapeSet)
                return values.AndroidTabletLandscape;
            if (values.IsTabletLandscapeSet)
                return values.TabletLandscape;
            return !values.IsLandscapeSet ? values.Default : values.Landscape;
        }
    }
    internal class AndroidPhonePlatform<T> : IRuntimePlatform<T>
    {
        public T GetValue(OnPlatformOrientation<T> values)
        {
            if (values.IsPortrait)
            {
                if (values.IsAndroidPhonePortraitSet)
                    return values.AndroidPhonePortrait;
                if (values.IsPhonePortraitSet)
                    return values.PhonePortrait;
                return !values.IsPortraitSet ? values.Default : values.Portrait;
            }
            if (values.IsAndroidPhoneLandscapeSet)
                return values.AndroidPhoneLandscape;
            if (values.IsPhoneLandscapeSet)
                return values.PhoneLandscape;
            return !values.IsLandscapeSet ? values.Default : values.Landscape;
        }
    }

    internal class Desktop<T> : IRuntimePlatform<T>
    {
        public T GetValue(OnPlatformOrientation<T> values)
        {
            if (values.IsDesktopSet)
                return values.Desktop;
            return !values.IsPortraitSet ? values.Default : values.Portrait;
        }
    }

    internal class iOSTabletPlatform<T> : IRuntimePlatform<T>
    {
        public T GetValue(OnPlatformOrientation<T> values)
        {
            if (values.IsPortrait)
            {
                if (values.IsiOSTabletPortraitSet)
                    return values.iOSTabletPortrait;
                if (values.IsTabletPortraitSet)
                    return values.TabletPortrait;
                return !values.IsPortraitSet ? values.Default : values.Portrait;
            }
            if (values.IsiOSTabletLandscapeSet)
                return values.iOSTabletLandscape;
            if (values.IsTabletLandscapeSet)
                return values.TabletLandscape;
            return !values.IsLandscapeSet ? values.Default : values.Landscape;
        }
    }

    internal class iOSPhonePlatform<T> : IRuntimePlatform<T>
    {
        public T GetValue(OnPlatformOrientation<T> values)
        {
            if (values.IsPortrait)
            {
                if (values.IsiOSPhonePortraitSet)
                    return values.iOSPhonePortrait;
                if (values.IsPhonePortraitSet)
                    return values.PhonePortrait;
                return !values.IsPortraitSet ? values.Default : values.Portrait;
            }
            if (values.IsiOSPhoneLandscapeSet)
                return values.iOSPhoneLandscape;
            if (values.IsPhoneLandscapeSet)
                return values.PhoneLandscape;
            return !values.IsLandscapeSet ? values.Default : values.Landscape;
        }
    }

    public class OnPlatformOrientationStringValue : OnPlatformOrientation<string>
    {
    }
    public class OnPlatformOrientationThickness : OnPlatformOrientation<Thickness>
    {
    }
}
