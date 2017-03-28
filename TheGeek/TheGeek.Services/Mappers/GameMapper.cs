using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using TheGeek.Data.Models;

namespace TheGeek.Services.Mappers
{
    public class GameMapper
    {
        public List<BoardGame> Map(List<BoardGame> existingGames, string response)
        {
            XDocument xmlFile = XDocument.Parse(response);

            foreach (BoardGame existingGame in existingGames)
            {
                var games = from game in xmlFile.Descendants("item")
                            where game.Attribute("id").Value == existingGame.boardGameId.ToString()
                            select new
                            {
                                description = game.Element("description").Value,
                                weight = game.Element("statistics").Element("ratings").Element("averageweight").Attribute("value").Value,
                                minAge = game.Element("minage").Attribute("value").Value,
                                desingers = game.Elements("link").Where(t => t.Attribute("type").Value == "boardgamedesigner"),
                                categories = game.Elements("link").Where(t => t.Attribute("type").Value == "boardgamecategory"),
                                mechanics = game.Elements("link").Where(t => t.Attribute("type").Value == "boardgamemechanic"),
                                expansions = game.Elements("link").Where(t => t.Attribute("type").Value == "boardgameexpansion"),
                                artists = game.Elements("link").Where(t => t.Attribute("type").Value == "boardgameartist")
                            };

                if (games.Count() > 1)
                {
                    //Problem
                    throw new Exception();
                }

                foreach (var game in games)
                {
                    existingGame.description = WebUtility.HtmlDecode(game.description);
                    existingGame.weight = Math.Round(Convert.ToDouble(game.weight), 1);
                    existingGame.minAge = Convert.ToInt32(game.minAge);

                    foreach (var category in game.categories)
                    {
                        existingGame.categories.Add(new Category { categoryId = Convert.ToInt32(category.Attribute("id").Value), name = category.Attribute("value").Value });
                    }

                    foreach (var mechanic in game.mechanics)
                    {
                        existingGame.mechanics.Add(new Mechanic { mechanicId = Convert.ToInt32(mechanic.Attribute("id").Value), name = mechanic.Attribute("value").Value });
                    }

                    foreach (var expansion in game.expansions)
                    {
                        existingGame.expansions.Add(new Expansion { expansionId = Convert.ToInt32(expansion.Attribute("id").Value), name = expansion.Attribute("value").Value });
                    }

                    foreach (var desinger in game.desingers)
                    {
                        existingGame.designers.Add(new Designer { designerId = Convert.ToInt32(desinger.Attribute("id").Value), name = desinger.Attribute("value").Value });
                    }

                    foreach (var artist in game.artists)
                    {
                        existingGame.artists.Add(new Artist { artistId = Convert.ToInt32(artist.Attribute("id").Value), name = artist.Attribute("value").Value });
                    }
                }
            }

            return existingGames;
        }
    }
}
