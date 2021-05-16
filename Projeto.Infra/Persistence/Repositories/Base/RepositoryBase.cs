using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Projeto.Infra.Persistence.Repositories.Base
{
    public class RepositoryBase<TEntidade> : IRepositoryBase<TEntidade>
        where TEntidade : EntityBase
    {
        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;

        }

        public IQueryable<TEntidade> GetAll(bool asNoTracking = true, Func<IQueryable<TEntidade>, IIncludableQueryable<TEntidade, object>> includeProperties = null)
        {
            try
            {
                IQueryable<TEntidade> query = _context.Set<TEntidade>();

                if (includeProperties != null)
                {
                    query = includeProperties(query);
                }

                if (asNoTracking)
                {
                    return query.AsNoTracking();
                }

                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<TEntidade> GetAllAndOrderBy<TKey>(bool asNoTracking = true, Expression<Func<TEntidade, bool>> where = null, Expression<Func<TEntidade, TKey>> ordem = null, bool ascendente = true, Func<IQueryable<TEntidade>, IIncludableQueryable<TEntidade, object>> includeProperties = null)
        {
            return ascendente ? GetAllBy(asNoTracking, where, includeProperties).OrderBy(ordem) : GetAllBy(asNoTracking, where, includeProperties).OrderByDescending(ordem);
        }

        public IQueryable<TEntidade> GetAllBy(bool asNoTracking = true, Expression<Func<TEntidade, bool>> where = null, Func<IQueryable<TEntidade>, IIncludableQueryable<TEntidade, object>> includeProperties = null)
        {
            if (where == null) return GetAll(asNoTracking, includeProperties);

            return GetAll(asNoTracking, includeProperties).Where(where);
        }

        public IQueryable<TEntidade> GetAllOrderBy<TKey>(bool asNoTracking = true, Expression<Func<TEntidade, TKey>> ordem = null, bool ascendente = true, Func<IQueryable<TEntidade>, IIncludableQueryable<TEntidade, object>> includeProperties = null)
        {
            return ascendente ? GetAll(asNoTracking, includeProperties).OrderBy(ordem) : GetAll(asNoTracking, includeProperties).OrderByDescending(ordem);
        }

        public async Task<TEntidade> GetByIdAsync(string id, bool asNoTracking = true, Func<IQueryable<TEntidade>, IIncludableQueryable<TEntidade, object>> includeProperties = null)
        {
            if (includeProperties != null)
            {
                try
                {
                    return await GetAll(asNoTracking, includeProperties).FirstOrDefaultAsync(x => x.Id == id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            return await _context.Set<TEntidade>().FindAsync(id);
        }

        public async Task InsertAsync(TEntidade entidade)
        {
            await _context.Set<TEntidade>().AddAsync(entidade);
        }

        public async Task InsertListAsync(IEnumerable<TEntidade> entidades)
        {
            await _context.Set<TEntidade>().AddRangeAsync(entidades);
        }

        public void Remove(TEntidade entidade)
        {
            _context.Set<TEntidade>().Remove(entidade);
        }

        public void RemoveList(IEnumerable<TEntidade> entidades)
        {
            _context.Set<TEntidade>().RemoveRange(entidades);
        }

        public TEntidade Update(TEntidade entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;
            return entidade;
        }
    }
}
