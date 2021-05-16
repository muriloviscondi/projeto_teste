using Project.Domain.Interfaces.Arguments;
using System;

namespace Project.Domain.Arguments.Person
{
    public class PersonResponse : IResponse
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public static explicit operator PersonResponse(Entities.Person person)
        {
            return new PersonResponse
            {
                Id = person.Id,
                Name = person.Name,
            };
        }        
    }
}
