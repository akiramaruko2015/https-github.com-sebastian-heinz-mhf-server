using System;
using MySql.Data.MySqlClient;
using Mhf.Server.Database.Sql.Core;

namespace Mhf.Server.Database.Sql
{
    /// <summary>
    /// SQLite Mhf database.
    /// </summary>
    public class MhfMariaDb : MhfSqlDb<MySqlConnection, MySqlCommand>, IDatabase
    {
        public const string MemoryDatabasePath = ":memory:";

        private const string SelectAutoIncrement = "SELECT last_insert_rowid()";


        private string _connectionString;

        public bool CreateDatabase()
        {
            throw new NotImplementedException();
        }

        public MhfMariaDb(string host, short port, string user, string password, string database)
        {
            _connectionString = $"host={host};port={port};user id={user};password={password};database={database};";
        }

        protected override MySqlConnection Connection()
        {
            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

        protected override MySqlCommand Command(string query, MySqlConnection connection)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            return command;
        }

        protected override long AutoIncrement(MySqlConnection connection, MySqlCommand command)
        {
            return command.LastInsertedId;
        }

        public override int Upsert(string table, string[] columns, object[] values, string whereColumn,
            object whereValue,
            out long autoIncrement)
        {
            throw new NotImplementedException();
        }
    }
}
