using Project.Domain.Interfaces.Arguments;
using System;

namespace Project.Domain.Arguments.PhoneNumberType
{
    public class AlterPhoneNumberTypeRequest : IRequest
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
