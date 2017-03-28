using TheGeek.Data.Models;
using TheGeek.UserInterface.ViewModels;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace TheGeek.UserInterface.Views
{
    public sealed partial class GameView : Page
    {
        public GameView()
        {
            InitializeComponent();

            variableSizedWrapGrid.RegisterImplicitAnimations();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            BoardGame game = (BoardGame)e?.Parameter;
            DataContext = new GameViewModel(game);

            SystemNavigationManager systemNavigationManager = SystemNavigationManager.GetForCurrentView();
            systemNavigationManager.BackRequested += GameView_BackRequested;
            systemNavigationManager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        private void GameView_BackRequested(object sender, BackRequestedEventArgs e)
        {
            e.Handled = true;
            Frame.GoBack(new SuppressNavigationTransitionInfo());
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            SystemNavigationManager systemNavigationManager = SystemNavigationManager.GetForCurrentView();
            systemNavigationManager.BackRequested -= GameView_BackRequested;
            systemNavigationManager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }
    }
}
