using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;
using System.Linq;
using TheGeek.Data.Models.LinkModels;

namespace TheGeek.Data.Models
{
    public enum WishListRating
    {
        NotOnWishlist,
        MustHave,
        LoveToHave,
        LikeToHave,
        ThinkingAboutIt,
        DontBuyThis
    }

    public class BoardGame : Model
    {
        [PrimaryKey]
        public int boardGameId { get; set; }

        public string description { get; set; }

        public int yearPublished { get; set; }

        public string image { get; set; }

        public string thumbnail { get; set; }

        public bool owned { get; set; }

        public bool previouslyOwned { get; set; }

        public bool forTrade { get; set; }

        public bool want { get; set; }

        public bool wantToPlay { get; set; }

        public bool preOrdered { get; set; }

        public int minimumPlayers { get; set; }

        public int maximumPlayers { get; set; }

        public string numberOfPlayers => string.Join(" - ", minimumPlayers, maximumPlayers);

        public int minimumPlayTime { get; set; }

        public int maximumPlayTime { get; set; }

        public int playTime { get; set; }

        public string displayPlayTime => string.Join(" - ", minimumPlayTime, maximumPlayTime);

        public int minAge { get; set; }

        public int numberOfPlays { get; set; }

        public double rating { get; set; }

        public double average { get; set; }

        public double weight { get; set; }

        public WishListRating wishlist { get; set; }

        [ManyToMany(typeof(BoardGameArtist), CascadeOperations = CascadeOperation.All)]
        public List<Artist> artists { get; set; }

        [ManyToMany(typeof(BoardGameCategory), CascadeOperations = CascadeOperation.All)]
        public List<Category> categories { get; set; }

        [ManyToMany(typeof(BoardGameMechanic), CascadeOperations = CascadeOperation.All)]
        public List<Mechanic> mechanics { get; set; }

        [ManyToMany(typeof(BoardGameExpansion), CascadeOperations = CascadeOperation.All)]
        public List<Expansion> expansions { get; set; }

        [ManyToMany(typeof(BoardGameDesigner), CascadeOperations = CascadeOperation.All)]
        public List<Designer> designers { get; set; }
    }
}
