using Project.Domain.Interfaces.Arguments;
using System;

namespace Project.Domain.Arguments.Person
{
    public class AlterPersonRequest :IRequest
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string[] Phones { get; set; }
    }
}
