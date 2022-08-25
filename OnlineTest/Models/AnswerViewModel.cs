namespace OnlineTest.Models
{
    public class AnswerViewModel
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Answer1 { get; set; }
        public bool IsCorrect { get; set; }
    }
}
