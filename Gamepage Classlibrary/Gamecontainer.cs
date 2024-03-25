using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamepage_DAL;
using Gamepage_interfaces;

namespace Gamepage_Classlibrary
{
    public class Gamecontainer
    {
        private IGamecontainer icontainer;

        public Gamecontainer(IGamecontainer icontainer)
        {
            this.icontainer = icontainer;
        }

        public bool AddGame(Game g) //deze methode roept de methode aan van GameDAL
        {
            if(icontainer.addGame(g.ToDto()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool updategame(Game g)
        {
            if (icontainer.updateGame(g.ToDto()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Game getById(int id)
        {
            Game gameSendBack = new(icontainer.getByID(id));
            return gameSendBack;
        }


        public List<Game> getGameList() //deze methode haalt de lijst van het DAL zodat die in de form te zien is
        {
            List<Game> list = new List<Game>();
            foreach (GameDTO dto in icontainer.getGameList()) 
            {
                list.Add(new Game(dto));
            }

            return list;
        }

        public bool removeGame(Game g) 
        {
            if (icontainer.removeGame(g.ToDto()))
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
