using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamepage_interfaces
{
    public interface ICommentcontainer
    {
        public bool AddComment(CommentDTO coDTO);

        public List<CommentDTO> GetCommentList(int ClipID);
    }
}
