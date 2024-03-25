using Gamepage_Classlibrary;
using Gamepage_DAL;
using Gamepage_interfaces;
using GamepageWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace GamepageWebApplication.Controllers
{
    public class Clipcontroller : Controller
    {
        Clipcontainer ccon = new Clipcontainer(new ClipSQLDAL());

        // GET: Clipcontroller
        public ActionResult Index(int gameid)
        {
            TempData["gameid"] = gameid;

            if (Checkcookies() != true)
            {
                return RedirectToAction("Logout", "Home");
            }

            List<Clip> clips = ccon.GetClipList(gameid);
            List<ClipViewModel> viewmodels = new List<ClipViewModel>();

            foreach (Clip c in clips)
            {
                ClipViewModel viewmodel = new ClipViewModel()
                {
                    ClipID = c.ClipID,
                    GameID= c.GameID,
                    UserID= c.UserID,
                    Maker = c.Maker,
                    Title= c.Title,
                    ClipText= c.ClipText
                };

                viewmodels.Add(viewmodel);
            }

            return View(viewmodels);
        }

        // GET: Clipcontroller/Create
        public ActionResult CreateClip()
        {
            if (Checkcookies() != true)
            {
                return RedirectToAction("Logout", "Home");
            }
            
            ClipViewModel newclip = new ClipViewModel();

            return View(newclip);
        }

        // POST: Clipcontroller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateClip(ClipViewModel viewmodel)
        {
            int id = HttpContext.Session.GetInt32("UserID") ?? -0;

            if (Checkcookies() != true)
            {
                return RedirectToAction("Logout", "Home");
            }

            if (TempData["gameid"] != null && int.TryParse(TempData["gameid"].ToString(), out int gameid))
            {
                viewmodel.GameID = gameid;
            }

            try
            {
                Clip newclip = new Clip();
                newclip.GameID = viewmodel.GameID;
                newclip.UserID = id;
                newclip.Title = viewmodel.Title;
                newclip.ClipText = viewmodel.ClipText;

                ccon.AddClip(newclip);

                return RedirectToAction(nameof(Index), new { gameid = viewmodel.GameID });
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
