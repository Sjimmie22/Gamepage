using Gamepage_Classlibrary;
using Gamepage_DAL;
using GamepageWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamepageWebApplication.Controllers
{
    public class CommentController : Controller
    {
        Commentcontainer cocon = new Commentcontainer(new CommentSQLDAL());

        // GET: CommentController
        public ActionResult Index(int clipid)
        {
            TempData["clipid"] = clipid;

            if (Checkcookies() != true)
            {
                return RedirectToAction("Logout", "Home");
            }

            List<Comment> comments = cocon.getCommentList(clipid);
            List<CommentViewModel> viewmodelcommments = new List<CommentViewModel>();

            foreach (Comment co in comments)
            {
                CommentViewModel viewmodel = new CommentViewModel()
                {
                    CommentID = co.CommentID,
                    ClipID = co.ClipID,
                    UserID = co.UserID,
                    CommentText= co.CommentText,
                    Maker = co.Maker
                };

                viewmodelcommments.Add(viewmodel);
            }

            return View(viewmodelcommments);
        }

        // GET: CommentController/Create
        public ActionResult AddComment()
        {
            if (Checkcookies() != true)
            {
                return RedirectToAction("Logout", "Home");
            }

            CommentViewModel empty = new CommentViewModel();

            return View(empty);
        }

        // POST: CommentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(CommentViewModel viewmodel)
        {
            int userid = HttpContext.Session.GetInt32("UserID") ?? -0;

            if (Checkcookies() != true)
            {
                return RedirectToAction("Logout", "Home");
            }

            if (TempData["clipid"] != null && int.TryParse(TempData["clipid"].ToString(), out int clipid))
            {
                viewmodel.ClipID = clipid;
            }

            try
            {
                Comment newcomment = new Comment()
                {
                    ClipID= viewmodel.ClipID,
                    UserID= userid,
                    CommentText= viewmodel.CommentText
                };

                cocon.addComment(newcomment);

                return RedirectToAction(nameof(Index), new { clipid = viewmodel.ClipID });
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
