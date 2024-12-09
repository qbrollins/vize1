using System.ComponentModel.DataAnnotations;

namespace Internet_1.ViewModels
{
    public class SurwayQuestionsModel : BaseModel
    {

        [Display(Name = "Adı")]
        [Required(ErrorMessage = "Cevap Adı Giriniz!")]
        public string Name { get; set; }

    }
}
