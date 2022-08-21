using Microsoft.AspNetCore.Mvc;
using OnlineTest.Data;
using OnlineTest.Models;

namespace OnlineTest.Controllers
{
    public class OnlineTestController : Controller
    {
        private readonly OnlineTestContext _db;

        public OnlineTestController(OnlineTestContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var data = _db.Questions.Select(x => new QuestionsList
            {
                Id = x.Id,
                Question = x.Question1,
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

        public IActionResult SubmitAsnwers(UserAnswersCreateModel[] model)
        {
            // Todo: save answers logic


            return View(); // redirect to one view where they can see the total corrected ansers in percentage
        }


    }
}
