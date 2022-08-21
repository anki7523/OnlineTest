using System;
using System.Collections.Generic;

namespace OnlineTest.Data
{
    public partial class Answer
    {
        public Answer()
        {
            UsersAnswers = new HashSet<UsersAnswer>();
        }

        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Answer1 { get; set; } = null!;
        public bool IsCorrect { get; set; }

        public virtual Question Question { get; set; } = null!;
        public virtual ICollection<UsersAnswer> UsersAnswers { get; set; }
    }
}
