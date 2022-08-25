using Microsoft.AspNetCore.Mvc;
using OnlineTest.Data;
using OnlineTest.Models;

namespace OnlineTest.Controllers
{
    public class OnlineTestController : Controller
    {
        private readonly OnlineTestContext _db;
        public const string SessionKeyName = "UserId";

        public OnlineTestController(OnlineTestContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            // var itens = _db.UsersAnswers
            //.Join(_db.Answers, ua => ua.AnswerId,
            //a => a.Id, (ua, a) => new { ua, a })
            //.Where(x => x.a.IsCorrect == true)
            //.GroupBy(x => new { x.ua.UserId })
            //.Select(g => new
            //{
            //    g.Key.UserId,
            //    Count = g.Count()
            //}).OrderByDescending(x => x.Count).Take(3).ToList();

            var userid = HttpContext.Session.GetString(SessionKeyName);
            if (Convert.ToInt64(userid) > 0)
            {
                var data = _db.Questions.Where(q => q.Active == true).Select(x => new QuestionsList
                {
                    Id = x.Id,
                    Question = x.Question1,
                    Active = x.Active,
                    Answers = _db.Answers.Where(a => a.QuestionId == x.Id).Select(ax => new AnswerViewModel
                    {
                        Id = ax.Id,
                        QuestionId = ax.QuestionId,
                        Answer1 = ax.Answer1
                    }).ToList()

                }).Where(x => x.Answers.Count() > 0); // yahan pe active = 0 check kar lena DB update krne ke baad
                QuestionsViewModel model = new QuestionsViewModel { Questions = data.ToList() };
                return View(model);
            }
            else
            {
                TempData["Message"] = "You have not access. please register yourself.";
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult solutions()
        {
            var data = _db.Questions.Select(x => new QuestionsList
            {
                Id = x.Id,
                Question = x.Question1,
                Active = x.Active,
                Answers = _db.Answers.Where(a => a.QuestionId == x.Id).Select(ax => new AnswerViewModel
                {
                    Id = ax.Id,
                    QuestionId = ax.QuestionId,
                    Answer1 = ax.Answer1,
                    IsCorrect = ax.IsCorrect,
                }).ToList()

            }).Where(x => x.Answers.Count() > 0);

            QuestionsViewModel model = new QuestionsViewModel { Questions = data.ToList() };
            return View(model);
        }

        public IActionResult SubmitAsnwers(QuestionsViewModel model)
        {
            try
            {
                var userid = HttpContext.Session.GetString(SessionKeyName);
                if (Convert.ToInt64(userid) > 0)
                {
                    var alreadyExistUA = _db.UsersAnswers.Where(x => x.UserId == Convert.ToInt32(userid)).Any();
                    if (alreadyExistUA)
                    {
                        TempData["Message"] = "You have already given the test!";
                        return RedirectToAction("UserResult");
                    }
                    else
                    {
                        //throw new Exception();
                        // Todo: save answers logic
                        // jab time out ho jaayega us time pe maybe ku6 ans select nahi kiye ho
                        // to usko table me save nahi krna hai is liye selectedanswer 0 kic condition
                        var userAnswers = model.Questions.Where(x => x.SelectedAnswerId != 0).Select(item => new UsersAnswer
                        {
                            QuestionId = item.Id,
                            AnswerId = item.SelectedAnswerId,
                            UserId = Convert.ToInt64(userid),
                            CreatedDate = DateTime.UtcNow
                        });

                        _db.AddRange(userAnswers);
                        _db.SaveChanges();
                    }
                }
                else
                {
                    TempData["Message"] = "You have not access. please register yourself.";
                    return RedirectToAction("Index", "Home");
                }

            }
            catch
            {
                TempData["Message"] = "Something went wrong, please try again later!";
                // add log to the file from here using Serilog, do once everything is completed
                return View("Index", model);
            }
            return RedirectToAction("UserResult");
        }

        public IActionResult UserResult()
        {
            WinnerModel model = new WinnerModel();
            var userid = HttpContext.Session.GetString(SessionKeyName);
            if (Convert.ToInt64(userid) > 0)
            {
                var top3winners = (from ua in _db.UsersAnswers
                                   join a in _db.Answers on ua.AnswerId equals a.Id
                                   join u in _db.Users on ua.UserId equals u.Id
                                   where a.IsCorrect == true
                                   group ua by new { ua.UserId, u.Name, u.State} into g
                                   select new Top3WinnerModel
                                   {
                                       Name = g.Key.Name,
                                       State = g.Key.State,                                       
                                       UserId = g.Key.UserId,
                                       TotalCorrectAnswers = g.Count(),
                                   }).OrderByDescending(x => x.TotalCorrectAnswers).Take(3);


                int[] top3winnerprize = { 11000, 7100, 5100 };
                model.Top3WinnerPrize = top3winnerprize;
                model.Top3WinnerList = top3winners.ToList();
                return View(model);
            }
            else
            {
                TempData["Message"] = "You have not access. please register yourself.";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
