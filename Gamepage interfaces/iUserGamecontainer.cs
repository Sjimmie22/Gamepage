using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamepage_interfaces
{
    public interface iUserGamecontainer
    {
        public List<UserGameDTO> GetByUserID(int userid);

        public int getByName(string name);

        public bool addUserGame(UserGameDTO g);

        public bool updateUserGame(UserGameDTO g);

        public bool removeUserGame(int userid, int gameid);
    }
}
