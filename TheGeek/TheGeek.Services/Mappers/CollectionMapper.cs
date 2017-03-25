using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using TheGeek.Data.Models;
using TheGeek.Services.Services;

namespace TheGeek.Services.Mappers
{
    public class CollectionMapper
    {
        ImageDownloadService imageService = new ImageDownloadService();

        /// <summary>
        /// Maps a collection response to a board game collection
        /// </summary>
        /// <param name="collectionResponse">Raw data response from the BGG API</param>
        /// <returns>User's collection as a C# object</returns>
        public async Task<List<BoardGame>> Map(string collectionResponse)
        {
            string isTrue = "1";
            List<BoardGame> collection = new List<BoardGame>();

            XDocument xmlFile = XDocument.Parse(collectionResponse);

            var games = from game in xmlFile.Descendants("item")
                        select new
                        {
                            id = game.Attribute("objectid").Value,
                            name = game.Element("name").Value,
                            yearPublished = game.Element("yearpublished").Value,
                            image = game.Element("image").Value,
                            numberOfPlays = game.Element("numplays").Value,
                            minimumPlayers = game.Element("stats").Attribute("minplayers").Value,
                            maximumPlayers = game.Element("stats").Attribute("maxplayers").Value,
                            minimumPlayTime = game.Element("stats").Attribute("minplaytime").Value,
                            maximumPlayTime = game.Element("stats").Attribute("maxplaytime").Value,
                            PlayTime = game.Element("stats").Attribute("playingtime").Value,
                            numberOwned = game.Element("stats").Attribute("numowned").Value,
                            owned = game.Element("status").Attribute("own").Value,
                            previouslyOwned = game.Element("status").Attribute("prevowned").Value,
                            forTrade = game.Element("status").Attribute("fortrade").Value,
                            want = game.Element("status").Attribute("want").Value,
                            wantToPlay = game.Element("status").Attribute("wanttoplay").Value,
                            preOrdered = game.Element("status").Attribute("preordered").Value,
                            wishlist = game.Element("status").Attribute("wishlist").Value,
                            rating = game.Element("stats").Element("rating").Attribute("value").Value,
                            numberOfRatings = game.Element("stats").Element("rating").Element("usersrated").Attribute("value").Value,
                            averageRating = game.Element("stats").Element("rating").Element("average").Attribute("value").Value,
                            bayesianAverageRating = game.Element("stats").Element("rating").Element("bayesaverage").Attribute("value").Value,
                            standardDeviationRating = game.Element("stats").Element("rating").Element("stddev").Attribute("value").Value,
                            medianRating = game.Element("stats").Element("rating").Element("median").Attribute("value").Value
                        };

            foreach (var game in games)
            {
                double result;

                string image = await imageService.GetImageAsync("http:" + game.image, game.id);

                BoardGame boardGame = new BoardGame()
                {
                    boardGameId = Convert.ToInt32(game.id),
                    name = game.name,
                    yearPublished = Convert.ToInt32(game.yearPublished),
                    image = image,
                    minimumPlayers = Convert.ToInt32(game.minimumPlayers),
                    maximumPlayers = Convert.ToInt32(game.maximumPlayers),
                    minimumPlayTime = Convert.ToInt32(game.minimumPlayTime),
                    maximumPlayTime = Convert.ToInt32(game.maximumPlayTime),
                    playTime = Convert.ToInt32(game.PlayTime),
                    numberOfPlays = Convert.ToInt32(game.numberOfPlays),
                    rating = double.TryParse(game.rating, out result) ? Math.Round(Convert.ToDouble(game.rating), 1) : -1,
                    average = double.TryParse(game.averageRating, out result) ? Math.Round(Convert.ToDouble(game.averageRating), 1) : -1,
                    owned = game.owned == isTrue,
                    previouslyOwned = game.previouslyOwned == isTrue,
                    forTrade = game.forTrade == isTrue,
                    want = game.want == isTrue,
                    wantToPlay = game.wantToPlay == isTrue,
                    preOrdered = game.preOrdered == isTrue,
                    wishlist = (WishListRating)Enum.Parse(typeof(WishListRating), game.wishlist),
                    categories = new List<Category>(),
                    mechanics = new List<Mechanic>(),
                    expansions = new List<Expansion>(),
                    designers = new List<Designer>(),
                    artists = new List<Artist>()

                };

                collection.Add(boardGame);
            }

            return collection;
        }
    }
}
