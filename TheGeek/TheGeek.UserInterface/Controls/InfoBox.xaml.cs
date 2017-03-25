using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TheGeek.UserInterface.Controls
{
    public sealed partial class InfoBox : UserControl
    {
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(string), typeof(InfoBox), new PropertyMetadata(""));
        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty TitleTextProperty = DependencyProperty.Register("TitleText", typeof(string), typeof(InfoBox), new PropertyMetadata(""));
        public string TitleText
        {
            get { return (string)GetValue(TitleTextProperty); }
            set { SetValue(TitleTextProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(InfoBox), new PropertyMetadata(""));
        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public InfoBox()
        {
            this.InitializeComponent();
        }
    }
}
