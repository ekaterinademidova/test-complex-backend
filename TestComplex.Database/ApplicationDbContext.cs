using Microsoft.EntityFrameworkCore;
using TestComplex.Domain.Models;

namespace TestComplex.Database
{
    // Create DbContext configured with ms sql local connection.
    // Register created context in API project in DI and use in controller
    // Create initial db migration with user model
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Progress> Progresses { get; set; }
    }

}