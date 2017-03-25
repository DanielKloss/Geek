using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace TheGeek.Data.Models.LinkModels
{
    public class BoardGameDesigner
    {
        [PrimaryKey, AutoIncrement]
        public int boardGameDesignerId { get; set; }

        [ForeignKey(typeof(BoardGame))]
        public int boardGameId { get; set; }

        [ForeignKey(typeof(Designer))]
        public int designerId { get; set; }
    }
}
