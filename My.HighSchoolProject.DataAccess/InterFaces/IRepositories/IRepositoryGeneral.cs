using My.HighSchoolProject.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.DataAccess.InterFaces.IRepositories
{
    public interface IRepositoryGeneral<T> where T : class
    {
        Task<List<T>> GetAll();

        Task<T> GetById(object id);

        Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false);

        Task Create(T entity);

        void Update(T entity, T unchanged);

        void Remove(T entity);

        IQueryable<T> GetQuery();
    }
}
