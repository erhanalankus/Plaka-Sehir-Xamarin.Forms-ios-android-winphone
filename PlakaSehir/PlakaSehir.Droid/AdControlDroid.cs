using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using PlakaSehir;
using PlakaSehir.Droid;
using Xamarin.Forms.Platform.Android;
using Android.Gms.Ads;

[assembly: ExportRenderer(typeof(AdControl), typeof(AdControlDroid))]
namespace PlakaSehir.Droid
{
    class AdControlDroid : ViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                AdView ad = new AdView(this.Context);
                ad.AdSize = AdSize.Banner;
                //test id
                //ad.AdUnitId = ""; //TODO Private Info
                //live id
                ad.AdUnitId = "";
                var requestBuilder = new AdRequest.Builder(); //TODO Private Info
                ad.LoadAd(requestBuilder.Build());
                this.SetNativeControl(ad);
            }
        }
    }
}