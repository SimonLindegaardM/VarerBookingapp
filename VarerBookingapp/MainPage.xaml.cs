using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace VarerBookingapp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public InternettoViewModel ViewModel { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            ViewModel = new InternettoViewModel();
        }

        private void click_hjem(object sender, RoutedEventArgs e)
        {
            frame.Navigate(typeof(Hjem));
        }
        private void click_omos(object sender, RoutedEventArgs e)
        {
            frame.Navigate(typeof(OmOs));
        }
        private void click_indkøbskurv(object sender, RoutedEventArgs e)
        {
            frame.Navigate(typeof(Indkøbskurv));
        }
        private void click_loginopret(object sender, RoutedEventArgs e)
        {
            frame.Navigate(typeof(LoginOpret));
        }
    }
}
