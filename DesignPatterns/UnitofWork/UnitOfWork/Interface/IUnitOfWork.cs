using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitofWork.Repository;

namespace UnitofWork.UnitofWork.Interface
{
    public interface IUnitOfWork
    {
        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        public void Commit();
        public void Dispose();
    }
}
