using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;
using TheGeek.Data.Models.LinkModels;

namespace TheGeek.Data.Models
{
    public class Designer : Model
    {
        [PrimaryKey]
        public int designerId { get; set; }

        [ManyToMany(typeof(BoardGameDesigner))]
        public List<BoardGame> boardGames { get; set; }
    }
}
