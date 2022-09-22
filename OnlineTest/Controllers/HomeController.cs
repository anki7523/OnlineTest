using Microsoft.AspNetCore.Mvc;
using OnlineTest.Data;
using OnlineTest.Models;
using System.Diagnostics;

namespace OnlineTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly OnlineTestContext _db;
        public const string SessionKeyName = "UserId";

        public HomeController(OnlineTestContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signup(User user)
        {
            try
            {
                if (user != null)
                {
                    var isExistUser = _db.Users.Where(x => x.Mobile.Equals(user.Mobile));
                    if (isExistUser.Any())
                    {
                        var userID = isExistUser.FirstOrDefault().Id;
                        HttpContext.Session.SetString(SessionKeyName, userID.ToString());
                        return RedirectToAction("Index","OnlineTest");
                    }
                    else
                    {
                        user.CreatedDate = DateTime.Now;
                        _db.Add(user);
                        _db.SaveChanges();
                        long id = user.Id;
                        HttpContext.Session.SetString(SessionKeyName, id.ToString());
                        return RedirectToAction("Index", "OnlineTest");
                    }
                }
                else
                {
                    TempData["Message"] = "Something Went wrong ! please try again later.";
                }
            }
            catch
            {
                TempData["Message"] = "Something Went wrong ! please try again later.";
            }
            return View();

        }
        public IActionResult WelcomePage()
        {
            var userid = HttpContext.Session.GetString(SessionKeyName);
            if (Convert.ToInt64(userid) > 0)
            {
                return View();
            }
            else
            {
                TempData["Message"] = "You have not access. please register yourself.";
                return RedirectToAction("Index");
            }
        }

        public IActionResult QuestionAnswer()
        {
            var questions = _db.Questions.ToList();
            return View(questions);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}