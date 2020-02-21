
using Android.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Text;
using Entry_Editor_Sample;
using Entry_Editor_Sample.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using notenow4.Core.CustomControls;

[assembly: ExportRenderer(typeof(MultiEditor), typeof(MultiLineEntry))]

namespace Entry_Editor_Sample.Droid
{
   public class MultiLineEntry : EditorRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null) return;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                Control.BackgroundTintList = ColorStateList.ValueOf(Color.White);
            else
                Control.Background.SetColorFilter(Color.White, PorterDuff.Mode.SrcAtop);

        }
    }
}