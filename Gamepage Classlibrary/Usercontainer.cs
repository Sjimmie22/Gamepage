using Gamepage_interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamepage_Classlibrary
{
    public class Usercontainer
    {
        private IUsercontainer Icontainer;

        public Usercontainer(IUsercontainer icontainer)
        {
            this.Icontainer = icontainer;
        }

        public bool Register(User u)
        {
            if (Icontainer.Register(u.ToDto()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public User Login(User u) 
        {
            UserDTO dto = Icontainer.Login(u.ToDto());

            User user = new User()
            {
                ID= dto.Id,
                Email= dto.Email,
                Username= dto.Username,
                Password= dto.Password,
                IsAdmin= dto.IsAdmin
            };

            return user;
        }
    }
}
