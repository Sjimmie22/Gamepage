using Gamepage_interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamepage_DAL
{
    public class ClipSQLDAL : IClipcontainer
    {
        string ConnectionString = @"Server=mssqlstud.fhict.local;Database=dbi513890;User Id=dbi513890;Password=Miereneter22#;";

        public List<ClipDTO> getBygameID(int Gameid)
        {
            List<ClipDTO> clips = new List<ClipDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string selectquery = "SELECT c.*, u.UserName " +
                                 "FROM Clip c " +
                                 "INNER JOIN [User] u ON c.UserID = u.ID " +
                                 "WHERE c.GameID = @GameID";

                    using (SqlCommand command = new SqlCommand(selectquery, connection))
                    {
                        command.Parameters.AddWithValue("@GameID", Gameid);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClipDTO clip = new ClipDTO();

                                clip.ClipID = (int)reader["ClipID"];
                                clip.GameID = (int)reader["GameID"];
                                clip.UserID = (int)reader["UserID"];
                                clip.Title = (string)reader["Title"];
                                clip.Maker = (string)reader["Username"];
                                clip.Cliptext = (string)reader["Cliptext"];

                                clips.Add(clip);
                            }
                        }
                    }
                    return clips;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("kon clip niet krijgen bij ID");
                return clips;
            }

        }

        public bool AddClip(ClipDTO cDto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Clip (GameID, UserID, Title, Cliptext) VALUES (@GameID, @UserID, @Title, @Cliptext)";
                    using (SqlCommand addcommand = new SqlCommand(insertQuery, connection))
                    {
                        addcommand.Parameters.AddWithValue("@GameID", cDto.GameID);
                        addcommand.Parameters.AddWithValue("@UserID", cDto.UserID);
                        addcommand.Parameters.AddWithValue("@Title", cDto.Title);
                        addcommand.Parameters.AddWithValue("@Cliptext", cDto.Cliptext);

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
                Console.WriteLine("Kon Clip niet adden misschien ieets fout aan de data of de connectie?");
                return false;
            }

        }

    }
}
