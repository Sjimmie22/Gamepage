using Gamepage_Classlibrary;
using Gamepage_DAL;
using GamepageWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace GamepageWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        Usercontainer ucon = new Usercontainer(new UserSQLDAL());
        Gamecontainer gcon = new Gamecontainer(new GameSQLDAL());
        UserGameContainer ugcon = new UserGameContainer(new UserGameSQLDAL());

        private bool Checkcookies()
        {
            if (DateTime.TryParse(Request.Cookies["RememberMeExpires"], out DateTime expirationDate))
            {
                if (expirationDate >= DateTime.Now)
                {
                    return true;
                }
            }

            return false;
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("IsLoggedIn") == "true")
            {
                return RedirectToAction(nameof(GameList));
            }

            return View();
        }

        [HttpPost]
        public IActionResult Index(UserViewModel Uviewmodel)
        {

            User u = new User(Uviewmodel.Email, Uviewmodel.Username, Uviewmodel.Password, Uviewmodel.Isadmin);
            u = ucon.Login(u);

            if (u.ID > 0)
            {
                HttpContext.Session.SetInt32("UserID", u.ID);
                HttpContext.Session.SetString("Username", u.Username);
                HttpContext.Session.SetString("IsLoggedIn", "true");

                if (u.IsAdmin == true)
                {
                    HttpContext.Session.SetString("Admin", "true");
                }

                if (Uviewmodel.RememberMe)
                {
                    CookieOptions options = new CookieOptions()
                    {
                        Expires = DateTime.Now.AddDays(7),
                        IsEssential = true
                    };
                    Response.Cookies.Append("RememberMeExpires", DateTime.Now.AddDays(7).ToString(), options);
                }
                else
                {
                    CookieOptions options = new CookieOptions()
                    {
                        Expires = DateTime.Now.AddMinutes(30),
                        IsEssential = true
                    };
                    Response.Cookies.Append("RememberMeExpires", DateTime.Now.AddMinutes(30).ToString(), options);
                }
                return RedirectToAction(nameof(GameList));
            }
            else
            {
                ModelState.AddModelError("", "Verkeerde Credentials Zet de goede er in of Registeer je.");
            }

            return View(Uviewmodel);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserViewModel Uviewmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool admin = false;
                    User u = new User(Uviewmodel.Email, Uviewmodel.Username, Uviewmodel.Password, admin);
                    ucon.Register(u);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Lukt niet om te Registeren...probeer het later nog eens.");
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserID");
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("IsLoggedIn");
            HttpContext.Session.Remove("Admin");

            Response.Cookies.Delete("RememberMe");
            Response.Cookies.Delete("RememberMeExpires");

            return RedirectToAction(nameof(Index));
        }

        public IActionResult GameList()
        {
            if (Checkcookies() != true)
            {
                return RedirectToAction(nameof(Logout));
            }

            int userID = HttpContext.Session.GetInt32("UserID") ?? -1;

            List<UserGameViewModel> userGameViewModels = new List<UserGameViewModel>();

            List<UserGame> userGames = ugcon.GetByUserID(userID);

            foreach (UserGame g in userGames)
            {
                UserGameViewModel userGameViewModel = new UserGameViewModel()
                {
                    gameID = g.gameID,
                    Name = g.Name,
                    Time = g.Time,
                    Level= g.Level,
                    Particularities= g.Particularities
                };

                userGameViewModels.Add(userGameViewModel);
            }

            return View(userGameViewModels);
        }

        public IActionResult Addgamelist()
        {
            if (Checkcookies() != true)
            {
                return RedirectToAction(nameof(Logout));
            }

            UserGameViewModel newviewmodel = new UserGameViewModel();

            List<Game> games = gcon.getGameList();
            List<UserGameViewModel> gamesViewModels = new List<UserGameViewModel>();

            foreach (Game g in games)
            {
                UserGameViewModel gameViewModel = new UserGameViewModel()
                {
                    Name = g.Name
                };
                gamesViewModels.Add(gameViewModel);
            }

            ViewBag.ExistingUserGames = gamesViewModels;


            return View(newviewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Addgamelist(UserGameViewModel viewmodel)
        {
            if (Checkcookies() != true)
            {
                return RedirectToAction(nameof(Logout));
            }

            viewmodel.userID = HttpContext.Session.GetInt32("UserID") ?? -1;

            try
            {
                if (viewmodel.Particularities == string.Empty)
                {
                    viewmodel.Particularities = "-";
                }

                viewmodel.gameID = ugcon.getByName(viewmodel.Name);

                UserGame usergame = new UserGame()
                {
                    userID = viewmodel.userID,
                    gameID = viewmodel.gameID,
                    Time = viewmodel.Time,
                    Level = viewmodel.Level,
                    Particularities = viewmodel.Particularities
                };

                ugcon.addUserGame(usergame);

                return RedirectToAction(nameof(GameList), new { userid = viewmodel.userID });

            }
            catch
            {
                ModelState.AddModelError("", "Lukt niet om game op te slaan... als niet alles ingevuld is doe dat, of probeer het later nog eens.");
            }
            return View();
        }

        public IActionResult GameListedit(UserGameViewModel viewmodel)
        {
            if (Checkcookies() != true)
            {
                return RedirectToAction(nameof(Logout));
            }

            return View(viewmodel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult GameListeditPost(UserGameViewModel viewmodel)
        {
            viewmodel.userID = HttpContext.Session.GetInt32("UserID") ?? -1;

            if (Checkcookies() != true)
            {
                return RedirectToAction(nameof(Logout));
            }

            try
            {
                UserGame g = new() { userID = viewmodel.userID, gameID = viewmodel.gameID, Level = viewmodel.Level, Time = viewmodel.Time, Particularities = viewmodel.Particularities };
                ugcon.editUserGame(g);
                return RedirectToAction(nameof(GameList));
            }
            catch
            {
                ModelState.AddModelError("", "Lukt niet om Usergame te editten... als niet alles ingevuld is doe dat, of probeer het later nog eens.");
            }
            return View();

        }

        public IActionResult GameListdelete(int gameID, int userID)
        {
            userID = HttpContext.Session.GetInt32("UserID") ?? -1;

            if (Checkcookies() != true)
            {
                return RedirectToAction(nameof(Logout));
            }

            try
            {
                ugcon.removeUserGame(userID, gameID);
                return RedirectToAction(nameof(GameList));

            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Lukt niet om Usergame te verwijderen...");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}