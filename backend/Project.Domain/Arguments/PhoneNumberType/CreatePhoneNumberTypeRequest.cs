using Project.Domain.Interfaces.Arguments;

namespace Project.Domain.Arguments.PhoneNumberType
{
    public class CreatePhoneNumberTypeRequest : IRequest
    {
        public string Name { get; set; }        
    }
}
