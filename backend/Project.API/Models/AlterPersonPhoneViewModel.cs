using System.ComponentModel.DataAnnotations;

namespace Project.API.Models
{
    public class AlterPersonPhoneViewModel
    {
        [Required(ErrorMessage = "O ID é obrigatório.")]
        public string Id { get; set; }

        [Required(ErrorMessage = "O número do telefone é obrigatório.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "O PhoneNumberTypeID é obrigatório.")]
        public string PhoneNumberTypeID { get; set; }

        [Required(ErrorMessage = "O PersonId é obrigatório.")]
        public string PersonId { get; set; }

        public AlterPersonViewModel Person { get; set; }

        public AlterPhoneNumberTypeViewModel PhoneNumberType { get; set; }
    }
}
