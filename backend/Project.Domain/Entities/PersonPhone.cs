using Abp.Events.Bus;
using prmToolkit.NotificationPattern;
using Project.Domain.Arguments.PersonPhone;
using System;
using System.Collections.Generic;

namespace Project.Domain.Entities
{
    public class PersonPhone : EntityBase
    {
        protected PersonPhone() { }

        public PersonPhone(string phoneNumber, string phoneNumberTypeID, string personId)
        {
            PhoneNumber = phoneNumber;
            PhoneNumberTypeID = phoneNumberTypeID;
            PersonId = personId;

            new AddNotifications<PersonPhone>(this).IfNullOrEmpty(x => x.PhoneNumber, "O telefone é obrigatório.");
            new AddNotifications<PersonPhone>(this).IfNullOrEmpty(x => x.PhoneNumberTypeID, "O PhoneNumberTypeID é obrigatório.");
            new AddNotifications<PersonPhone>(this).IfNullOrEmpty(x => x.PersonId, "O PhoneNumberTypeID é obrigatório.");
        }

        public string PhoneNumber { get; private set; }

        public string PhoneNumberTypeID { get; private set; }

        public string PersonId { get; private set; }

        public Person Person { get; private set; }

        public PhoneNumberType PhoneNumberType { get; private set; }

        public ICollection<IEventData> DomainEvents => throw new NotImplementedException();

        public void Alter(AlterPersonPhoneRequest request)
        {
            PhoneNumber = request.PhoneNumber;
            PhoneNumberTypeID = request.PhoneNumberTypeID;
            PersonId = request.PersonId;

            new AddNotifications<PersonPhone>(this).IfNullOrEmpty(x => x.PhoneNumber, "O telefone é obrigatório.");
            new AddNotifications<PersonPhone>(this).IfNullOrEmpty(x => x.PhoneNumberTypeID, "O PhoneNumberTypeID é obrigatório.");
        }
    }
}
