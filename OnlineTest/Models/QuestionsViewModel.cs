namespace OnlineTest.Models
{
    public class QuestionsViewModel
    {
        public List<QuestionsList> Questions { get; set; }        
    }

    public class QuestionsList
    {
        public int Id { get; set; }
        public string Question { get; set; } = null!;
        public bool Active { get; set; }
        public int SelectedAnswerId { get; set; }
        public List<AnswerViewModel> Answers { get; set; }
    }
}
