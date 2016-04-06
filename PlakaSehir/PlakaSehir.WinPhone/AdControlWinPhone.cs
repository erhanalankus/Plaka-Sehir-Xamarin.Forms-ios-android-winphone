using GoogleAds;
using PlakaSehir;
using PlakaSehir.WinPhone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(AdControl), typeof(AdControlWinPhone))]
namespace PlakaSehir.WinPhone
{
    class AdControlWinPhone : ViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                AdView bannerAd = new AdView
                {
                    Format = AdFormats.Banner,
                    AdUnitID = "" //TODO Private Info
                };
                AdRequest adRequest = new AdRequest();
                bannerAd.LoadAd(adRequest);
                Children.Add(bannerAd);
            }
        }
    }
}
