using System.ComponentModel.DataAnnotations;

namespace Project.API.Models
{
    public class CreatePersonPhoneViewModel
    {
        public CreatePersonPhoneViewModel()
        {
            PhoneNumberType = new CreatePhoneNumberTypeViewModel();
        }

        [Required(ErrorMessage = "O número do telefone é obrigatório.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "O PhoneNumberTypeID é obrigatório.")]
        public string PhoneNumberTypeID { get; set; }

        [Required(ErrorMessage = "O PersonId é obrigatório.")]
        public string PersonId { get; set; }

        public CreatePersonViewModel Person { get; set; }

        public CreatePhoneNumberTypeViewModel PhoneNumberType { get; set; }
    }
}
