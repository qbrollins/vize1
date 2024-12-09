using AutoMapper;
using Internet_1.Models;
using Internet_1.ViewModels;

namespace Internet_1.Repositories
{
    public class SurwayRepository : GenericRepository<Surway>
    {
        public SurwayRepository(AppDbContext context) : base(context)
        {
        }
    }
}
