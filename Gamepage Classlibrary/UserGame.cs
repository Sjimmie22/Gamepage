using Gamepage_interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamepage_Classlibrary
{
    public class UserGame
    {
        public int gameID { get; set; }

        public int userID { get; set; }

        public string Name { get; set; }

        public int Time { get; set; }

        public int Level { get; set; }

        public string Particularities { get; set; }

        public UserGame() 
        {
        
        }

        public UserGame(UserGameDTO dto)
        {
            Name = dto.Name;
            gameID = dto.GameID;
            userID = dto.UserID;
            Time = dto.Time;
            Level = dto.Level;
            Particularities= dto.Particularities;
        }

        public UserGameDTO ToDto() //zet game over naar GameDTO
        {
            return new UserGameDTO() { GameID = gameID, UserID = userID, Time = Time, Level = Level, Particularities = Particularities };
        }
    }
}
