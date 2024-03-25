using Gamepage_Classlibrary;
using Gamepage_DAL;
using Gamepage_interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamepage_Unittests
{
    [TestClass]
    public class CommentUnittest
    {
        [TestMethod]
        public void Firstconstructortest()
        {
            // arrange & act
            Comment comment = new Comment();

            // assert
            Assert.IsNotNull(comment, "Comment zou niet null moeten zijn.");
        }

        [TestMethod]
        public void Secondconstructortest()
        {
            // arrange
            CommentDTO commentDTO = new CommentDTO()
            {
                ClipID = 1,
                CommentID = 1,
                UserID = 1,
                CommentText = "buhbuh",
                Maker = "ik"
            };

            //act
            Comment comment = new Comment(commentDTO);

            // assert
            Assert.IsNotNull(comment, "Comment zou niet null moeten zijn.");

            Assert.AreEqual(commentDTO.CommentID, comment.CommentID, "CommentID's kloppen niet.");
            Assert.AreEqual(commentDTO.ClipID, comment.ClipID, "ClipID's kloppen niet.");
            Assert.AreEqual(commentDTO.UserID, comment.UserID, "UserID's kloppen niet.");
            Assert.AreEqual(commentDTO.CommentText, comment.CommentText, "Commenttexts matchen niet.");
            Assert.AreEqual(commentDTO.Maker, comment.Maker, "ClipID's kloppen niet.");
        }

        [TestMethod]
        public void addComment()
        {
            //arrange
            CommentDAL DAL = new CommentDAL();
            Commentcontainer cocon = new Commentcontainer(DAL);
            
            Comment comment = new Comment()
            {
                CommentID = 15,
                ClipID = 2,
                UserID = 3,
                CommentText = "test",
            };

            //act
            cocon.addComment(comment);

            //assert
            Assert.AreEqual(comment.CommentID, DAL.testaddcomment.CommentID, "Commentid's komen niet overheen met elkaar...");
            Assert.AreEqual(comment.ClipID, DAL.testaddcomment.ClipID, "Clipid's komen niet overheen met elkaar...");
            Assert.AreEqual(comment.UserID, DAL.testaddcomment.UserID, "Userid's komen niet overheen met elkaar...");
            Assert.AreEqual(comment.CommentText, DAL.testaddcomment.CommentText, "Commenttexts komen niet overheen met elkaar..."); 
        }

        [TestMethod]
        public void getcommentlist()
        {
            //arrange
            CommentDAL DAL = new CommentDAL();
            Commentcontainer cocon = new Commentcontainer(DAL);

            int clipid = 5;

            //act
            List<Comment> comments = cocon.getCommentList(clipid);

            //arrange
            Assert.AreEqual(DAL.CommentDTOlist.Count, comments.Count, "het nummer wat er in de lijst zit is anders.");

            for (int i = 0; i < DAL.CommentDTOlist.Count; i++)
            {
                Assert.AreEqual(comments[i].CommentID, DAL.CommentDTOlist[i].CommentID, $"Comment in de lijst op plek {i} heeft een ander commentID.");
                Assert.AreEqual(comments[i].UserID, DAL.CommentDTOlist[i].UserID, $"Comment in de lijst op plek {i} heeft een ander userID.");
                Assert.AreEqual(comments[i].ClipID, DAL.CommentDTOlist[i].ClipID, $"Comment in de lijst op plek {i} heeft een ander clipID.");
                Assert.AreEqual(comments[i].CommentText, DAL.CommentDTOlist[i].CommentText, $"Comment in de lijst op plek {i} heeft een andere commenttext.");
            }

        }

        [TestMethod]
        public void ToDTO()
        {
            //arrange
            int Commentid = 1;
            int UserID = 2;
            int ClipID = 3;
            string Commenttext = "hello";
            string Maker = "baba";


            //act
            Comment comment = new Comment()
            {
                CommentID= Commentid,
                UserID= UserID,
                ClipID= ClipID,
                CommentText= Commenttext,
                Maker= Maker
            };

            CommentDTO commentdto = comment.toDTO();

            //assert
            Assert.AreEqual(comment.CommentID, commentdto.CommentID, "Commentid's matchen niet");
            Assert.AreEqual(comment.ClipID, commentdto.ClipID, "Clipid's matchen niet");
            Assert.AreEqual(comment.UserID, commentdto.UserID, "userid's matchen niet");
            Assert.AreEqual(comment.CommentText, commentdto.CommentText, "Commenttexts matchen niet");
            Assert.AreEqual(comment.Maker, commentdto.Maker, "Makers matchen niet");
        }
    }
}
