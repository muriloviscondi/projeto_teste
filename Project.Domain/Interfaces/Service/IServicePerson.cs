using Project.Domain.Arguments.Base;
using Project.Domain.Arguments.Person;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Service.Base;
using Project.Domain.Utils;
using System.Threading.Tasks;

namespace Project.Domain.Interfaces.Service
{
    public interface IServicePerson : IServiceBase
    {
        Task<ResponseBase> CreateAsync(CreatePersonRequest request);

        Task<PersonResponse> GetByIdAsync(string id);

        Task<Paginated<PersonListsResponse, Person>> GetAllByPersonAsync(int? pageNumber);

        Task<ResponseBase> AlterAsync(AlterPersonRequest request);

        Task<ResponseBase> Remove(string id);       
    }
}
