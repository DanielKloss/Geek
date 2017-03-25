using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace TheGeek.Data.Models.LinkModels
{
    public class BoardGameMechanic
    {
        [PrimaryKey, AutoIncrement]
        public int boardGameMechanicId { get; set; }

        [ForeignKey(typeof(BoardGame))]
        public int boardGameId { get; set; }

        [ForeignKey(typeof(Mechanic))]
        public int mechanicId { get; set; }
    }
}
