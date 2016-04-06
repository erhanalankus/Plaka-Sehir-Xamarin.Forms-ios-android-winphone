using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Xamarin;

namespace PlakaSehir.WinPhone
{
    public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage
    {
        public MainPage()
        {
            Insights.Initialize(""); //TODO Private Info

            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.Portrait;

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new PlakaSehir.App());
        }
    }
}
