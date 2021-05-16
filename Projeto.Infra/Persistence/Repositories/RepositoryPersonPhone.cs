using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using Projeto.Infra.Persistence.Repositories.Base;
using System;

namespace Projeto.Infra.Persistence.Repositories
{
    public class RepositoryPersonPhone : RepositoryBase<PersonPhone>, IRepositoryPersonPhone
    {
        protected readonly ProjectContext _context;
        public RepositoryPersonPhone(ProjectContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
