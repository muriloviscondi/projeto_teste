using System.ComponentModel.DataAnnotations;

namespace Project.API.Models
{
    public class CreatePersonViewModel
    {
        public CreatePersonViewModel()
        {
            PersonPhone = new CreatePersonPhoneViewModel();
            PhoneType = new CreatePhoneNumberTypeViewModel();
        }

        [MaxLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Name { get; set; }

        public CreatePersonPhoneViewModel PersonPhone { get; set; }

        public CreatePhoneNumberTypeViewModel PhoneType { get; }
    }
}
