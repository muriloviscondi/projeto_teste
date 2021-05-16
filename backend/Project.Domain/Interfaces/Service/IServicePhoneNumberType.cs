using Project.Domain.Arguments.Base;
using Project.Domain.Arguments.PhoneNumberType;
using Project.Domain.Interfaces.Service.Base;
using System.Threading.Tasks;

namespace Project.Domain.Interfaces.Service
{
    public interface IServicePhoneNumberType : IServiceBase
    {
        Task<ResponseBase> CreateAsync(CreatePhoneNumberTypeRequest request);

        Task<PhoneNumberTypeResponse> GetByIdAsync(string id);

        Task<ResponseBase> AlterAsync(AlterPhoneNumberTypeRequest request);

        Task<ResponseBase> Remove(string id);       
    }
}
