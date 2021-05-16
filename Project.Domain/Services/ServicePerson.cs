using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using prmToolkit.NotificationPattern;
using Project.Domain.Arguments.Base;
using Project.Domain.Arguments.Person;
using Project.Domain.Entities;
using Project.Domain.Extensions;
using Project.Domain.Interfaces.Repositories;
using Project.Domain.Interfaces.Service;
using Project.Domain.Utils;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project.Domain.Services
{
    public class ServicePerson : Notifiable, IServicePerson
    {
        #region Constructor
        public ServicePerson() { }

        public ServicePerson(
           IRepositoryPerson repositoryPerson)
        {
            _repositoryPerson = repositoryPerson;
        }

        #endregion

        #region Properties
        private readonly IRepositoryPerson _repositoryPerson;
        #endregion

        public async Task<ResponseBase> CreateAsync(CreatePersonRequest request)
        {
            if (request == null)
            {
                AddNotification("Person", "Os dados da pessoa é obrigatório.");
                return null;
            }

            var person = new Person(request.Name);

            AddNotifications(person);

            if (this.IsInvalid())
            {
                return null;
            }

            await _repositoryPerson.InsertAsync(person);
            return new ResponseBase() { Id = person.Id };
        }

        public async Task<PersonResponse> GetByIdAsync(string id)
        {
            Person person = await _repositoryPerson.GetByIdAsync(id);

            if (person == null)
            {
                AddNotification("Person", "A pessoa não foi encontrada.");
                return null;
            }

            return (PersonResponse)person;
        }

        public async Task<Paginated<PersonListsResponse, Person>> GetAllByPersonAsync(int? pageNumber)
        {
            Func<IQueryable<Person>, IIncludableQueryable<Person, object>> includes = s => s
                           .Include(phone => phone.Phones)
                            .ThenInclude(phone => phone.PhoneNumberType.Name);

            Expression<Func<Person, bool>> where = a => a.Name.Any();

            var persons = _repositoryPerson.GetAllAndOrderBy(includeProperties: includes, where: where, ordem: p => p.Name);
            return await Paginated<PersonListsResponse, Person>.CreateAsync(persons, pageNumber ?? 1, 10);
        }

        public async Task<ResponseBase> AlterAsync(AlterPersonRequest request)
        {
            if (request == null)
            {
                AddNotification("Person", "Os dados da pessoa é obrigatório.");
                return null;
            }

            Person person = await _repositoryPerson.GetByIdAsync(request.Id, false);

            if (person == null)
            {
                AddNotification("Person", "Pessoa não encontrada.");
                return null;
            }

            person.Alter(request);

            AddNotifications(person);

            if (this.IsInvalid())
            {
                return null;
            }

            _repositoryPerson.Update(person);
            return new ResponseBase();
        }

        public async Task<ResponseBase> Remove(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                AddNotification("Id", "Pessoa não encontrada.");
                return null;
            }

            Person person = await _repositoryPerson.GetAllBy(true, x => x.Id == id).FirstOrDefaultAsync();

            _repositoryPerson.Remove(person);
            return new ResponseBase(message: "Pessoa excluida com sucesso.");
        }
    }
}
