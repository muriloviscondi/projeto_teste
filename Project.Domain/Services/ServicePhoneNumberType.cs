using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern;
using Project.Domain.Arguments.Base;
using Project.Domain.Arguments.PhoneNumberType;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using Project.Domain.Interfaces.Service;
using System.Threading.Tasks;

namespace Project.Domain.Services
{
    public class ServicePhoneNumberType : Notifiable, IServicePhoneNumberType
    {
        #region Constructor
        public ServicePhoneNumberType() { }

        public ServicePhoneNumberType(
           IRepositoryPhoneNumberType repositoryPhoneNumberType)
        {
            _repositoryPhoneNumberType = repositoryPhoneNumberType;
        }

        #endregion

        #region Properties
        private readonly IRepositoryPhoneNumberType _repositoryPhoneNumberType;
        #endregion

        public async Task<ResponseBase> CreateAsync(CreatePhoneNumberTypeRequest request)
        {
            if (request == null)
            {
                AddNotification("PhoneNumberType", "O tipo do número é obrigatório.");
                return null;
            }

            var phoneNumberType = new PhoneNumberType(request.Name);

            AddNotifications(phoneNumberType);

            if (this.IsInvalid())
            {
                return null;
            }

            await _repositoryPhoneNumberType.InsertAsync(phoneNumberType);
            return new ResponseBase() { Id = phoneNumberType.Id };
        }

        public async Task<PhoneNumberTypeResponse> GetByIdAsync(string id)
        {
            PhoneNumberType phoneNumberType = await _repositoryPhoneNumberType.GetByIdAsync(id);

            if (phoneNumberType == null)
            {
                AddNotification("PhoneNumberType", "O tipo do número foi encontrado.");
                return null;
            }

            return (PhoneNumberTypeResponse)phoneNumberType;
        }

        public async Task<ResponseBase> AlterAsync(AlterPhoneNumberTypeRequest request)
        {
            if (request == null)
            {
                AddNotification("PhoneNumberType", "O tipo do número é obrigatório.");
                return null;
            }

            PhoneNumberType phoneNumberType = await _repositoryPhoneNumberType.GetByIdAsync(request.Id, false);

            if (phoneNumberType == null)
            {
                AddNotification("PhoneNumberType", "Tipo de número não encontrado");
                return null;
            }

            phoneNumberType.Alter(request);

            AddNotifications(phoneNumberType);

            if (this.IsInvalid())
            {
                return null;
            }

            _repositoryPhoneNumberType.Update(phoneNumberType);
            return new ResponseBase();
        }

        public async Task<ResponseBase> Remove(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                AddNotification("Id", "Tipo de número não encontrado");
                return null;
            }

            PhoneNumberType phoneNumberType = await _repositoryPhoneNumberType.GetAllBy(true, x => x.Id == id).FirstOrDefaultAsync();

            _repositoryPhoneNumberType.Remove(phoneNumberType);
            return new ResponseBase(message: "Tipo de número excluido com sucesso.");
        }
    }
}
