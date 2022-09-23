using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineTest.Data
{
    public partial class OnlineTestContext : DbContext
    {
        public OnlineTestContext()
        {
        }

        public OnlineTestContext(DbContextOptions<OnlineTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UsersAnswer> UsersAnswers { get; set; } = null!;
        public virtual DbSet<StateWiseResult> StateWiseResults { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=103.87.173.217;Initial Catalog=OnlineTest;User ID=itfuturz;Password=MyPrincess@1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        //    public string Name { get; set; }
        //public string State { get; set; }
        //public int TotalCorrectAnswer { get; set; }
        //public DateTime SubmittedDate { get; set; }
        //public int RankNo { get; set; }

        modelBuilder.Entity<StateWiseResult>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.UserID).HasColumnName("UserID").HasColumnType("bigint");
                entity.Property(e => e.TotalCorrectAnswer).HasColumnName("TotalCorrectAnswer").HasColumnType("bigint");
                entity.Property(e => e.RankNo).HasColumnName("RankNo").HasColumnType("bigint");
                //entity.Property(e => e.UserID).HasColumnName("UserID");
                entity.Property(e => e.SubmittedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Answer>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Answer1)
                .HasMaxLength(500)
                .HasColumnName("Answer");

            entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

            entity.HasOne(d => d.Question)
                .WithMany(p => p.Answers)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Answer_Question");
        });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Question1)
                    .HasMaxLength(1000)
                    .HasColumnName("Question");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");


                entity.Property(e => e.Mobile)
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.State).HasMaxLength(50);
            });

            modelBuilder.Entity<UsersAnswer>(entity =>
            {
                entity.ToTable("UsersAnswer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AnswerId).HasColumnName("AnswerID");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.UsersAnswers)
                    .HasForeignKey(d => d.AnswerId)
                    .HasConstraintName("FK_UsersAnswer_Answer");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.UsersAnswers)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersAnswer_Question");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
