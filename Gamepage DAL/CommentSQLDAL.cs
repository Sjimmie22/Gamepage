using Gamepage_interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamepage_DAL
{
    public class CommentSQLDAL : ICommentcontainer
    {
        string ConnectionString = @"Server=mssqlstud.fhict.local;Database=dbi513890;User Id=dbi513890;Password=Miereneter22#;";  //de connection string naar de database

        public List<CommentDTO> GetCommentList(int ClipID)
        {
            List<CommentDTO> comments = new List<CommentDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string selectquery = "SELECT co.*, u.UserName " +
                                 "FROM Comment co " +
                                 "INNER JOIN [User] u ON co.UserID = u.ID " +
                                 "WHERE co.ClipID = @ClipID";

                    using (SqlCommand command = new SqlCommand(selectquery, connection))
                    {
                        command.Parameters.AddWithValue("@ClipID", ClipID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CommentDTO comment = new CommentDTO();

                                comment.CommentID = (int)reader["CommentID"];
                                comment.ClipID= ClipID;
                                comment.UserID = (int)reader["UserID"];
                                comment.CommentText = (string)reader["Text"];
                                comment.Maker = (string)reader["Username"];

                                comments.Add(comment);
                            }
                        }
                    }
                    return comments;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Commentlijst kan niet opgehaald worden.");
                return comments;
            }
        }

        public bool AddComment(CommentDTO coDTO)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Comment (ClipID, UserID, Text) VALUES (@ClipID, @UserID, @Text)";
                    using (SqlCommand addcommand = new SqlCommand(insertQuery, connection))
                    {
                        addcommand.Parameters.AddWithValue("@ClipID", coDTO.ClipID);
                        addcommand.Parameters.AddWithValue("@UserID", coDTO.UserID);
                        addcommand.Parameters.AddWithValue("@Text", coDTO.CommentText);

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
                Console.WriteLine("lukte niet om een comment te adden hieraan.");
                return false;
            }
        }
    }
}
