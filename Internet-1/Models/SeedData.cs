using Microsoft.EntityFrameworkCore;

namespace Internet_1.Models
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {




            modelBuilder.Entity<SurwayQuestions>().HasData(
                new SurwayQuestions() { Id = 1, Name = "Categori 1", IsActive = true },
                new SurwayQuestions() { Id = 2, Name = "Categori 1", IsActive = true },
                new SurwayQuestions() { Id = 3, Name = "Categori 2", IsActive = true }
);


            modelBuilder.Entity<Surway>().HasData(new Surway() { Id = 1, Name = "Kalem", Price = 10, Description = "Kalem açıklama", IsActive = true, SurwayQuestionsId = 1 },
            new Surway() { Id = 2, Name = "Defter", Price = 15, Description = "Defter açıklama", IsActive = true, SurwayQuestionsId = 1 },
            new Surway() { Id = 3, Name = "Silgi", Price = 20, Description = "Silgi açıklama", IsActive = false, SurwayQuestionsId = 2 },
            new Surway() { Id = 4, Name = "Kitap", Price = 30, Description = "Kitap açıklama", IsActive = false, SurwayQuestionsId = 2 },
            new Surway() { Id = 5, Name = "Boya", Price = 25, Description = "Boya açıklama", IsActive = false, SurwayQuestionsId = 3 }
                );



        }
    }
}
