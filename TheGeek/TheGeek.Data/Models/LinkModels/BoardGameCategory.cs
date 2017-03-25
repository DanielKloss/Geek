using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace TheGeek.Data.Models.LinkModels
{
    public class BoardGameCategory
    {
        [PrimaryKey, AutoIncrement]
        public int boardGameCategoryId { get; set; }

        [ForeignKey(typeof(BoardGame))]
        public int boardGameId { get; set; }

        [ForeignKey(typeof(Category))]
        public int categoryId { get; set; }
    }
}
