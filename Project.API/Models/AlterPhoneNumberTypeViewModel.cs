using System.ComponentModel.DataAnnotations;

namespace Project.API.Models
{
    public class AlterPhoneNumberTypeViewModel
    {
        [Required(ErrorMessage = "O ID é obrigatório.")]
        public string Id { get; set; }

        [MaxLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Name { get; set; }
    }
}
