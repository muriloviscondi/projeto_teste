using Project.Domain.Interfaces.Arguments;
using System;

namespace Project.Domain.Arguments.Person
{
    public class PersonResponse : IResponse
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string PhoneNumberType { get; set; }

        public static explicit operator PersonResponse(Entities.Person person)
        {
            return new PersonResponse
            {
                Id = person.Id,
                Name = person.Name,
                PhoneNumber = person.Phones.PhoneNumber,
                PhoneNumberType = person.Phones.PhoneNumberType.Name,
            };
        }        
    }
}
