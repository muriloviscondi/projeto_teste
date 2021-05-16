using System.ComponentModel.DataAnnotations;

namespace Project.API.Models
{
    public class CreatePhoneNumberTypeViewModel
    {
        [MaxLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Name { get; set; }
    }
}
