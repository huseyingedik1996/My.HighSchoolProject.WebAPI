using My.HighSchoolProject.DataAccess.InterFaces.IRepositories;
using My.HighSchoolProject.DataAccess.Models2;
using My.HighSchoolProject.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly HighSchoolDatabaseContext _context;

        public Uow(HighSchoolDatabaseContext context)
        {
            _context = context;
        }

        public IRepositoryGeneral<T> GetRepository<T>() where T : class
        {
            return new RepositoryGeneral<T>(_context);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
