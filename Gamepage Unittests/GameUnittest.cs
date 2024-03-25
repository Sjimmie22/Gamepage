using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gamepage_Classlibrary;
using Gamepage_DAL;
using System.Xml.Linq;
using Gamepage_interfaces;

namespace Gamepage_Unittests
{
    [TestClass]
    public class GameUnittest
    {
        [TestMethod]
        public void Firstconstructortest()
        {
            // arrange & act
            Game game = new Game();

            // assert
            Assert.IsNotNull(game, "Game zou niet null moeten zijn.");
        }

        [TestMethod] 
        public void Secondconstructortest() 
        {
            //arrange
            string name = "kirby & the forgotten mirror";

            //Act
            Game game = new Game(name);

            // Assert
            Assert.IsNotNull(game, "Game zou niet null moeten zijn.");
            Assert.AreEqual(name, game.Name, "Namen matchen niet met elkaar");
        }

        [TestMethod]
        public void Thirdconstructortest()
        {

            //arrange
            int Id = 5;
            string name = "Honkai Impact";

            //act
            GameDTO dto = new GameDTO()
            {
                ID= Id,
                Name= name
            };

            Game game = new Game(dto);

            //assert
            Assert.IsNotNull(game, "Game zou niet null moeten zijn.");
            Assert.AreEqual(Id, game.ID, "Id's matchen niet met elkaar");
            Assert.AreEqual(name, game.Name, "Namen matchen niet met elkaar");
        }

        [TestMethod]
        public void Addgame()
        {
            //arrange
            GameDAL DAL = new GameDAL();
            Gamecontainer gcon = new Gamecontainer(DAL);

            string name = "GTA V";

            //act
            Game game = new Game(name);
            gcon.AddGame(game);

            //assert
            Assert.AreEqual(name, DAL.testaddgame.Name, "Game toevoegen mislukt door naam");
        }

        [TestMethod]
        public void UpdateGame()
        {
            //arrange
            GameDAL DAL = new GameDAL();
            Gamecontainer gcon = new Gamecontainer(DAL);

            int Id = 5;
            string name = "Honkai Impact";

            //act
            Game game = new Game()
            {
                ID = Id, 
                Name = name 
            };

            gcon.updategame(game);

            //assert
            Assert.AreEqual(Id, DAL.testupdategame.ID, "updaten ging fout door het ID");
            Assert.AreEqual(name, DAL.testupdategame.Name, "Updaten ging fout door de naam");
        }

        [TestMethod]
        public void Removegame()
        {
            //arrangge
            GameDAL DAL = new GameDAL();
            Gamecontainer gcon = new Gamecontainer(DAL);

            int iD = 5;
            string name = "Genshin Impact";

            //act
            Game game = new Game()
            {
                ID = iD,
                Name = name
            };

            gcon.removeGame(game);

            //assert
            Assert.AreEqual(iD, DAL.testremovegame.ID, "ID is niet hetzelde dus kan niet verwijderd worden");
            Assert.AreEqual(name, DAL.testremovegame.Name, "Name is niet hetzelfde dus kan niet verwijderd worden");
            //CollectionAssert.DoesNotContain(DAL.gamesDTOlist, game, "je game zit er nog in");
        }

        [TestMethod]
        public void Getgamelist()
        {
            //arrange
            GameDAL DAL = new GameDAL();
            Gamecontainer gcon = new Gamecontainer(DAL);

            //act
            List<Game> games = gcon.getGameList();

            //assert
            Assert.AreEqual(DAL.gamesDTOlist.Count, games.Count, "het nummer wat er in de lijst zit is anders.");

            for (int i = 0; i < DAL.gamesDTOlist.Count; i++)
            {
                Assert.AreEqual(DAL.gamesDTOlist[i].ID, games[i].ID, $"Game in de lijst op plek {i} heeft een ander ID.");
                Assert.AreEqual(DAL.gamesDTOlist[i].Name, games[i].Name, $"Game in de lisjt op plek {i} heeft een andere Name.");
            }
        }

        [TestMethod]
        public void GetbyID()
        {
            //arrange
            GameDAL DAL = new GameDAL();
            Gamecontainer gcon = new Gamecontainer(DAL);

            int Id = 5;

            //act
            Game game = gcon.getById(Id);

            //assert
            Assert.AreEqual(Id, DAL.testid, "Het ID is niet binnengekomen");
        }

        [TestMethod]
        public void ToDTO() 
        {
            //arrange

            int Id = 5;
            string name = "Honkai Impact";

            //act
            Game game = new Game() 
            { 
                ID= Id,
                Name = name
            };

            GameDTO dto = game.ToDto();

            //assert
            Assert.IsNotNull(dto, "GameDTO mag niet null zijnn.");
            Assert.AreEqual(Id, dto.ID, "GameDTO ID matched niet.");
            Assert.AreEqual(name, dto.Name, "GameDTO name matched niet.");
        }
    }
}
