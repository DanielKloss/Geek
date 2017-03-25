using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace TheGeek.Data.Models.LinkModels
{
    public class BoardGameExpansion
    {
        [PrimaryKey, AutoIncrement]
        public int boardGameExpansionId { get; set; }

        [ForeignKey(typeof(BoardGame))]
        public int boardGameId { get; set; }

        [ForeignKey(typeof(Expansion))]
        public int expansionId { get; set; }
    }
}
