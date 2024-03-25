using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamepage_interfaces;

namespace Gamepage_DAL
{
    public class UserSQLDAL: IUsercontainer
    {
        string ConnectionString = @"Server=mssqlstud.fhict.local;Database=dbi513890;User Id=dbi513890;Password=Miereneter22#;";

        public bool Register(UserDTO User)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM [User] Where Email = @Email";
                    using (SqlCommand checkcommand = new SqlCommand(checkQuery, connection))
                    {
                        checkcommand.Parameters.AddWithValue("@Email", User.Email);
                        int count = (int)checkcommand.ExecuteScalar();
                        if (count > 0)
                        {
                            return false;
                        }
                    }

                    string insertQuery = "INSERT INTO [User] (Email, Username, Password, Admin) VALUES (@Email, @Username, @Password, @Admin)";
                    using (SqlCommand insertcommand = new SqlCommand(insertQuery, connection))
                    {
                        insertcommand.Parameters.AddWithValue("@Email", User.Email);
                        insertcommand.Parameters.AddWithValue("@Username", User.Username);
                        insertcommand.Parameters.AddWithValue("@Password", User.Password);
                        insertcommand.Parameters.AddWithValue("@Admin", User.IsAdmin);

                        int Rowsaffected = insertcommand.ExecuteNonQuery();

                        if (Rowsaffected > 0)
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
                Console.WriteLine("Kan de user niet registeren gaat iets mis met de database");
                return false;
            }
        }

        public UserDTO Login(UserDTO User)
        {
            UserDTO userdto = new UserDTO();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {

                    connection.Open();

                    string Selectquery = "SELECT * FROM [User] WHERE Email = @Email And Password = @Password";

                    using (SqlCommand Checkcommand = new SqlCommand(Selectquery, connection))
                    {
                        Checkcommand.Parameters.AddWithValue("@Email", User.Email);
                        Checkcommand.Parameters.AddWithValue("@Password", User.Password);

                        using (SqlDataReader Reader = Checkcommand.ExecuteReader())
                        {
                            if (Reader.HasRows)
                            {
                                while (Reader.Read() == true)
                                {
                                    userdto.Id = Reader.GetInt32(0);
                                    userdto.Email = Reader.GetString(1);
                                    userdto.Username = Reader.GetString(2);
                                    userdto.Password = Reader.GetString(3);
                                    userdto.IsAdmin = Reader.GetBoolean(4);
                                }
                                return userdto;
                            }

                        }
                    }
                }
                return new UserDTO();
            }
            catch (Exception)
            {
                Console.WriteLine("Login gaat fout probeer het later nog eens");
                return new UserDTO();
            }


        }

    }
}
