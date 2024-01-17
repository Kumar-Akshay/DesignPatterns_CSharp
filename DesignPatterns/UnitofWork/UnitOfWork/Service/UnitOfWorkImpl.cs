using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitofWork.Repository;
using UnitofWork.UnitofWork.Interface;

namespace UnitofWork.UnitofWork.Service
{
    public class UnitOfWorkImpl : IUnitOfWork
    {
        // delcare the dbContext
        private readonly AppDbContext _context;

        private Dictionary<Type, object> _repositories;


        public UnitOfWorkImpl(AppDbContext dbContext)
        {
            _context = dbContext;
            _repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
            {
                return (IGenericRepository<TEntity>)_repositories[typeof(TEntity)];
            }
            var repository = new GenericRepository<TEntity>(_context);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public void Commit()
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
