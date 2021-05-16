using prmToolkit.NotificationPattern;
using Project.Domain.Extensions;
using System;

namespace Project.Domain.Entities
{
    public class EntityBase : Notifiable
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid().ToString();
            DateCreation = DateTime.Now.ToBrasilia();
        }

        public string Id { get; private set; }

        public DateTime DateCreation { get; protected set; }
    }
}
