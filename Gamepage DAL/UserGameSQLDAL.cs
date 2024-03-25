using Gamepage_interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamepage_DAL
{
    public class UserGameSQLDAL : iUserGamecontainer
    {
        string ConnectionString = @"Server=mssqlstud.fhict.local;Database=dbi513890;User Id=dbi513890;Password=Miereneter22#;";  //de connection string naar de database

        public int getByName(string name)
        {
            int gameid = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string selectquery = "SELECT * FROM game WHERE Name = @Name";

                    using (SqlCommand command = new SqlCommand(selectquery, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                gameid = (int)reader["Id"];
                            }
                        }
                    }
                    return gameid;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Lukt niet om met deze naam een id uit te halen.");
                return gameid;
            }
        }

        public List<UserGameDTO> GetByUserID(int userid)
        {
            List<UserGameDTO> games = new List<UserGameDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string selectquery = "SELECT GameID, Game.[Name], [Time], Levels, Particularities " +
                        "FROM UserGame " +
                        "JOIN Game on Game.ID = UserGame.GameID " +
                        "WHERE UserGame.UserID = @Id";

                    using (SqlCommand command = new SqlCommand(selectquery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", userid);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserGameDTO game = new UserGameDTO();
                                game.GameID = (int)reader["GameID"];
                                game.Name = (string)reader["Name"];
                                game.Time = (int)reader["Time"];
                                game.Level = (int)reader["Levels"];
                                game.Particularities = (string)reader["Particularities"];

                                games.Add(game);
                            }
                        }
                    }
                }
                return games;
            }
            catch (Exception)
            {
                Console.WriteLine("Het is niet gelukt om met dit ID games op te kunnen halen.");
                return games;
            }
        }

        public bool addUserGame(UserGameDTO g)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM UserGame Where GameID = @GameID AND UserID = @UserID"; //vanaf hier checked hij of de game al in de database zit
                    using (SqlCommand checkcommand = new SqlCommand(checkQuery, connection))
                    {
                        checkcommand.Parameters.AddWithValue("@GameID", g.GameID);
                        checkcommand.Parameters.AddWithValue("@UserID", g.UserID);
                        int count = (int)checkcommand.ExecuteScalar();
                        if (count > 0)
                        {
                            return false;
                        }
                    }

                    string insertQuery = "INSERT INTO UserGame (GameID, UserID, Time, Levels, Particularities) VALUES (@GameID, @UserID, @Time, @Levels, @Particularities)"; //hier voegt die de game toe
                    using (SqlCommand addcommand = new SqlCommand(insertQuery, connection))
                    {
                        addcommand.Parameters.AddWithValue("@GameID", g.GameID);
                        addcommand.Parameters.AddWithValue("@UserID", g.UserID);
                        addcommand.Parameters.AddWithValue("@Time", g.Time);
                        addcommand.Parameters.AddWithValue("@Levels", g.Level);
                        addcommand.Parameters.AddWithValue("@Particularities", g.Particularities);

                        int rowsAffected = addcommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Er is een fout opgetreden om de game te kunnen adden aan de lijst ");
                return false;
            }

        }

        public bool updateUserGame(UserGameDTO g) //deze methode update de game voor nu alleen de game z'n naam waar het ID gegeven wordt
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string editQuery = "UPDATE UserGame SET Time=@Time, Levels=@Levels, Particularities=@Particularities WHERE GameID=@GameID AND UserID=@UserID";
                    using (SqlCommand command = new SqlCommand(editQuery, connection))
                    {
                        command.Parameters.AddWithValue("@GameID", g.GameID);
                        command.Parameters.AddWithValue("@UserID", g.UserID);

                        command.Parameters.AddWithValue("@Time", g.Time);
                        command.Parameters.AddWithValue("@Levels", g.Level);
                        command.Parameters.AddWithValue("@Particularities", g.Particularities);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Kan de usergame niet updaten.");
                return false;
            }
        }

        public bool removeUserGame(int userid, int gameid)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string deletequery = "DELETE FROM UserGame WHERE GameID=@GameID AND UserID=@UserID";

                    using (SqlCommand command = new SqlCommand(deletequery, connection))
                    {
                        command.Parameters.AddWithValue("@GameID", gameid);
                        command.Parameters.AddWithValue("@UserID", userid);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Is niet gelukt om UserGame te deleten staat die wel in de database?");
                return false;
            }
        }
    }
}
