using System.ComponentModel.DataAnnotations;

namespace Project.API.Models
{
    public class CreatePersonViewModel
    {
        public CreatePersonViewModel()
        {
            PersonPhone = new CreatePersonPhoneViewModel();
        }

        [MaxLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        public string[] Phones { get; set; }

        public CreatePersonPhoneViewModel PersonPhone { get; set; }
    }
}
