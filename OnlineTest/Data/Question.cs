using System;
using System.Collections.Generic;

namespace OnlineTest.Data
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
            UsersAnswers = new HashSet<UsersAnswer>();
        }

        public int Id { get; set; }
        public string Question1 { get; set; } = null!;

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<UsersAnswer> UsersAnswers { get; set; }
    }
}
