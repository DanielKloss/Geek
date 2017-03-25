using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheGeek.Data.Models;
using TheGeek.Data.Repositories;
using TheGeek.Services.Mappers;
using TheGeek.Services.Services;

namespace TheGeek.UserInterface.Controllers
{
    public class GameController
    {
        private GameService _gameService;
        private CollectionService _collectionService;
        private GameMapper _gameMapper;
        private CollectionMapper _collectionMapper;
        private BoardGameRepository _boardGameRepository;

        public GameController(GameMapper GameMapper, GameService GameService, CollectionMapper CollectionMapper, CollectionService CollectionService, BoardGameRepository DatabaseContext)
        {
            _gameMapper = GameMapper;
            _gameService = GameService;
            _collectionMapper = CollectionMapper;
            _collectionService = CollectionService;
            _boardGameRepository = DatabaseContext;
        }

        internal async Task<List<BoardGame>> GetGames(string username)
        {
            _boardGameRepository.DatabaseExists();

            List<BoardGame> baseCollection = new List<BoardGame>();

            //Get collection data from service asynchronously
            string baseCollectionResponse = await _collectionService.GetBaseCollectionOwnedAsync(username);

            //Map data to collection
            baseCollection = await _collectionMapper.Map(baseCollectionResponse);

            List<int> ids = new List<int>();

            //Get detail game data
            foreach (BoardGame game in baseCollection)
            {
                ids.Add(game.boardGameId);
            }

            string response = await _gameService.GetGameDetailsAsync(ids);

            baseCollection = _gameMapper.Map(baseCollection, response);

            _boardGameRepository.InsertBoardGames(baseCollection);

            return baseCollection;
        }

        internal void ClearAllGames()
        {
            _boardGameRepository.ClearDatabase();
        }

        internal List<BoardGame> LoadGames()
        {
            _boardGameRepository.DatabaseExists();
            return _boardGameRepository.GetCollection();
        }
    }
}
