using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TheGeek.UserInterface.Controls
{
    public sealed partial class BoardGameSearchBox : UserControl
    {
        public static readonly DependencyProperty FilterTextProperty = DependencyProperty.Register("FilterText", typeof(string), typeof(BoardGameSearchBox), new PropertyMetadata(""));
        public string FilterText
        {
            get { return (string)GetValue(FilterTextProperty); }
            set { SetValue(FilterTextProperty, value); }
        }

        public static readonly DependencyProperty SearchCategoriesProperty = DependencyProperty.Register("SearchCategories", typeof(ObservableCollection<string>), typeof(BoardGameSearchBox), new PropertyMetadata(""));
        public ObservableCollection<string> SearchCategories
        {
            get { return (ObservableCollection<string>)GetValue(SearchCategoriesProperty); }
            set { SetValue(SearchCategoriesProperty, value); }
        }

        public static readonly DependencyProperty SelectedSearchCategoryProperty = DependencyProperty.Register("SelectedSearchCategory", typeof(int), typeof(BoardGameSearchBox), new PropertyMetadata(0));
        public int SelectedSearchCategory
        {
            get { return (int)GetValue(SelectedSearchCategoryProperty); }
            set { SetValue(SelectedSearchCategoryProperty, value); }
        }

        public static readonly DependencyProperty IsWorkingProperty = DependencyProperty.Register("IsWorking", typeof(bool), typeof(BoardGameSearchBox), new PropertyMetadata(false));
        public bool IsWorking
        {
            get { return (bool)GetValue(IsWorkingProperty); }
            set { SetValue(IsWorkingProperty, value); }
        }

        public BoardGameSearchBox()
        {
            InitializeComponent();
        }
    }
}
