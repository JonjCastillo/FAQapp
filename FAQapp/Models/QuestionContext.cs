using Microsoft.EntityFrameworkCore;

namespace FAQapp.Models
{
    public class QuestionContext : DbContext
    {
        public QuestionContext(DbContextOptions<QuestionContext> options)
            : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().HasData(
                    new Question
                    {
                        Id = 1,
                        QuestionText = "What is C#?",
                        Category = "General",
                        Topic = "C#",
                        Answer = "A general purpose object oriented language that uses a concise, java-like syntax"
                    },

                    new Question
                    {
                        Id = 2,
                        QuestionText = "What is Bootstrap?",
                        Category = "General",
                        Topic = "Bootstrap",
                        Answer = "A CSS framework for creating resposive web apps for multiple screen sizes"
                    },

                    new Question
                    {
                        Id = 3,
                        QuestionText = "What is JavaScript?",
                        Category = "General",
                        Topic = "JavaScript",
                        Answer = "A general purpose scripting language that executes in a web browser"
                    },

                    new Question
                    {
                        Id = 4,
                        QuestionText = "When was Bootstrap first released?",
                        Category = "History",
                        Topic = "Bootstrap",
                        Answer = "In 2011"
                    },

                    new Question
                    {
                        Id = 5,
                        QuestionText = "When was C# frist released?",
                        Category = "History",
                        Topic = "C#",
                        Answer = "In 2002."
                    }
                );
        }
    }
    

}
