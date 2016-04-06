using GoogleAdMobAds;
using PlakaSehir;
using PlakaSehir.iOS;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using System.Linq;
using Foundation;
using System.Drawing;

[assembly: ExportRenderer(typeof(AdControl), typeof(AdControliOS))]
namespace PlakaSehir.iOS
{
    public class AdControliOS : ViewRenderer
    {
        GADBannerView adView;
        bool viewOnScreen = false;

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            adView = new GADBannerView(size: GADAdSizeCons.Banner)
            {
                //id for live ads
                AdUnitID = "", //TODO Private Info
                //id for test ads
                //AdUnitID = "", //TODO Private Info
                RootViewController = UIApplication.SharedApplication.Windows[0].RootViewController
            };

            adView.AdReceived += (sender, args) =>
            {
                if (!viewOnScreen)
                {
                    this.AddSubview(adView);
                    viewOnScreen = true;
                }
            };
            adView.LoadRequest(GADRequest.Request);
            base.SetNativeControl(adView);
        }
    }
}
