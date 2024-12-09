using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Internet_1.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public DbSet<Surway> Surways { get; set; }
        public DbSet<SurwayQuestions> SurwayQuestionss { get; set; }
        public DbSet<Todo> Todos { get; set; }




        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Seed();
        //}
    }
}
