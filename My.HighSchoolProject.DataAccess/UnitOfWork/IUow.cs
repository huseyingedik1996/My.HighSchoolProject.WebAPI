using My.HighSchoolProject.DataAccess.InterFaces.IRepositories;
using My.HighSchoolProject.DataAccess.Models2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.DataAccess.UnitOfWork
{
    public interface IUow
    {
        IRepositoryGeneral<T> GetRepository<T>() where T : class;

        Task SaveChanges();
    }
}
