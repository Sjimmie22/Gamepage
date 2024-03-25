using GamepageWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gamepage_Classlibrary;
using Gamepage_DAL;
using System.Net;
using System.Reflection;

namespace GamepageWebApplication.Controllers
{
    public class GameController : Controller
    {
        // GET: GameController
        Gamecontainer gcon = new Gamecontainer(new GameSQLDAL());

        public ActionResult Index()
        {
            if (Checkcookies() != true)
            {
                return RedirectToAction("Logout", "Home");
            }

            List<Game> games = gcon.getGameList();
            List<GameViewModel> gamesViewModels = new List<GameViewModel>();

            foreach (Game g in games)
            {
                GameViewModel gameViewModel = new GameViewModel()
                {
                    ID = g.ID,
                    Name = g.Name,
                    IsAdmin = HttpContext.Session.GetString("Admin") == "true"
                };
                gamesViewModels.Add(gameViewModel);
            }
            return View(gamesViewModels);
        }

        // GET: GameController/Details/5
        public ActionResult Details(int id)
        {
            int userID = HttpContext.Session.GetInt32("UserID") ?? -1;

            if (userID == 1)
            {
                if (Checkcookies() != true)
                {
                    return RedirectToAction("Logout", "Home");
                }

                if (id == 0)
                {
                    return null;
                }

                Game g = new() { ID = id };
                g = gcon.getById(id);

                GameViewModel gameview = new() { ID = g.ID, Name = g.Name };
                if (gameview == null)
                {
                    return null;
                }
                return View(gameview);
            }
            else
            {
                if (Checkcookies() != true)
                {
                    return RedirectToAction("Logout", "Home");
                }

                return RedirectToAction("Index", "Game");
            }
        }

        // GET: GameController/Create
        public ActionResult Create()
        {
            if (Checkcookies() != true)
            {
                return RedirectToAction("Logout", "Home");
            }

            GameViewModel gameview = new();
            return View(gameview);
        }

        // POST: GameController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Game g = new() { Name = model.Name };
                    gcon.AddGame(g);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Lukt niet om game op te slaan... als niet alles ingevuld is doe dat, of probeer het later nog eens.");
            }
            return View();
        }

        // GET: GameController/Edit/5
        public ActionResult Edit(int id)
        {
            int userID = HttpContext.Session.GetInt32("UserID") ?? -1;

            if(userID== 1)
            {
                if (Checkcookies() != true)
                {
                    return RedirectToAction("Logout", "Home");
                }

                if (id == 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Game g = new() { ID = id };
                    g = gcon.getById(id);

                    GameViewModel gameview = new GameViewModel { ID = id, Name = g.Name };

                    return View(gameview);
                }
            }
            else
            {
                if (Checkcookies() != true)
                {
                    return RedirectToAction("Logout", "Home");
                }

                return RedirectToAction("Index", "Game");
            }
        }

        // POST: GameController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GameViewModel model)
        {
            try
            {
                Game g = new() {ID = model.ID, Name = model.Name };
                gcon.updategame(g);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Lukt niet om game te editten... als niet alles ingevuld is doe dat, of probeer het later nog eens.");
            }
            return View();
        }

        // GET: GameController/Delete/5
        public ActionResult Delete(int id)
        {
            int userID = HttpContext.Session.GetInt32("UserID") ?? -1;

            if (userID == 1)
            {
                if (Checkcookies() != true)
                {
                    return RedirectToAction("Logout", "Home");
                }

                if (id == 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Game g = new() { ID = id };
                    g = gcon.getById(id);

                    GameViewModel gameview = new GameViewModel { ID = id, Name = g.Name };

                    return View(gameview);
                }
            }
            else
            {
                if (Checkcookies() != true)
                {
                    return RedirectToAction("Logout", "Home");
                }

                return RedirectToAction("Index", "Game");
            }
        }

        // POST: GameController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(GameViewModel model)
        {
            try
            {
                Game g = new Game() { ID = model.ID, Name = model.Name};
                gcon.removeGame(g);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

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
    }
}
