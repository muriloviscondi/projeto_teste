using Abp.Events.Bus;
using prmToolkit.NotificationPattern;
using Project.Domain.Arguments.Person;
using System;
using System.Collections.Generic;

namespace Project.Domain.Entities
{
    public class Person : EntityBase
    {
        protected Person() { }

        public Person(string name)
        {
            Name = name;

            new AddNotifications<Person>(this).IfNullOrEmpty(x => x.Name, "O nome é obrigatório.");
        }

        public string Name { get; private set; }

        public PersonPhone Phones { get; set; }

        public ICollection<IEventData> DomainEvents => throw new NotImplementedException();

        public void Alter(AlterPersonRequest request)
        {
            Name = request.Name;

            new AddNotifications<Person>(this).IfNullOrEmpty(x => x.Name, "O nome é obrigatório.");
        }
    }
}
