using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern;
using Project.Domain.Arguments.Base;
using Project.Domain.Arguments.PersonPhone;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using Project.Domain.Interfaces.Service;
using System.Threading.Tasks;

namespace Project.Domain.Services
{
    public class ServicePersonPhone : Notifiable, IServicePersonPhone
    {
        #region Constructor
        public ServicePersonPhone() { }

        public ServicePersonPhone(
           IRepositoryPersonPhone repositoryPersonPhone)
        {
            _repositoryPersonPhone = repositoryPersonPhone;
        }

        #endregion

        #region Properties
        private readonly IRepositoryPersonPhone _repositoryPersonPhone;
        #endregion

        public async Task<ResponseBase> CreateAsync(CreatePersonPhoneRequest request)
        {
            if (request == null)
            {
                AddNotification("PersonPhone", "O telefone pessoal é obrigatório.");
                return null;
            }

            var personPhone = new PersonPhone(request.PhoneNumber, request.PhoneNumberTypeID, request.PersonID);

            AddNotifications(personPhone);

            if (this.IsInvalid())
            {
                return null;
            }

            await _repositoryPersonPhone.InsertAsync(personPhone);
            return new ResponseBase() { Id = personPhone.Id };
        }

        public async Task<PersonPhoneResponse> GetByIdAsync(string id)
        {
            PersonPhone personPhone = await _repositoryPersonPhone.GetByIdAsync(id);

            if (personPhone == null)
            {
                AddNotification("PersonPhone", "O telefone pessoal não foi encontrado.");
                return null;
            }

            return (PersonPhoneResponse)personPhone;
        }

        public async Task<ResponseBase> AlterAsync(AlterPersonPhoneRequest request)
        {
            if (request == null)
            {
                AddNotification("PersonPhone", "O telefone pessoal é obrigatório.");
                return null;
            }

            PersonPhone personPhone = await _repositoryPersonPhone.GetByIdAsync(request.Id, false);

            if (personPhone == null)
            {
                AddNotification("PersonPhone", "O telefone pessoal não foi encontrado.");
                return null;
            }

            personPhone.Alter(request);

            AddNotifications(personPhone);

            if (this.IsInvalid())
            {
                return null;
            }

            _repositoryPersonPhone.Update(personPhone);
            return new ResponseBase();
        }

        public async Task<ResponseBase> Remove(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                AddNotification("Id", "O telefone pessoal não foi encontrado.");
                return null;
            }

            PersonPhone personPhone = await _repositoryPersonPhone.GetAllBy(true, x => x.Id == id).FirstOrDefaultAsync();

            _repositoryPersonPhone.Remove(personPhone);
            return new ResponseBase(message: "Telefone pessoal excluido com sucesso.");
        }
    }
}
