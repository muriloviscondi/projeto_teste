using Project.Domain.Interfaces.Arguments;
using System;

namespace Project.Domain.Arguments.PhoneNumberType
{
    public class PhoneNumberTypeResponse : IResponse
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public static explicit operator PhoneNumberTypeResponse(Entities.PhoneNumberType phoneNumberType)
        {
            return new PhoneNumberTypeResponse
            {
                Id = phoneNumberType.Id,
                Name = phoneNumberType.Name,
            };
        }        
    }
}
