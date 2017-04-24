using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TheGeek.UserInterface.Controls
{
    public sealed partial class MiniFilterControlBox : UserControl
    {
        public static readonly DependencyProperty IsFilteredProperty = DependencyProperty.Register("IsFiltered", typeof(bool), typeof(FilterControlBox), new PropertyMetadata(false));
        public bool IsFiltered
        {
            get { return (bool)GetValue(IsFilteredProperty); }
            set { SetValue(IsFilteredProperty, value); }
        }

        public static readonly DependencyProperty IsWorkingProperty = DependencyProperty.Register("IsWorking", typeof(bool), typeof(FilterControlBox), new PropertyMetadata(false));
        public bool IsWorking
        {
            get { return (bool)GetValue(IsWorkingProperty); }
            set { SetValue(IsWorkingProperty, value); }
        }

        public static readonly DependencyProperty RatingMinProperty = DependencyProperty.Register("RatingMin", typeof(double), typeof(FilterControlBox), new PropertyMetadata(1.0));
        public double RatingMin
        {
            get { return (double)GetValue(RatingMinProperty); }
            set { SetValue(RatingMinProperty, value); }
        }

        public static readonly DependencyProperty RatingMaxProperty = DependencyProperty.Register("RatingMax", typeof(double), typeof(FilterControlBox), new PropertyMetadata(1.0));
        public double RatingMax
        {
            get { return (double)GetValue(RatingMaxProperty); }
            set { SetValue(RatingMaxProperty, value); }
        }

        public static readonly DependencyProperty AvRatingMinProperty = DependencyProperty.Register("AvRatingMin", typeof(double), typeof(FilterControlBox), new PropertyMetadata(0.0));
        public double AvRatingMin
        {
            get { return (double)GetValue(AvRatingMinProperty); }
            set { SetValue(AvRatingMinProperty, value); }
        }

        public static readonly DependencyProperty AvRatingMaxProperty = DependencyProperty.Register("AvRatingMax", typeof(double), typeof(FilterControlBox), new PropertyMetadata(0.0));
        public double AvRatingMax
        {
            get { return (double)GetValue(AvRatingMaxProperty); }
            set { SetValue(AvRatingMaxProperty, value); }
        }

        public static readonly DependencyProperty ComplexityMinProperty = DependencyProperty.Register("ComplexityMin", typeof(double), typeof(FilterControlBox), new PropertyMetadata(0.0));
        public double ComplexityMin
        {
            get { return (double)GetValue(ComplexityMinProperty); }
            set { SetValue(ComplexityMinProperty, value); }
        }

        public static readonly DependencyProperty ComplexityMaxProperty = DependencyProperty.Register("ComplexityMax", typeof(double), typeof(FilterControlBox), new PropertyMetadata(0.0));
        public double ComplexityMax
        {
            get { return (double)GetValue(ComplexityMaxProperty); }
            set { SetValue(ComplexityMaxProperty, value); }
        }

        public static readonly DependencyProperty LengthMinProperty = DependencyProperty.Register("LengthMin", typeof(double), typeof(FilterControlBox), new PropertyMetadata(0.0));
        public double LengthMin
        {
            get { return (double)GetValue(LengthMinProperty); }
            set { SetValue(LengthMinProperty, value); }
        }

        public static readonly DependencyProperty LengthMaxProperty = DependencyProperty.Register("LengthMax", typeof(double), typeof(FilterControlBox), new PropertyMetadata(0.0));
        public double LengthMax
        {
            get { return (double)GetValue(LengthMaxProperty); }
            set { SetValue(LengthMaxProperty, value); }
        }

        public static readonly DependencyProperty NumberOfPlayersProperty = DependencyProperty.Register("NumberOfPlayers", typeof(int), typeof(FilterControlBox), new PropertyMetadata(1));
        public int NumberOfPlayers
        {
            get { return (int)GetValue(NumberOfPlayersProperty); }
            set { SetValue(NumberOfPlayersProperty, value); }
        }

        public MiniFilterControlBox()
        {
            this.InitializeComponent();
        }
    }
}
