using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamepage_interfaces;

namespace Gamepage_DAL
{
    public class GameSQLDAL : IGamecontainer
    {
        string ConnectionString = @"Server=mssqlstud.fhict.local;Database=dbi513890;User Id=dbi513890;Password=Miereneter22#;";  //de connection string naar de database

        public bool addGame(GameDTO g) //Deze methode doet voornamelijk de game toevoegen...maar het checked ook of de game al in de database staat
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM Game Where Name = @Name"; //vanaf hier checked hij of de game al in de database zit
                    using (SqlCommand checkcommand = new SqlCommand(checkQuery, connection))
                    {
                        checkcommand.Parameters.AddWithValue("@Name", g.Name);
                        int count = (int)checkcommand.ExecuteScalar();
                        if (count > 0)
                        {
                            return false;
                        }
                    }

                    string insertQuery = "INSERT INTO Game (Name) VALUES (@Name)"; //hier voegt die de game toe
                    using (SqlCommand addcommand = new SqlCommand(insertQuery, connection))
                    {
                        addcommand.Parameters.AddWithValue("@Name", g.Name);

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
                Console.WriteLine("Kon game niet toevoegen aan de algemene lijst.");
                return false;
            }

        }

        public bool updateGame(GameDTO g) //deze methode update de game voor nu alleen de game z'n naam waar het ID gegeven wordt
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string editQuery = "UPDATE Game SET Name=@Name WHERE Id=@Id";

                    using (SqlCommand command = new SqlCommand(editQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Name", g.Name);
                        command.Parameters.AddWithValue("@Id", g.ID);

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
                Console.WriteLine("Kan de game niet updaten.");
                return false;
            }

        }

        public GameDTO getByID(int id) //deze methode haalt een game uit de database door te kijken naar het ID hiervan
        {
            GameDTO g = new GameDTO();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string selectquery = "SELECT * FROM game WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(selectquery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                g.ID = (int)reader["Id"];
                                g.Name = (string)reader["Name"];
                            }
                        }
                    }
                    return g;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Kan game niet krijgen van dit id gaat er iets mis daarmee?");
                return g;
            }
        }

        public List<GameDTO> getGameList() //deze methode pakt alles van game en dat staat voor nu ingesteld voor ID's en Names
        {
            List<GameDTO> Returngames = new List<GameDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        connection.Open();

                        command.CommandText = "select * from Game";

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            GameDTO game = new GameDTO();
                            game.ID = (int)reader["ID"];
                            game.Name = (string)reader["Name"];

                            Returngames.Add(game);
                        }
                    }
                }
                
                return Returngames;
            }
            catch (Exception)
            {
                Console.WriteLine("Kan de game niet vinden ");
                return Returngames;
            }
        }

        public bool removeGame(GameDTO g) //Deze methode delete de game van de ID die is aangegeven 
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string deletequery = "DELETE FROM Game WHERE Id=@Id";

                    using (SqlCommand command = new SqlCommand(deletequery, connection))
                    {
                        command.Parameters.AddWithValue("@ID", g.ID);

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
                Console.WriteLine("Is niet gelukt om game te deleten staat die wel in de database?");
                return false;
            }
        }
    }
}
