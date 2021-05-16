using Project.Domain.Interfaces.Arguments;
using System;

namespace Project.Domain.Arguments.PersonPhone
{
    public class PersonPhoneResponse : IResponse
    {
        public string Id { get; set; }

        public string PhoneNumberTypeID { get; set; }

        public static explicit operator PersonPhoneResponse(Entities.PersonPhone personPhone)
        {
            return new PersonPhoneResponse
            {
                Id = personPhone.Id,
                PhoneNumberTypeID = personPhone.PhoneNumberTypeID,
            };
        }        
    }
}
