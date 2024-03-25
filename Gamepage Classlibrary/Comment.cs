using Gamepage_interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamepage_Classlibrary
{
    public class Comment
    {
        public int CommentID { get; set; }

        public int ClipID { get; set; }

        public int UserID { get; set; }

        public string CommentText { get; set; }

        public string Maker { get; set; }

        public Comment() 
        { 
            
        }

        public Comment(CommentDTO dto)
        {
            CommentID = dto.CommentID;
            UserID= dto.UserID;
            ClipID = dto.ClipID;
            CommentText = dto.CommentText;
            Maker = dto.Maker;
        }

        public CommentDTO toDTO() //Zet Clip over naar CommentDTO
        {
            return new CommentDTO() {CommentID = CommentID, ClipID = ClipID, UserID = UserID, CommentText = CommentText, Maker = Maker};
        }
    }
}
