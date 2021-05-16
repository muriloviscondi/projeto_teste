using System;

namespace Project.Domain.Arguments.Base
{
    public class SelectListItem
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public string Group { get; set; }

        public static explicit operator SelectListItem(Entities.PersonPhone personPhone)
        {
            return new SelectListItem
            {
                Id = personPhone.Id,
                Text = personPhone.PhoneNumber,
                Group = personPhone.PhoneNumberType.Name
            };
        }
    }
}
