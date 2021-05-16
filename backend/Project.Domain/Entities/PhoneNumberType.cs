using Abp.Events.Bus;
using prmToolkit.NotificationPattern;
using Project.Domain.Arguments.PhoneNumberType;
using System;
using System.Collections.Generic;

namespace Project.Domain.Entities
{
    public class PhoneNumberType : EntityBase
    {
        protected PhoneNumberType() { }

        public PhoneNumberType(string name)
        {
            Name = name;

            new AddNotifications<PhoneNumberType>(this).IfNullOrEmpty(x => x.Name, "O nome é obrigatório.");
        }

        public string Name { get; private set; }

        public ICollection<IEventData> DomainEvents => throw new NotImplementedException();

        public void Alter(AlterPhoneNumberTypeRequest request)
        {
            Name = request.Name;

            new AddNotifications<PhoneNumberType>(this).IfNullOrEmpty(x => x.Name, "O nome é obrigatório.");
        }
    }
}
