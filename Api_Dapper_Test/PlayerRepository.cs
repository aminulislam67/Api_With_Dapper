using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;



namespace Api_Dapper_Test
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly string _connectionString;

        public PlayerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Player> AddPlayer(string playerName)
        {
            using IDbConnection dbConnection = new SqlConnection(_connectionString);
            try
            {
                //dbConnection.Open();
                //string selectSql = "SELECT * FROM Player WHERE Name = @Name;";
                //List<Player> matchingPlayers = dbConnection.Query<Player>(selectSql, new { Name = playerName }).AsList();
                dbConnection.Open();
                string selectSql = "SELECT * FROM Player;"; // Adjust the table name to "Players"
                List<Player> allPlayers = dbConnection.Query<Player>(selectSql).AsList();


                return allPlayers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}