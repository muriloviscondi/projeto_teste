using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using Projeto.Infra.Persistence.Repositories.Base;
using System;

namespace Projeto.Infra.Persistence.Repositories
{
    public class RepositoryPhoneNumberType : RepositoryBase<PhoneNumberType>, IRepositoryPhoneNumberType
    {
        protected readonly ProjectContext _context;
        public RepositoryPhoneNumberType(ProjectContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
