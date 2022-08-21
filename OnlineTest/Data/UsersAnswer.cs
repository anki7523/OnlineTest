using System;
using System.Collections.Generic;

namespace OnlineTest.Data
{
    public partial class UsersAnswer
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public int QuestionId { get; set; }
        public int? AnswerId { get; set; }

        public virtual Answer? Answer { get; set; }
        public virtual Question Question { get; set; } = null!;
    }
}
