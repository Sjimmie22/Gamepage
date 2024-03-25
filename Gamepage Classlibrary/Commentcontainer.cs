using Gamepage_DAL;
using Gamepage_interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamepage_Classlibrary
{
    public class Commentcontainer
    {
        private ICommentcontainer icontainer;

        public Commentcontainer(ICommentcontainer icontainer)
        {
            this.icontainer = icontainer;
        }

        public bool addComment(Comment Co)
        {
            if (icontainer.AddComment(Co.toDTO()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Comment> getCommentList(int ClipID) //deze methode haalt de lijst van het DAL zodat die in de form te zien is
        {
            List<Comment> list = new List<Comment>();

            foreach (CommentDTO dto in icontainer.GetCommentList(ClipID))
            {
                    list.Add(new Comment(dto));
            }

            return list;
        }
    }
}
