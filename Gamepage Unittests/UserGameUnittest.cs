using Gamepage_Classlibrary;
using Gamepage_interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Gamepage_Unittests
{
    [TestClass]
    public class UserGameUnittest
    {
        [TestMethod]
        public void Firstconstructortest()
        {
            // arrange & act
            UserGame usergame = new UserGame();

            // assert
            Assert.IsNotNull(usergame, "Game zou niet null moeten zijn.");
        }

        [TestMethod]
        public void Secondconstructortest()
        {
            //arrange
            string name = "kirby & the forgotten mirror";
            int gameid = 50;
            int userid = 239;
            int time = 50;
            int level = 20;
            string particularities = "nothing special";

            //Act
            UserGameDTO dto = new UserGameDTO()
            {
                Name = name,
                GameID = gameid,
                UserID = userid,
                Time = time,
                Level = level,
                Particularities = particularities
            };

            UserGame usergame = new UserGame(dto);

            // Assert
            Assert.IsNotNull(usergame, "Game zou niet null moeten zijn.");
            Assert.AreEqual(name, usergame.Name, "Namen matchen niet met elkaar");
            Assert.AreEqual(gameid, usergame.gameID, "gameid's matchen niet met elkaar");
            Assert.AreEqual(userid, usergame.userID, "userid's matchen niet met elkaar");
            Assert.AreEqual(time, usergame.Time, "tijden matchen niet met elkaar");
            Assert.AreEqual(level, usergame.Level, "levels matchen niet met elkaar");
            Assert.AreEqual(particularities, usergame.Particularities, "Particularities matchen niet met elkaar");
        }


        [TestMethod]
        public void addUserGame()
        {
            //arrange
            UserGameDAL DAL = new UserGameDAL();
            UserGameContainer UGcon = new UserGameContainer(DAL);

            int UserID = 255;
            int GameID = 156;
            int Time = 50015;
            int Level = 60;
            string Particularities = "veelste lang";

            //act
            UserGame userGame = new UserGame()
            {
                userID= UserID,
                gameID= GameID,
                Time= Time, 
                Level= Level,
                Particularities = Particularities
            };

            UGcon.addUserGame(userGame);

            //assert
            Assert.AreEqual(UserID, DAL.testaddusergame.UserID, "UserID komt niet overheen");
            Assert.AreEqual(GameID, DAL.testaddusergame.GameID, "GameID komt niet overheen");
            Assert.AreEqual(Time, DAL.testaddusergame.Time, "Time komt niet overheen");
            Assert.AreEqual(Level, DAL.testaddusergame.Level, "Level komt niet overheen");
            Assert.AreEqual(Particularities, DAL.testaddusergame.Particularities, "Particularities komen niet overheen");
        }

        [TestMethod]
        public void Getbyname()
        {
            //arrange
            UserGameDAL DAL = new UserGameDAL();
            UserGameContainer UGcon = new UserGameContainer(DAL);

            string name = "Genshin Impact";
            int gameid = 2;

            //act
            int checkid = UGcon.getByName(name);

            //assert
            Assert.AreEqual(name, DAL.testname, "Naam was niet goed dus ID klopt niet");
        }

        [TestMethod]
        public void Getbyuserid()
        {
            //arrange
            UserGameDAL DAL = new UserGameDAL();
            UserGameContainer UGcon = new UserGameContainer(DAL);

            int userid = 1;

            //act
            List<UserGame> usergames = UGcon.GetByUserID(userid);

            //assert
            Assert.AreEqual(userid, DAL.testid, "ID komt niet overheen gaat er iets mis in de businesslaag?");
        }

        [TestMethod]
        public void updateUserGame()
        {
            //arrange
            UserGameDAL DAL = new UserGameDAL();
            UserGameContainer UGcon = new UserGameContainer(DAL);

            int userID = 1;
            int gameID = 2;
            string name = "Genshin Impact";
            int level = 60;
            int time = 56700;
            string particularities = "new game!!!";

            //act
            UserGame usergame = new UserGame()
            {
                userID = userID,
                gameID = gameID,
                Name = name,
                Level = level,
                Time = time,
                Particularities = particularities
            };

            UGcon.editUserGame(usergame);

            //assert
            Assert.AreEqual(usergame.Level, DAL.testeditusergame.Level, "Levels komen niet overheen");
            Assert.AreEqual(time, DAL.testeditusergame.Time, "tijden komen niet overheen");
            Assert.AreEqual(particularities, DAL.testeditusergame.Particularities, "Particularities komen niet overheen");
        }

        [TestMethod]
        public void deleteUserGame()
        {
            //arrange
            UserGameDAL DAL = new UserGameDAL();
            UserGameContainer UGcon = new UserGameContainer(DAL);

            int userid = 1;
            int gameid = 2;

            //act
            UGcon.removeUserGame(userid, gameid);

            //assert
            Assert.AreEqual(userid, DAL.testuserid, "userid's kloppen niet met elkaar");
            Assert.AreEqual(gameid, DAL.testgameid, "gameid's kloppen niet met elkaar");

        }

        [TestMethod]
        public void ToDTO()
        {
            //arrange
            int gameid = 50;
            int userid = 239;
            int time = 50;
            int level = 20;
            string particularities = "nothing special";

            //act
            UserGame Usergame = new UserGame()
            {
                gameID= gameid,
                userID= userid,
                Time= time,
                Level= level,
                Particularities= particularities,
            };

            UserGameDTO dto = Usergame.ToDto();

            //assert
            Assert.IsNotNull(dto, "UserGameDTO mag niet null zijn.");
            Assert.AreEqual(gameid, dto.GameID, "UserGameDTO userid's matched niet.");
            Assert.AreEqual(userid, dto.UserID, "UserGameDTO gameid's matched niet.");
            Assert.AreEqual(time, dto.Time, "UserGameDTO tijden matched niet.");
            Assert.AreEqual(level, dto.Level, "UserGameDTO levels matched niet.");
            Assert.AreEqual(particularities, dto.Particularities, "UserGameDTO particularities matched niet.");
        }
    }
}
