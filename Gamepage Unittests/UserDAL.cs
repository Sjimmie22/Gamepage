using Gamepage_interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamepage_Unittests
{
    public class UserDAL : IUsercontainer
    {
        public UserDTO testregisterdto = new UserDTO();
        public UserDTO testlogindto = new UserDTO();

        public List<UserDTO> UserDTOlist = new()
        {
            new UserDTO()
            {
                Id= 1,
                Email = "Sjimmieemail22@hotmail.com",
                Username= "SjimmieTimmie",
                Password = "password",
                IsAdmin= false
            }
        };

        public bool Register(UserDTO User)
        {
            testregisterdto = User;

            for (int i = 0; i < UserDTOlist.Count; i++)
            {
                if (User.Email == UserDTOlist[i].Email)
                {
                    return false;
                }
            }

            UserDTOlist.Add(User);

            return true;
        }

        UserDTO IUsercontainer.Login(UserDTO User)
        {
            testlogindto= User;

            for (int i = 0; i < UserDTOlist.Count; i++)
            {
                if (User.Email == UserDTOlist[i].Email && User.Password == UserDTOlist[i].Password)
                {
                    User.Id = UserDTOlist[i].Id;
                    User.Username = UserDTOlist[i].Username;
                    User.IsAdmin= UserDTOlist[i].IsAdmin;
                    return User;
                }
            }
            return User;
        }
    }
}
