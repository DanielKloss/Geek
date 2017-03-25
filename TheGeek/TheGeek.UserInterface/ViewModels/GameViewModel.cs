using TheGeek.Data.Models;

namespace TheGeek.UserInterface.ViewModels
{
    class GameViewModel : BaseViewModel
    {
        private BoardGame _game;
        public BoardGame game
        {
            get { return _game; }
            set
            {
                _game = value;
                OnPropertyChanged(nameof(game));
            }
        }

        public GameViewModel(BoardGame Game)
        {
            game = Game;
        }
    }
}
