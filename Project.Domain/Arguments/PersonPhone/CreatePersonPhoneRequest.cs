using Project.Domain.Interfaces.Arguments;

namespace Project.Domain.Arguments.PersonPhone
{
    public class CreatePersonPhoneRequest : IRequest
    {
        public string PhoneNumber { get; set; }

        public string PhoneNumberTypeID { get; set; }

        public string PersonID { get; set; }

        public Entities.Person Person { get; set; }

        public Entities.PhoneNumberType PhoneNumberType { get; set; }
    }
}
