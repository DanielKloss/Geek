using Microsoft.Services.Store.Engagement;
using System;
using Windows.ApplicationModel;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TheGeek.UserInterface.Views
{
    public sealed partial class AboutView : Page
    {
        public AboutView()
        {
            InitializeComponent();

            if (StoreServicesFeedbackLauncher.IsSupported())
            {
                feedbackButton.Visibility = Visibility.Visible;
            }
        }

        private async void moreInfoButton_Click(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("http://www.boardgamegeek.com"));
        }

        private async void rateAndReviewButton_Click(object sender, RoutedEventArgs e)
        {
            string packageFamilyName = Package.Current.Id.FamilyName;
            await Launcher.LaunchUriAsync(new Uri("ms-windows-store:REVIEW?PFN=" + packageFamilyName));
        }

        private async void feedbackButton_Click(object sender, RoutedEventArgs e)
        {
            var launcher = StoreServicesFeedbackLauncher.GetDefault();
            await launcher.LaunchAsync();
        }
    }
}
