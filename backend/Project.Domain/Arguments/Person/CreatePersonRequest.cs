using Project.Domain.Interfaces.Arguments;

namespace Project.Domain.Arguments.Person
{
    public class CreatePersonRequest : IRequest
    {
        public string Name { get; set; }

        public string[] Phones { get; set; }
    }
}
