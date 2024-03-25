using Gamepage_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Gamepage_interfaces;

namespace Gamepage_Classlibrary
{
    public class Clip
    {
        public string Title { get; set; }
        public int ClipID { get; set; }
        public int UserID { get; set; }
        public string Maker { get; set; }
        public int GameID { get; set; }
        public string ClipText { get; set; }

        public Clip() 
        {
        
        }

        public Clip(ClipDTO dto)
        {
            ClipID= dto.ClipID;
            UserID= dto.UserID;
            Maker = dto.Maker;
            GameID= dto.GameID;
            Title = dto.Title;
            ClipText = dto.Cliptext;
        }

        public ClipDTO toDTO() //Zet Clip over naar CLipDTO
        {
            return new ClipDTO() {ClipID = ClipID, UserID = UserID, Maker = Maker, GameID = GameID, Title = Title, Cliptext = ClipText};
        }

    }
}
