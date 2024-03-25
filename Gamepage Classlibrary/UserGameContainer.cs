using Gamepage_interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Gamepage_Classlibrary
{
    public class UserGameContainer
    {
        private iUserGamecontainer icontainer;

        public UserGameContainer(iUserGamecontainer icontainer)
        {
            this.icontainer = icontainer;
        }

        public int getByName(string name)
        {
            int gameid;

            gameid = icontainer.getByName(name);

            return gameid;
        }

        public List<UserGame> GetByUserID(int userid)
        {
            List<UserGame> list = new List<UserGame>();
            foreach (UserGameDTO dto in icontainer.GetByUserID(userid))
            {
                list.Add(new UserGame(dto));
            }

            return list;
        }

        public bool addUserGame(UserGame g)
        {
            if (icontainer.addUserGame(g.ToDto()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool editUserGame(UserGame g)
        {
            if (icontainer.updateUserGame(g.ToDto()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool removeUserGame(int userid, int gameid)
        {
            if (icontainer.removeUserGame(userid, gameid))
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
