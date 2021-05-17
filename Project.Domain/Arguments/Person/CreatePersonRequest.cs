using Project.Domain.Arguments.PersonPhone;
using Project.Domain.Arguments.PhoneNumberType;
using Project.Domain.Interfaces.Arguments;

namespace Project.Domain.Arguments.Person
{
    public class CreatePersonRequest : IRequest
    {
        public string Name { get; set; }

        public CreatePersonPhoneRequest PersonPhone { get; set; }

        public CreatePhoneNumberTypeRequest PhoneNumberType { get; set; }
    }
}
