using Gamepage_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamepage_interfaces;
using System.ComponentModel.DataAnnotations;

namespace Gamepage_Classlibrary
{
    public class Game
    {
        public int ID { get; set; }

        public string Name { get; set; }
        

        public Game()
        {

        }

        public Game(string name)
        {
            Name = name;
        }

        public Game(GameDTO dto)
        {
               Name= dto.Name;
               ID = dto.ID;
        }

        public GameDTO ToDto() //zet game over naar GameDTO
        {
            return new GameDTO() {Name = Name, ID = ID};
        }
    }
}
