﻿using MvvmDialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TheGeek.Data.Models;
using TheGeek.Data.Repositories;
using TheGeek.UserInterface.Controllers;
using TheGeek.UserInterface.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace TheGeek.UserInterface.ViewModels
{
    public class CollectionViewModel : BaseViewModel
    {
        private IDialogService _dialogService;
        private GameController _gameController;
        private BoardGameRepository _boardGameRepository;
        private SettingsController _settingsController;
        private Random _random;
        public bool isNarrow = false;

        private string _username;
        public string username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(username));
            }
        }

        private bool _isLoggedIn;
        public bool isLoggedIn
        {
            get { return _isLoggedIn; }
            set
            {
                _isLoggedIn = value;
                OnPropertyChanged(nameof(isLoggedIn));
            }
        }

        private ObservableCollection<BoardGame> _baseCollection;
        public ObservableCollection<BoardGame> baseCollection
        {
            get { return _baseCollection; }
            set
            {
                _baseCollection = value;
                OnPropertyChanged(nameof(baseCollection));
            }
        }

        private ObservableCollection<BoardGame> _filteredBaseCollection;
        public ObservableCollection<BoardGame> filteredbaseCollection
        {
            get { return _filteredBaseCollection; }
            set
            {
                _filteredBaseCollection = value;
                OnPropertyChanged(nameof(filteredbaseCollection));
            }
        }

        private ObservableCollection<string> _searchCategories;
        public ObservableCollection<string> searchCategories
        {
            get { return _searchCategories; }
            set
            {
                _searchCategories = value;
                OnPropertyChanged(nameof(searchCategories));
            }
        }

        private bool _isWorking;
        public bool isWorking
        {
            get { return _isWorking; }
            set
            {
                _isWorking = value;
                OnPropertyChanged(nameof(isWorking));
            }
        }

        private bool _isFiltered;
        public bool isFiltered
        {
            get { return _isFiltered; }
            set
            {
                _isFiltered = value;
                OnPropertyChanged(nameof(isFiltered));
                Filter();
            }
        }

        #region Filters
        private int _searchType;
        public int searchType
        {
            get { return _searchType; }
            set
            {
                _searchType = value;
                OnPropertyChanged(nameof(searchType));
                Filter();
            }
        }

        private string _filterText;
        public string filterText
        {
            get { return _filterText; }
            set
            {
                _filterText = value;
                OnPropertyChanged(nameof(filterText));
                Filter();
            }
        }

        private double _minimumComplexity;
        public double minimumComplexity
        {
            get { return _minimumComplexity; }
            set
            {
                _minimumComplexity = value;
                OnPropertyChanged(nameof(minimumComplexity));
                Filter();
            }
        }

        private double _maximumComplexity;
        public double maximumComplexity
        {
            get { return _maximumComplexity; }
            set
            {
                _maximumComplexity = value;
                OnPropertyChanged(nameof(maximumComplexity));
                Filter();
            }
        }

        private int _minimumLength;
        public int minimumLength
        {
            get { return _minimumLength; }
            set
            {
                _minimumLength = value;
                OnPropertyChanged(nameof(minimumLength));
                Filter();
            }
        }

        private int _maximumLength;
        public int maximumLength
        {
            get { return _maximumLength; }
            set
            {
                _maximumLength = value;
                OnPropertyChanged(nameof(maximumLength));
                Filter();
            }
        }

        private int _numberOfPlayers;
        public int numberOfPlayers
        {
            get { return _numberOfPlayers; }
            set
            {
                _numberOfPlayers = value;
                OnPropertyChanged(nameof(numberOfPlayers));
                Filter();
            }
        }

        private double _minimumRating;
        public double minimumRating
        {
            get { return _minimumRating; }
            set
            {
                _minimumRating = value;
                OnPropertyChanged(nameof(maximumRating));
                Filter();
            }
        }

        private double _maximumRating;
        public double maximumRating
        {
            get { return _maximumRating; }
            set
            {
                _maximumRating = value;
                OnPropertyChanged(nameof(maximumRating));
                Filter();
            }
        }

        private double _minimumAverageRating;
        public double minimumAverageRating
        {
            get { return _minimumAverageRating; }
            set
            {
                _minimumAverageRating = value;
                OnPropertyChanged(nameof(minimumAverageRating));
                Filter();
            }
        }

        private double _maximumAverageRating;
        public double maximumAverageRating
        {
            get { return _maximumAverageRating; }
            set
            {
                _maximumAverageRating = value;
                OnPropertyChanged(nameof(maximumAverageRating));
                Filter();
            }
        }
        #endregion

        private ICommand _showGameDetailCommand;
        public ICommand showGameDetailCommand
        {
            get
            {
                if (_showGameDetailCommand == null)
                {
                    _showGameDetailCommand = new Command<BoardGame>(ShowGameDetail);
                }

                return _showGameDetailCommand;
            }
            set { _showGameDetailCommand = value; }
        }

        private ICommand _getBaseCollectionCommand;
        public ICommand getBaseCollectionCommand
        {
            get
            {
                if (_getBaseCollectionCommand == null)
                {
                    _getBaseCollectionCommand = new Command(GetBaseCollectionOwned);
                }
                return _getBaseCollectionCommand;
            }
            set { _getBaseCollectionCommand = value; }
        }

        private ICommand _refreshCollectionCommand;
        public ICommand refreshCollectionCommand
        {
            get
            {
                if (_refreshCollectionCommand == null)
                {
                    _refreshCollectionCommand = new Command(refreshCollection);
                }
                return _refreshCollectionCommand;
            }
            set { _refreshCollectionCommand = value; }
        }

        private ICommand _chooseRandomGameCommand;
        public ICommand chooseRandomGameCommand
        {
            get
            {
                if (_chooseRandomGameCommand == null)
                {
                    _chooseRandomGameCommand = new Command(ChooseRandomGame);
                }

                return _chooseRandomGameCommand;
            }
            set { _chooseRandomGameCommand = value; }
        }

        private ICommand _logoutCommand;
        public ICommand logoutCommand
        {
            get
            {
                if (_logoutCommand == null)
                {
                    _logoutCommand = new Command(Logout);
                }

                return _logoutCommand;
            }
            set { _logoutCommand = value; }
        }

        private ICommand _aboutCommand;
        public ICommand aboutCommand
        {
            get
            {
                if (_aboutCommand == null)
                {
                    _aboutCommand = new Command(NavigateToAbout);
                }

                return _aboutCommand;
            }
            set { _aboutCommand = value; }
        }

        public CollectionViewModel(BoardGameRepository BoardGameRepository, GameController GameController, SettingsController SettingsController, IDialogService dialogService, Random Random)
        {
            _dialogService = dialogService;
            _boardGameRepository = BoardGameRepository;
            _gameController = GameController;
            _settingsController = SettingsController;
            _random = Random;

            IsLoggedIn();

            baseCollection = new ObservableCollection<BoardGame>(_gameController.LoadGames());
            filteredbaseCollection = new ObservableCollection<BoardGame>(baseCollection.OrderBy(b => b.name));

            searchCategories = new ObservableCollection<string>()
            {
                "Board Game",
                "Designer",
                "Mechanic",
                "Artist",
                "Category",
                "Expansion"
            };

            isWorking = false;
            isFiltered = false;
            filterText = "";
            searchType = 0;

            SetFilters();
        }

        private void SetFilters()
        {
            isFiltered = _settingsController.GetIsFiltered();

            numberOfPlayers = _settingsController.GetNumberOfPlayers() == 0 ? 4 : _settingsController.GetNumberOfPlayers();

            minimumComplexity = _settingsController.GetMinimumComplexity();
            minimumAverageRating = _settingsController.GetMinimumAverageRating();
            minimumRating = _settingsController.GetMinimumRating();
            minimumLength = _settingsController.GetMinimumLength();

            maximumComplexity = _settingsController.GetMaximumComplexity() == 0 ? 5 : _settingsController.GetMaximumComplexity();
            maximumLength = _settingsController.GetMaximumLength() == 0 ? 60 : _settingsController.GetMaximumLength();
            maximumAverageRating = _settingsController.GetMaximumAverageRating() == 0 ? 10 : _settingsController.GetMaximumAverageRating();
            maximumRating = _settingsController.GetMaximumRating() == 0 ? 10 : _settingsController.GetMaximumRating();

            filterText = _settingsController.GetSearchTerm();
            searchType = _settingsController.GetCategoryIndex();
        }

        internal void SaveFilters()
        {
            _settingsController.SetFilters(numberOfPlayers, minimumRating, maximumRating, minimumAverageRating, maximumAverageRating, minimumComplexity, maximumComplexity, minimumLength, maximumLength);
            _settingsController.SetIsFiltered(isFiltered);
            _settingsController.SetSearch(filterText, searchType);
        }

        private void IsLoggedIn()
        {
            if (_settingsController.GetUsername() == null || _settingsController.GetUsername() == String.Empty)
            {
                isLoggedIn = false;
            }
            else
            {
                username = _settingsController.GetUsername();
                isLoggedIn = true;
            }
        }

        private async void Logout()
        {
            var dialogViewModel = new ConfirmContentDialogViewModel("Logout", "Are you sure you want to logout?");

            ContentDialogResult result = await _dialogService.ShowContentDialogAsync(dialogViewModel);
            if (result == ContentDialogResult.Primary)
            {
                _settingsController.SetUsername(null);

                _gameController.ClearAllGames();

                filteredbaseCollection.Clear();

                IsLoggedIn();
            }
        }

        private void ShowGameDetail(BoardGame gameToShow)
        {
            ((App)Application.Current).rootFrame.Navigate(typeof(GameView), gameToShow, new DrillInNavigationTransitionInfo());
        }

        private void NavigateToAbout()
        {
            ((App)Application.Current).rootFrame.Navigate(typeof(AboutView), new DrillInNavigationTransitionInfo());
        }

        private async void refreshCollection()
        {
            var dialogViewModel = new ConfirmContentDialogViewModel("Refresh Collection", "Are you sure you want to refresh the collection for this user?");

            ContentDialogResult result = await _dialogService.ShowContentDialogAsync(dialogViewModel);
            if (result == ContentDialogResult.Primary)
            {
                GetBaseCollectionOwned();
            }
        }

        private async void GetBaseCollectionOwned()
        {
            isWorking = true;

            if (username != string.Empty)
            {
                _settingsController.SetUsername(username);

                IsLoggedIn();

                baseCollection = new ObservableCollection<BoardGame>(await _gameController.GetGames(username));

                if (baseCollection.Count == 0)
                {
                    var dialogViewModel = new NoConfirmContentDialogViewModel("No Games Found", "No games were found for this BGG user");

                    await _dialogService.ShowContentDialogAsync(dialogViewModel);
                    baseCollection = filteredbaseCollection;
                }
                else
                {
                    filteredbaseCollection = new ObservableCollection<BoardGame>(baseCollection.OrderBy(b => b.name));
                    _boardGameRepository.InsertBoardGames(new List<BoardGame>(baseCollection));
                }
            }

            isWorking = false;
        }

        private void ChooseRandomGame()
        {
            if (filteredbaseCollection.Count > 0)
            {
                ShowGameDetail(filteredbaseCollection[_random.Next(0, filteredbaseCollection.Count)]);
            }
        }

        private void Filter()
        {
            filteredbaseCollection.Clear();

            foreach (BoardGame game in baseCollection)
            {
                if (isFiltered)
                {
                    if (TextSearch(game, searchType) && ComplexitySearch(game) && LengthSearch(game) && PlayersSearch(game) && RatingSearch(game) && AverageRatingSearch(game))
                    {
                        filteredbaseCollection.Add(game);
                    }
                }
                else
                {
                    if (TextSearch(game, searchType))
                    {
                        filteredbaseCollection.Add(game);
                    }
                }
            }

            filteredbaseCollection = new ObservableCollection<BoardGame>(filteredbaseCollection.OrderBy(b => b.name));
        }

        private bool TextSearch(BoardGame game, int searchType)
        {
            if (filterText == null || filterText == string.Empty)
            {
                return true;
            }

            string searchTerm = filterText.ToUpper();

            switch (searchType)
            {
                case 0:
                    return game.name.ToUpper().Contains(searchTerm);
                case 1:
                    return game.designers.FindAll(d => d.name.ToUpper().Contains(searchTerm)).Count > 0;
                case 2:
                    return game.mechanics.FindAll(m => m.name.ToUpper().Contains(searchTerm)).Count > 0;
                case 3:
                    return game.artists.FindAll(a => a.name.ToUpper().Contains(searchTerm)).Count > 0;
                case 4:
                    return game.categories.FindAll(c => c.name.ToUpper().Contains(searchTerm)).Count > 0;
                case 5:
                    return game.expansions.FindAll(c => c.name.ToUpper().Contains(searchTerm)).Count > 0;
                default:
                    return true;
            }
        }

        private bool ComplexitySearch(BoardGame game)
        {
            return game.weight >= minimumComplexity && game.weight <= maximumComplexity;
        }

        private bool LengthSearch(BoardGame game)
        {
            return game.playTime >= minimumLength && game.playTime <= maximumLength;
        }

        private bool PlayersSearch(BoardGame game)
        {
            return (numberOfPlayers >= game.minimumPlayers && numberOfPlayers <= game.maximumPlayers);
        }

        private bool RatingSearch(BoardGame game)
        {
            return game.rating >= minimumRating && game.rating <= maximumRating;
        }

        private bool AverageRatingSearch(BoardGame game)
        {
            return game.average >= minimumAverageRating && game.average <= maximumAverageRating;
        }
    }
}
