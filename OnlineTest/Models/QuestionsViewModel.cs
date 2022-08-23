namespace OnlineTest.Models
{
    public class QuestionsViewModel
    {
        //andhi
        public List<QuestionsList> Questions { get; set; }        
    }

    public class QuestionsList
    {

        public int Id { get; set; }
        public string Question { get; set; } = null!;

        //public string QueAns { get; set; }

        public List<AnswerViewModel> Answers { get; set; }
    }
}
