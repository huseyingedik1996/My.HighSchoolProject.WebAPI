using Microsoft.EntityFrameworkCore;
using My.HighSchoolProject.DataAccess.InterFaces.IRepositories;
using My.HighSchoolProject.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.DataAccess.Repositories
{
    public class RepositoryGeneral<T> : IRepositoryGeneral<T> where T : class
    {
        private readonly HighSchoolDatabaseContext _context;

        public RepositoryGeneral(HighSchoolDatabaseContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            
        }

        public async Task<List<T>> GetAll()
        {
            var list = await _context.Set<T>().ToListAsync();
            return list;
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return asNoTracking ? await _context.Set<T>().SingleOrDefaultAsync(filter) : await _context.Set<T>
                ().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T> GetById(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity, T unchanged)
        {
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
        }
    }
}
