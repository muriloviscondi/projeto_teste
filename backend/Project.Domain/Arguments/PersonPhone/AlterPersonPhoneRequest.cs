using Project.Domain.Interfaces.Arguments;

namespace Project.Domain.Arguments.PersonPhone
{
    public class AlterPersonPhoneRequest :IRequest
    {
        public string Id { get; set; }

        public string PhoneNumber { get; set; }

        public string PhoneNumberTypeID { get; set; }

        public string PersonId { get; set; }

        public Entities.Person Person { get; set; }

        public Entities.PhoneNumberType PhoneNumberType { get; set; }
    }
}
