using Gamepage_interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamepage_DAL
{
    public class CommentDAL : ICommentcontainer
    {
        public List<CommentDTO> CommentDTOlist = new List<CommentDTO>()
        {
            new CommentDTO()
            {
                CommentID= 55,
                ClipID= 5,
                UserID= 1,
                CommentText = "new Clip!"
            }
        };

        public CommentDTO testaddcomment = new CommentDTO();


        public bool AddComment(CommentDTO coDTO)
        {
            testaddcomment = coDTO;

            bool check = true;

            if (coDTO.CommentText == null || coDTO.CommentText == string.Empty)
            {
                check = false;
            }
            else
            {
                CommentDTOlist.Add(coDTO);
            }
            return check;
        }

        public List<CommentDTO> GetCommentList(int ClipID)
        {
            return CommentDTOlist.FindAll(dto=>dto.ClipID == ClipID);
        }
    }
}
