using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace TheGeek.Data.Models.LinkModels
{
    public class BoardGameArtist
    {
        [PrimaryKey, AutoIncrement]
        public int boardGameArtistId { get; set; }

        [ForeignKey(typeof(BoardGame))]
        public int boardGameId { get; set; }

        [ForeignKey(typeof(Artist))]
        public int artistId { get; set; }
    }
}
