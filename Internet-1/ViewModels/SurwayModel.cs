using System.ComponentModel.DataAnnotations;

namespace Internet_1.ViewModels
{
    public class SurwayModel : BaseModel
    {


        [Display(Name = "Anket Adı")]
        [Required(ErrorMessage = "Anket Adı Giriniz!")]
        public string Name { get; set; }





        [Display(Name = "Anket Açıklama")]
        [Required(ErrorMessage = "Anket Açıklama Giriniz!")]
        public string Description { get; set; }





        [Display(Name = "Anket Fiyatı")]
        [Required(ErrorMessage = "Anket Fiyatı Giriniz!")]
        public decimal Price { get; set; }



        [Display(Name = "Cevap")]
        [Required(ErrorMessage = "Cevap Giriniz!")]
        public int SurwayQuestionsId { get; set; }
    }
}
