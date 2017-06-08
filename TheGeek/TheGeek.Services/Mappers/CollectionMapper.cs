using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
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
            XDocument xmlFile;

            try
            {
                xmlFile = XDocument.Parse(collectionResponse);
            }
            catch (XmlException)
            {
                return new List<BoardGame>();
            }

            var games = from game in xmlFile.Descendants("item")
                        select new
                        {
                            id = game.Attribute("objectid").Value,
                            name = game.TryGetElement("name", new XElement("name","no name")).Value,
                            yearPublished = game.TryGetElement("yearpublished", new XElement("yearpublished", "0")).Value,
                            image = game.TryGetElement("image", new XElement("image", "no image")).Value,
                            numberOfPlays = game.TryGetElement("numplays", new XElement("numplays", "0")).Value,
                            minimumPlayers = game.TryGetElement("stats", new XElement("stats", "no stats")).TryGetAttribute("minplayers", new XAttribute("minplayers", "0")).Value,
                            maximumPlayers = game.TryGetElement("stats", new XElement("stats", "no stats")).TryGetAttribute("maxplayers", new XAttribute("maxplayers", "0")).Value,
                            minimumPlayTime = game.TryGetElement("stats", new XElement("stats", "no stats")).TryGetAttribute("minplaytime", new XAttribute("minplaytime", "0")).Value,
                            maximumPlayTime = game.TryGetElement("stats", new XElement("stats", "no stats")).TryGetAttribute("maxplaytime", new XAttribute("maxplaytime", "0")).Value,
                            PlayTime = game.TryGetElement("stats", new XElement("stats", "no stats")).TryGetAttribute("playingtime", new XAttribute("playingtime", "0")).Value,
                            numberOwned = game.TryGetElement("stats", new XElement("stats", "no stats")).TryGetAttribute("numowned", new XAttribute("numowned", "0")).Value,
                            owned = game.TryGetElement("status", new XElement("status", "no status")).TryGetAttribute("own", new XAttribute("own", "0")).Value,
                            previouslyOwned = game.TryGetElement("status", new XElement("status", "no status")).TryGetAttribute("prevowned", new XAttribute("prevowned", "0")).Value,
                            forTrade = game.TryGetElement("status", new XElement("status", "no status")).TryGetAttribute("fortrade", new XAttribute("fortrade", "0")).Value,
                            want = game.TryGetElement("status", new XElement("status", "no status")).TryGetAttribute("want", new XAttribute("want", "0")).Value,
                            wantToPlay = game.TryGetElement("status", new XElement("status", "no status")).TryGetAttribute("wanttoplay", new XAttribute("wanttoplay", "0")).Value,
                            preOrdered = game.TryGetElement("status", new XElement("status", "no status")).TryGetAttribute("preordered", new XAttribute("preordered", "0")).Value,
                            wishlist = game.TryGetElement("status", new XElement("status", "no status")).TryGetAttribute("wishlist", new XAttribute("wishlist", "0")).Value,
                            rating = game.TryGetElement("stats", new XElement("stats", "no stats")).TryGetElement("rating", new XElement("rating", "no rating")).TryGetAttribute("value", new XAttribute("value", "0")).Value,
                            numberOfRatings = game.TryGetElement("stats", new XElement("stats", "no stats")).TryGetElement("rating", new XElement("rating", "no rating")).TryGetElement("usersrated", new XElement("usersrated", "no usersrated")).TryGetAttribute("value", new XAttribute("value", "0")).Value,
                            averageRating = game.TryGetElement("stats", new XElement("stats", "no stats")).TryGetElement("rating", new XElement("rating", "no rating")).TryGetElement("average", new XElement("average", "no average")).TryGetAttribute("value", new XAttribute("value", "0")).Value,
                            bayesianAverageRating = game.TryGetElement("stats", new XElement("stats", "no stats")).TryGetElement("rating", new XElement("rating", "no rating")).TryGetElement("bayesaverage", new XElement("bayesaverage", "no bayesaverage")).TryGetAttribute("value", new XAttribute("value", "0")).Value,
                            standardDeviationRating = game.TryGetElement("stats", new XElement("stats", "no stats")).TryGetElement("rating", new XElement("rating", "no rating")).TryGetElement("stddev", new XElement("stddev", "no stddev")).TryGetAttribute("value", new XAttribute("value", "0")).Value,
                            medianRating = game.TryGetElement("stats", new XElement("stats", "no stats")).TryGetElement("rating", new XElement("rating", "no rating")).TryGetElement("median", new XElement("median", "no median")).TryGetAttribute("value", new XAttribute("value", "0")).Value
                        };

            foreach (var game in games)
            {
                double result;

                string image = await imageService.GetImageAsync(game.image, game.id);

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
                    rating = double.TryParse(game.rating, out result) ? Math.Round(Convert.ToDouble(game.rating), 1) : 0,
                    average = double.TryParse(game.averageRating, out result) ? Math.Round(Convert.ToDouble(game.averageRating), 1) : 0,
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
