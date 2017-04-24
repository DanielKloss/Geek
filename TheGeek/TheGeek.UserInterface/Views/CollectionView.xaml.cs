using MvvmDialogs;
using System;
using TheGeek.Data.Repositories;
using TheGeek.Services.Mappers;
using TheGeek.Services.Services;
using TheGeek.UserInterface.Controllers;
using TheGeek.UserInterface.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace TheGeek.UserInterface.Views
{
    public sealed partial class CollectionView : Page
    {
        public CollectionView()
        {
            InitializeComponent();
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            var viewModel = (CollectionViewModel)DataContext;
            viewModel.SaveFilters();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            BoardGameRepository boardGameRepository = new BoardGameRepository();
            GameController gameController = new GameController(new GameMapper(), new GameService(), new CollectionMapper(), new CollectionService(), new BoardGameRepository());
            SettingsController settingsController = new SettingsController();
            DialogService dialogService = new DialogService();
            Random random = new Random();

            DataContext = new CollectionViewModel(boardGameRepository, gameController, settingsController, dialogService, random);

            CheckScreenWidth();
        }

        private void AdaptiveStates_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            var viewModel = (CollectionViewModel)DataContext;

            if (e.NewState.Name == "NarrowState")
            {
                viewModel.isNarrow = true;
            }
            else
            {
                viewModel.isNarrow = false;
            }
        }

        private void CheckScreenWidth()
        {
            var viewModel = (CollectionViewModel)DataContext;

            if (Window.Current.Bounds.Width <= 720)
            {
                viewModel.isNarrow = true;
            }
            else
            {
                viewModel.isNarrow = false;
            }
        }
    }
}
