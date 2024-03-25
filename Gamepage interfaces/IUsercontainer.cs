using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamepage_interfaces
{
    public interface IUsercontainer
    {
        public bool Register(UserDTO User);
        
        public UserDTO Login(UserDTO User);
    }
}
