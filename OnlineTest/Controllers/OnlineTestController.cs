using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineTest.Data;
using OnlineTest.DataAccess.Interfaces;
using OnlineTest.Models;
using System.Globalization;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace OnlineTest.Controllers
{
    public class OnlineTestController : Controller
    {
        private readonly OnlineTestContext _db;
        private readonly IDataRepository _dataRepository;
        public const string SessionKeyName = "UserId";


        public OnlineTestController(OnlineTestContext db, IDataRepository dataRepository)
        {
            _db = db;
            _dataRepository = dataRepository;
        }
        [Route("OnlineTest")]
        public IActionResult Index()
        {
            DateTime startTestTime = new DateTime(2022, 9, 24, 16, 40, 0);
            DateTime endTestTime = new DateTime(2022, 9, 24, 16, 55, 0);
            var localDateTime = DateTime.Now;
            try
            {
                var client = new TcpClient("time.nist.gov", 13);
                using (var streamReader = new StreamReader(client.GetStream()))
                {
                    var response = streamReader.ReadToEnd();
                    var utcDateTimeString = response.Substring(7, 17);
                    localDateTime = DateTime.ParseExact(utcDateTimeString, "yy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
                }
            }
            catch (Exception) { }
            double totalSeconds = 1800;
            ViewBag.totalPassedSecond = 0;
            if(localDateTime < endTestTime) 
            {
                if (localDateTime >= startTestTime)
                {
                    var totalPassedSecond = Math.Round(localDateTime.Subtract(startTestTime).TotalSeconds);
                    ViewBag.totalPassedSecond = totalPassedSecond;
                    if (totalPassedSecond > totalSeconds)
                    {
                        ViewBag.totalPassedSecond = 1799;
                    }
                    else
                    {
                        ViewBag.totalPassedSecond = totalPassedSecond;
                    }
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

                        }).Where(x => x.Answers.Count() > 0);
                        QuestionsViewModel model = new QuestionsViewModel { Questions = data.ToList() };
                        return View(model);
                    }
                    else
                    {
                        TempData["Message"] = "You have not access. please register yourself.";
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    TempData["TestTimeInvalid"] = "Test will start at 11:00 AM on 25th September 2022. please refresh page on time.";
                    return View();
                }
            }
            else
            {
                TempData["Message"] = "Test time has been closed. you can not access the test !";
                return RedirectToAction("UserResult");
            }
            
        }

        public IActionResult solutions()
        {
            QuestionsViewModel model = new QuestionsViewModel { };
            return View(model);
        }

        public async Task<IActionResult> SubmitAsnwers(QuestionsViewModel model)
        {
            try
            {
                var userid = HttpContext.Session.GetString(SessionKeyName);
                if (Convert.ToInt64(userid) > 0)
                {
                    var alreadyExistUA = await _dataRepository.CheckUsersAnswers(Convert.ToInt64(userid));
                    if (alreadyExistUA > 0)
                    {
                        TempData["Message"] = "You have already given the test!";
                        return RedirectToAction("UserResult");
                    }
                    else
                    {
                        var userAnswers = model.Questions.Where(x => x.SelectedAnswerId != 0).Select(item => new UsersAnswer
                        {
                            QuestionId = item.Id,
                            AnswerId = item.SelectedAnswerId,
                            UserId = Convert.ToInt64(userid),
                            CreatedDate = DateTime.UtcNow
                        });
                        await _db.AddRangeAsync(userAnswers);
                        await _db.SaveChangesAsync();
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
                return View("Index", model);
            }
            return RedirectToAction("UserResult");
        }

        public async Task<IActionResult> UserResult()
        {
            WinnerModel model = new WinnerModel();
            var userid = HttpContext.Session.GetString(SessionKeyName);
            if (Convert.ToInt64(userid) > 0)
            {
                var top3winners = (from ua in _db.UsersAnswers.AsNoTracking()
                                   join a in _db.Answers.AsNoTracking() on ua.AnswerId equals a.Id
                                   join u in _db.Users.AsNoTracking() on ua.UserId equals u.Id
                                   where a.IsCorrect == true
                                   group ua by new { ua.UserId, u.Name, u.State } into g
                                   select new Top3WinnerModel
                                   {
                                       Name = g.Key.Name,
                                       State = g.Key.State,
                                       UserId = g.Key.UserId,
                                       TotalCorrectAnswers = g.Count(),
                                   }).OrderByDescending(x => x.TotalCorrectAnswers).Take(3);
                var stateWiseRank = await _dataRepository.GetStateWiseResult();
                // remove user from the statewise winner who is already in top 3
                var stateWiseWinner = stateWiseRank.Where(x => !top3winners.Any(y => y.UserId == x.UserID));
                int[] top3winnerprize = { 11000, 7100, 5100 };
                model.Top3WinnerPrize = top3winnerprize;
                model.Top3WinnerList = top3winners.ToList();
                model.StateWiseWinnerList = stateWiseWinner.ToList();
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
