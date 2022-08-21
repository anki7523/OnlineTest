using System;
using Microsoft.EntityFrameworkCore;

namespace OnlineTest.Models
{
    public class dbEntities : DbContext
    {
        public dbEntities(DbContextOptions<dbEntities> options): base(options)
        {
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<QuestionModel> Questions { get; set; }
    }
}

