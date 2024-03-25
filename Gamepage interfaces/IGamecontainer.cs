using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamepage_interfaces
{
    public interface IGamecontainer
    {
        public bool addGame(GameDTO g);

        public bool updateGame (GameDTO g);

        public bool removeGame(GameDTO g);

        public List<GameDTO> getGameList();

        public GameDTO getByID(int id);
    }
}
