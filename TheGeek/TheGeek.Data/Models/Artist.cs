using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;
using TheGeek.Data.Models.LinkModels;

namespace TheGeek.Data.Models
{
    public class Artist : Model
    {
        [PrimaryKey]
        public int artistId { get; set; }

        [ManyToMany(typeof(BoardGameArtist))]
        public List<BoardGame> boardGames { get; set; }
    }
}
