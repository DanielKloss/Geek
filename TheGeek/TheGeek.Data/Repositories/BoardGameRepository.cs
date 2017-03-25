using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using System.Collections.Generic;
using System.IO;
using TheGeek.Data.Models;
using TheGeek.Data.Models.LinkModels;
using Windows.Storage;
using System;

namespace TheGeek.Data.Repositories
{
    public class BoardGameRepository
    {
        private static SQLiteConnection DbConnection
        {
            get
            {
                return new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), Path.Combine(ApplicationData.Current.LocalFolder.Path, "BBGDatabase.sqlite"));
            }
        }

        public bool DatabaseExists()
        {
            bool exists = DbConnection.GetTableInfo(nameof(BoardGame)).Count != 0;

            CreateTables();

            return exists;
        }

        private static void CreateTables()
        {
            if (DbConnection.GetTableInfo(nameof(BoardGame)).Count == 0)
            {
                DbConnection.CreateTable<BoardGame>();
            }

            if (DbConnection.GetTableInfo(nameof(Artist)).Count == 0)
            {
                DbConnection.CreateTable<Artist>();
            }

            if (DbConnection.GetTableInfo(nameof(Designer)).Count == 0)
            {
                DbConnection.CreateTable<Designer>();
            }

            if (DbConnection.GetTableInfo(nameof(Mechanic)).Count == 0)
            {
                DbConnection.CreateTable<Mechanic>();
            }

            if (DbConnection.GetTableInfo(nameof(Category)).Count == 0)
            {
                DbConnection.CreateTable<Category>();
            }

            if (DbConnection.GetTableInfo(nameof(Expansion)).Count == 0)
            {
                DbConnection.CreateTable<Expansion>();
            }

            if (DbConnection.GetTableInfo(nameof(BoardGameArtist)).Count == 0)
            {
                DbConnection.CreateTable<BoardGameArtist>();
            }

            if (DbConnection.GetTableInfo(nameof(BoardGameDesigner)).Count == 0)
            {
                DbConnection.CreateTable<BoardGameDesigner>();
            }

            if (DbConnection.GetTableInfo(nameof(BoardGameMechanic)).Count == 0)
            {
                DbConnection.CreateTable<BoardGameMechanic>();
            }

            if (DbConnection.GetTableInfo(nameof(BoardGameCategory)).Count == 0)
            {
                DbConnection.CreateTable<BoardGameCategory>();
            }

            if (DbConnection.GetTableInfo(nameof(BoardGameExpansion)).Count == 0)
            {
                DbConnection.CreateTable<BoardGameExpansion>();
            }
        }

        public void ClearDatabase()
        {
            DbConnection.DropTable<BoardGameExpansion>();
            DbConnection.DropTable<BoardGameCategory>();
            DbConnection.DropTable<BoardGameMechanic>();
            DbConnection.DropTable<BoardGameDesigner>();
            DbConnection.DropTable<BoardGameArtist>();

            DbConnection.DropTable<Expansion>();
            DbConnection.DropTable<Category>();
            DbConnection.DropTable<Mechanic>();
            DbConnection.DropTable<Designer>();
            DbConnection.DropTable<Artist>();
            DbConnection.DropTable<BoardGame>();
        }

        public void InsertBoardGames(List<BoardGame> boardGames)
        {
            DbConnection.InsertOrReplaceAllWithChildren(boardGames);
        }

        public List<BoardGame> GetCollection()
        {
            return DbConnection.GetAllWithChildren<BoardGame>();
        }
    }
}
