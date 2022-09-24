using Microsoft.AspNetCore.Mvc;
using OnlineTest.Data;
using OnlineTest.DataAccess.Interfaces;
using OnlineTest.DataAccess.Repositories;
using OnlineTest.Models;
using System.Data.Entity;
using System.Diagnostics;

namespace OnlineTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly OnlineTestContext _db;
        private readonly IDataRepository _repository;
        public const string SessionKeyName = "UserId";

        public HomeController(OnlineTestContext db, IDataRepository repository)
        {
            _db = db;
            _repository = repository;
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
        public async Task<IActionResult> Signup(UserSignupModel user)
        {
            try
            {
                if (user != null)
                {
                    var id = await _repository.CheckUser(user.Mobile);
                    if (id > 0)
                    {
                        var userID = id;
                        HttpContext.Session.SetString(SessionKeyName, userID.ToString());
                        return RedirectToAction("Index", "OnlineTest");
                    }
                    else
                    {
                        var userId = await _repository.AddUser(user);
                        HttpContext.Session.SetString(SessionKeyName, userId.ToString());
                        return RedirectToAction("Index", "OnlineTest");
                    }
                }
                else
                {
                    TempData["Message"] = "Something Went wrong ! please try again later.";
                }
            }
            catch(Exception ex)
            {
                TempData["Message"] = "Something Went wrong ! please try again later.";
            }
            TempData["Message"] = "Something Went wrong ! please try again later.";
            return RedirectToAction("Index", "Home");

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