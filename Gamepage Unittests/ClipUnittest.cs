using Gamepage_Classlibrary;
using Gamepage_interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamepage_Unittests
{
    [TestClass]
    public class ClipUnittest
    {
        [TestMethod]
        public void Firstconstructortest()
        {
            // arrange & act
            Clip clip = new Clip();

            // assert
            Assert.IsNotNull(clip, "Clip zou niet null moeten zijn.");
        }

        [TestMethod]
        public void Secondconstructortest()
        {
            // arrange
            ClipDTO clipDTO = new ClipDTO()
            {
                ClipID = 1,
                GameID = 2,
                UserID = 3,
                Maker = "baba",
                Title = "hello",
                Cliptext = "hello"
            };

            //act
            Clip clip = new Clip(clipDTO);

            // assert
            Assert.IsNotNull(clip, "Clip zou niet null moeten zijn.");

            Assert.AreEqual(clipDTO.ClipID, clip.ClipID, "ClipID's kloppen niet.");
            Assert.AreEqual(clipDTO.GameID, clip.GameID, "GameID's kloppen niet.");
            Assert.AreEqual(clipDTO.UserID, clip.UserID, "UserID's kloppen niet.");
            Assert.AreEqual(clipDTO.Maker, clip.Maker, "Maker's matchen niet");
            Assert.AreEqual(clipDTO.Title, clip.Title, "Title's matchen niet");
            Assert.AreEqual(clipDTO.Cliptext, clip.ClipText, "Cliptext's matchen niet.");
        }

        [TestMethod]
        public void AddClip()
        {
            //arrange
            ClipDAL DAL = new ClipDAL();
            Clipcontainer ccon = new Clipcontainer(DAL);

            Clip clip = new Clip()
            {
                ClipID = 1,
                GameID = 2,
                UserID = 3,
                Maker = "baba",
                Title = "hello",
                ClipText = "hello"
            };

            //act
            ccon.AddClip(clip);

            //assert
            Assert.AreEqual(clip.ClipID, DAL.testaddclip.ClipID, "ClipID's kloppen niet.");
            Assert.AreEqual(clip.GameID, DAL.testaddclip.GameID, "GameID's kloppen niet.");
            Assert.AreEqual(clip.UserID, DAL.testaddclip.UserID, "UserID's kloppen niet.");
            Assert.AreEqual(clip.Maker, DAL.testaddclip.Maker, "Maker's matchen niet");
            Assert.AreEqual(clip.Title, DAL.testaddclip.Title, "Title's matchen niet");
            Assert.AreEqual(clip.ClipText, DAL.testaddclip.Cliptext, "Cliptext's matchen niet.");
        }

        [TestMethod]
        public void GetbyGameID()
        {
            //arrange
            ClipDAL DAL = new ClipDAL();
            Clipcontainer ccon = new Clipcontainer(DAL);

            int gameid = 1;

            //act
            ccon.GetClipList(gameid);

            //assert
            Assert.AreEqual(gameid, DAL.testgameid, "id's matchen niet en kan daardoor niet de");
        }

        [TestMethod]
        public void ToDTO()
        {
            //arrange
            int Clipid = 1;
            int Gameid = 2;
            int UserID = 3;
            string Maker = "baba";
            string Title = "hello";
            string Cliptext = "hello";

            //act
            Clip clip = new Clip()
            {
                ClipID= Clipid,
                GameID= Gameid,
                UserID= UserID,
                Maker = Maker,
                Title= Title,
                ClipText= Cliptext
            };

            ClipDTO clipdto = clip.toDTO();

            //assert
            Assert.AreEqual(clip.ClipID, clipdto.ClipID, "Clipid's matchen niet");
            Assert.AreEqual(clip.GameID, clipdto.GameID, "Gameid's matchen niet");
            Assert.AreEqual(clip.UserID, clipdto.UserID, "Userid's matchen niet");
            Assert.AreEqual(clip.Maker, clipdto.Maker, "Makers matchen niet");
            Assert.AreEqual(clip.Title, clipdto.Title, "Titles matchen niet");
            Assert.AreEqual(clip.ClipText, clipdto.Cliptext, "Cliptexts matchen niet");
        }
    }
}
