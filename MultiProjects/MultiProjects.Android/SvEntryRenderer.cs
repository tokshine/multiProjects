using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MultiProjects.Droid;
using MultiProjects.MyCustomControl;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(SvEntry),typeof(SvEntryRenderer))]
namespace MultiProjects.Droid
{
    public class SvEntryRenderer:EntryRenderer
    {
        public SvEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            //if  (Control!= null)
            //{
            //    Control.Text = "This is from the cusdtom";
            //}
            if (e.OldElement == null)
            {
                //Control.SetBackgroundResource(Resource.Layout.rounded_shape);
                var view = (SvEntry)Element;
                var gradientDrawable = new GradientDrawable();
                //harcode approach
                //  gradientDrawable.SetCornerRadius(60f);
                // gradientDrawable.SetStroke(5, Android.Graphics.Color.DeepPink);
                //gradientDrawable.SetColor(Android.Graphics.Color.LightGray);

                gradientDrawable.SetColor(view.BackgroundColor.ToAndroid());
                gradientDrawable.SetCornerRadius(DpToPixels(this.Context, Convert.ToSingle(view.CornerRadius)));
                gradientDrawable.SetStroke(view.BorderWidth,view.BorderColor.ToAndroid());

                Control.SetBackground(gradientDrawable);

                //Control.SetPadding(50, Control.PaddingTop, Control.PaddingRight,
                //    Control.PaddingBottom);


                Control.SetPadding((int)DpToPixels(this.Context,Convert.ToSingle(12)), Control.PaddingTop, (int)DpToPixels(this.Context, Convert.ToSingle(12)),
                    Control.PaddingBottom);
            }
        }
        private static float DpToPixels(Context context,float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;

            return TypedValue.ApplyDimension(ComplexUnitType.Dip,valueInDp,metrics);
        }
    }
}