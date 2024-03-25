using Gamepage_interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamepage_Unittests
{
    public class UserGameDAL : iUserGamecontainer
    {
        public UserGameDTO testaddusergame = new UserGameDTO();
        public UserGameDTO testeditusergame = new UserGameDTO();
        public string testname;
        public int testid = 0;

        public int testuserid = 0;
        public int testgameid = 0;

        public List<UserGameDTO> usergamesDTOlist = new List<UserGameDTO>()
        {
            new UserGameDTO()
            {
                UserID = 1,
                GameID = 2,
                Name= "Genshin Impact",
                Level= 55,
                Time = 5500,
                Particularities = "new game"
            },

            new UserGameDTO()
            {
                UserID = 1,
                GameID = 3,
                Name = "Honkai Impact",
                Level = 80,
                Time= 2000,
                Particularities = "old game"
            }
        };

        public bool addUserGame(UserGameDTO g)
        {
            testaddusergame = g;

            if (usergamesDTOlist.Any(game => game.GameID == g.GameID))
            {
                return false;
            }

            usergamesDTOlist.Add(g);
            return true;
        }

        public int getByName(string name)
        {
            testname = name;

            UserGameDTO game = usergamesDTOlist.FirstOrDefault(g => g.Name == name);

            if (game.GameID > -1)
            {
                return game.GameID;
            }
            else
            {
                return -1;
            }
        }

        public List<UserGameDTO> GetByUserID(int userid)
        {
            testid= userid;

            List<UserGameDTO> games = usergamesDTOlist.Where(game => game.UserID == userid).ToList();
            return games;
        }

        public bool updateUserGame(UserGameDTO g)
        {
            testeditusergame = g;

            int index = usergamesDTOlist.FindIndex(dto => dto.GameID == g.GameID && dto.UserID == g.UserID);

            if (index != -1)
            {
                UserGameDTO updatedDTO = new UserGameDTO
                {
                    GameID = g.GameID,
                    UserID = g.UserID,
                    Time = g.Time,
                    Level = g.Level,
                    Particularities = g.Particularities
                };

                usergamesDTOlist[index] = updatedDTO;

                return true;
            }

            return false;
        }

        public bool removeUserGame(int userid, int gameid)
        {
            testuserid = userid;
            testgameid = gameid;

            int removedCount = usergamesDTOlist.RemoveAll(dto => dto.UserID == userid && dto.GameID == gameid);

            return removedCount > 0;
        }
    }
}