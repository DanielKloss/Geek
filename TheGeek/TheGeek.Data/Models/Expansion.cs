using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;
using TheGeek.Data.Models.LinkModels;

namespace TheGeek.Data.Models
{
    public class Expansion : Model
    {
        [PrimaryKey]
        public int expansionId { get; set; }

        [ManyToMany(typeof(BoardGameExpansion))]
        public List<BoardGame> boardGames { get; set; }
    }
}
