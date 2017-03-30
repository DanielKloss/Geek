using Windows.UI.Xaml.Controls;

namespace TheGeek.UserInterface.Views
{
    public sealed partial class ConfirmContentDialog : ContentDialog
    {
        public ConfirmContentDialog()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
