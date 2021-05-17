using Project.Domain.Arguments.PersonPhone;
using Project.Domain.Arguments.PhoneNumberType;
using Project.Domain.Interfaces.Arguments;
using System;

namespace Project.Domain.Arguments.Person
{
    public class AlterPersonRequest :IRequest
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public AlterPersonPhoneRequest PersonPhone { get; set; }

        public AlterPhoneNumberTypeRequest PhoneNumberType { get; set; }
    }
}
