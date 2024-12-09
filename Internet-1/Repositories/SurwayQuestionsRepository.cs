using AutoMapper;
using Internet_1.Models;
using Internet_1.ViewModels;

namespace Internet_1.Repositories
{
    public class SurwayQuestionsRepository : GenericRepository<SurwayQuestions>
    {
        public SurwayQuestionsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
