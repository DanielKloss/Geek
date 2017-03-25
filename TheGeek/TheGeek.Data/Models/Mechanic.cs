using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;
using TheGeek.Data.Models.LinkModels;

namespace TheGeek.Data.Models
{
    public class Mechanic : Model
    {
        [PrimaryKey]
        public int mechanicId { get; set; }

        [ManyToMany(typeof(BoardGameMechanic))]
        public List<BoardGame> boardGames { get; set; }
    }
}
