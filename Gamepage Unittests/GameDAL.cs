using Gamepage_interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamepage_Unittests
{
    public class GameDAL : IGamecontainer
    {
        public GameDTO testaddgame = new GameDTO();
        public GameDTO testupdategame = new GameDTO();
        public GameDTO testremovegame = new GameDTO();
        public int testid = 0;

        public List<GameDTO> gamesDTOlist = new List<GameDTO>()
        {
            new GameDTO()
            {
                ID= 5,
                Name= "Genshin Impact"
            }
        };

        public bool addGame(GameDTO gDto) //voegt een game toe aan de lijst die hierin zit (er wordt gechecked of de naam niet leeg is en de methode of de game er al in zit wordt hier ook opgeroepen)
        {
            testaddgame = gDto;

            if (gDto.Name == null || gDto.Name == string.Empty)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < gamesDTOlist.Count; i++)
                {
                    if (gDto.Name == gamesDTOlist[i].Name)
                    {
                        return false;
                    }
                }

                gDto.ID = gamesDTOlist.Count;
                gamesDTOlist.Add(gDto);

                return true;
            }
        }

        public bool updateGame(GameDTO g)
        {
            testupdategame= g;

            int index = gamesDTOlist.FindIndex(u => u.ID == g.ID);

            if (index > -1)
            {
                gamesDTOlist[index] = g;

                return true;
            }
            else
            {
                return false;
            }
        }

        public List<GameDTO> getGameList() //returned de lijst die hierin staat
        {
            return gamesDTOlist;
        }

        public bool removeGame(GameDTO g)
        {
            testremovegame= g;

            gamesDTOlist.Remove(g);

            return true;
        }

        public GameDTO getByID(int id)
        {
            testid= id;

            return gamesDTOlist.FirstOrDefault(game => game.ID == id);
        }

    }
}
