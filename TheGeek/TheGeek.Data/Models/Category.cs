using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;
using TheGeek.Data.Models.LinkModels;

namespace TheGeek.Data.Models
{
    public class Category : Model
    {
        [PrimaryKey]
        public int categoryId { get; set; }

        [ManyToMany(typeof(BoardGameCategory))]
        public List<BoardGame> boardGames { get; set; }
    }
}
