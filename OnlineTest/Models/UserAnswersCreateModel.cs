namespace OnlineTest.Models
{
    public class UserAnswersCreateModel
    {
        public List<QuestionsAnswer> UserAnswers { get; set; }
    }

    public class QuestionsAnswer
    {
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
    }
}
