using Gamepage_interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Gamepage_Classlibrary
{
    public class User
    {
        public int ID { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public User() 
        { 
        
        }

        public User(string email, string password)
        {
            Email = email;
            Password= password;
        }

        public User(string email, string username, string password, bool isadmin)
        {
            Email = email;
            Username = username;
            Password = password;
            IsAdmin = isadmin;
        }

        public User(UserDTO dto)
        {
            ID = dto.Id;
            Email = dto.Email;
            Username = dto.Username;
            Password = dto.Password;
        }

        public UserDTO ToDto() //zet game over naar GameDTO
        {
            return new UserDTO() { Id = ID, Email = Email, Username = Username ,Password = Password, IsAdmin = IsAdmin };
        }
    }
}
