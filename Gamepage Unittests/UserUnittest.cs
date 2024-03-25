using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamepage_Classlibrary;
using Gamepage_DAL;
using Gamepage_interfaces;

namespace Gamepage_Unittests
{
    [TestClass]
    public class UserUnittest
    {
        [TestMethod]
        public void Testfirstconstructor()
        {
            //arrange
            UserDAL DAL = new UserDAL();
            Usercontainer Ucon = new Usercontainer(DAL);

            string email = "SjimmieTimmiehotmail.com";
            string password = "password";

            //act
            User user = new User(email, password);

            //assert
            Assert.IsNotNull(user, "User niet aangemaakt");
            Assert.AreEqual(email, user.Email, "Constructor met 2 variablen niet aangemaakt door Email");
            Assert.AreEqual(password, user.Password, "Constructor met 2 variablen niet aangemaakt door Password");
        }

        [TestMethod]
        public void Testsecondconstructor()
        {
            //arrange
            UserDAL DAL = new UserDAL();
            Usercontainer Ucon = new Usercontainer(DAL);

            string email = "SjimmieTimmiehotmail.com";
            string username = "SjimmieTimmie";
            string password = "password";
            bool isadmin = false;

            //act
            User user = new User(email, username, password, isadmin);

            //assert
            Assert.IsNotNull(user, "User niet aangemaakt");
            Assert.AreEqual(email, user.Email, "Constructor met 4 variablen niet aangemaakt door Email");
            Assert.AreEqual(username, user.Username, "Constructor met 4 variablen niet aangemaakt door Username");
            Assert.AreEqual(password, user.Password, "Constructor met 4 variablen niet aangemaakt door Password");
            Assert.AreEqual(isadmin, user.IsAdmin, "Contructor met 4 variablen niet aangemaakt door admin boolean");
        }

        [TestMethod]
        public void Register()
        {
            //arrange
            UserDAL DAL = new UserDAL();
            Usercontainer Ucon = new Usercontainer(DAL);

            string email = "Sjimmieemail23@hotmail.com";
            string username = "Sjimmiebest23";
            string password = "password";
            bool isadmin = false;

            //act
            User user = new User(email ,username, password, isadmin);
            Ucon.Register(user);

            //assert
            Assert.AreEqual(email, DAL.testregisterdto.Email, "Register test failed: Fout bij Email");
            Assert.AreEqual(username, DAL.testregisterdto.Username, "Register test failed: Fout bij Username");
            Assert.AreEqual(password, DAL.testregisterdto.Password, "Register test failed: Fout bij Password");
            Assert.AreEqual(isadmin, DAL.testregisterdto.IsAdmin, "Register test failed: Fout bij IsAdmin");
        }

        [TestMethod]
        public void Login()
        {
            //arrange
            UserDAL DAL = new UserDAL();
            Usercontainer Ucon = new Usercontainer(DAL);

            User Checkuser = new User();
            string email = "Sjimmieemail22@hotmail.com";
            string password = "password";

            //act
            User user = new User(email, password);
            Checkuser = Ucon.Login(user);

            //assert
            Assert.AreEqual(Checkuser.Email, DAL.testlogindto.Email, "Login test failed: Fout bij Email");
            Assert.AreEqual(Checkuser.Password, DAL.testlogindto.Password, "Login test failed: Fout bij Password");
        }

        [TestMethod]
        public void ToDTO()
        {
            //arrange
            UserDAL DAL = new UserDAL();
            Usercontainer Ucon = new Usercontainer(DAL);

            User user = new User()
            {
                ID = 5,
                Email = "Random@email.com",
                Username = "Test",
                Password = "password123",
                IsAdmin = true
            };

            //act
            UserDTO userDto = user.ToDto();

            //assert
            Assert.AreEqual(user.ID, userDto.Id);
            Assert.AreEqual(user.Email, userDto.Email);
            Assert.AreEqual(user.Username, userDto.Username);
            Assert.AreEqual(user.Password, userDto.Password);
            Assert.AreEqual(user.IsAdmin, userDto.IsAdmin);
        }
    }
}
