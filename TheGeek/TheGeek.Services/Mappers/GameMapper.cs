using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using TheGeek.Data.Models;

namespace TheGeek.Services.Mappers
{
    public class GameMapper
    {
        public List<BoardGame> Map(List<BoardGame> existingGames, string response)
        {
            XDocument xmlFile;

            try
            {
                xmlFile = XDocument.Parse(response);
            }
            catch (XmlException)
            {
                return new List<BoardGame>();
            }

            foreach (BoardGame existingGame in existingGames)
            {
                var games = from game in xmlFile.Descendants("item")
                            where game.Attribute("id").Value == existingGame.boardGameId.ToString()
                            select new
                            {
                                description = game.TryGetElement("description", new XElement("description", "no description")).Value,
                                weight = game.TryGetElement("statistics", new XElement("statistics", "no statistics")).TryGetElement("ratings").TryGetElement("averageweight").TryGetAttribute("value", new XAttribute("value", "0")).Value,
                                minAge = game.TryGetElement("minage", new XElement("name", "no minage")).TryGetAttribute("value", new XAttribute("value", "0")).Value,
                                desingers = game.Elements("link").Where(t => t.TryGetAttribute("type").Value == "boardgamedesigner"),
                                categories = game.Elements("link").Where(t => t.TryGetAttribute("type").Value == "boardgamecategory"),
                                mechanics = game.Elements("link").Where(t => t.TryGetAttribute("type").Value == "boardgamemechanic"),
                                expansions = game.Elements("link").Where(t => t.TryGetAttribute("type").Value == "boardgameexpansion"),
                                artists = game.Elements("link").Where(t => t.TryGetAttribute("type").Value == "boardgameartist")
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
                        existingGame.categories.Add(new Category { categoryId = Convert.ToInt32(category.TryGetAttribute("id", new XAttribute("value", "-1")).Value), name = category.TryGetAttribute("value", new XAttribute("value", "-1")).Value });
                    }

                    foreach (var mechanic in game.mechanics)
                    {
                        existingGame.mechanics.Add(new Mechanic { mechanicId = Convert.ToInt32(mechanic.TryGetAttribute("id", new XAttribute("value", "-1")).Value), name = mechanic.TryGetAttribute("value", new XAttribute("value", "-1")).Value });
                    }

                    foreach (var expansion in game.expansions)
                    {
                        existingGame.expansions.Add(new Expansion { expansionId = Convert.ToInt32(expansion.TryGetAttribute("id", new XAttribute("value", "-1")).Value), name = expansion.TryGetAttribute("value", new XAttribute("value", "-1")).Value });
                    }

                    foreach (var desinger in game.desingers)
                    {
                        existingGame.designers.Add(new Designer { designerId = Convert.ToInt32(desinger.TryGetAttribute("id", new XAttribute("value", "-1")).Value), name = desinger.TryGetAttribute("value", new XAttribute("value", "-1")).Value });
                    }

                    foreach (var artist in game.artists)
                    {
                        existingGame.artists.Add(new Artist { artistId = Convert.ToInt32(artist.TryGetAttribute("id", new XAttribute("value", "-1")).Value), name = artist.TryGetAttribute("value", new XAttribute("value", "-1")).Value });
                    }
                }
            }

            return existingGames;
        }
    }
}
