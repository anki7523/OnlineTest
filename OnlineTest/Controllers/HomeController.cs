using Microsoft.AspNetCore.Mvc;
using OnlineTest.Models;
using System.Diagnostics;

namespace OnlineTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly dbEntities _db;

        public HomeController(dbEntities db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<UserModel> data = _db.Users.ToList();
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signup(UserModel user)
        {
            if (user !=null)
            {
                user.CreatedDate = DateTime.Now;
                user.State = "Gujrat";
                _db.Add(user);
                _db.SaveChanges();
                return RedirectToAction("WelcomePage");
            }
            else
            {
                return RedirectToAction ("Error");
            }
           
        }
        public IActionResult WelcomePage()
        {
            return View();
        }

        public IActionResult QuestionAnswer()
        {
            IEnumerable<QuestionModel> questions = _db.Questions.ToList();
            return View(questions);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}