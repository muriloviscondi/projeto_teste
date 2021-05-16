using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using Projeto.Infra.Persistence.Repositories.Base;
using System;

namespace Projeto.Infra.Persistence.Repositories
{
    public class RepositoryPerson : RepositoryBase<Person>, IRepositoryPerson
    {
        protected readonly ProjectContext _context;
        public RepositoryPerson(ProjectContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
