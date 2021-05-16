using Project.Domain.Arguments.Base;
using Project.Domain.Arguments.PersonPhone;
using Project.Domain.Interfaces.Service.Base;
using System.Threading.Tasks;

namespace Project.Domain.Interfaces.Service
{
    public interface IServicePersonPhone : IServiceBase
    {
        Task<ResponseBase> CreateAsync(CreatePersonPhoneRequest request);

        Task<PersonPhoneResponse> GetByIdAsync(string id);

        Task<ResponseBase> AlterAsync(AlterPersonPhoneRequest request);

        Task<ResponseBase> Remove(string id);       
    }
}
