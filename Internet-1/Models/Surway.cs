using System.ComponentModel.DataAnnotations;

namespace Internet_1.Models
{
    public class Surway : BaseEntity
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int SurwayQuestionsId { get; set; }
        public SurwayQuestions SurwayQuestions { get; set; }
    }
}
