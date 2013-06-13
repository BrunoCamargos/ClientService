using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace DAL.EntityFramework
{
	public abstract class EFDaoBase<TEntity> : IDao<TEntity> where TEntity : EntityBase, new()
	{
		protected DbSet<TEntity> _dbSet;
		protected DbContext Context
		{
			get
			{
				return ContextManager.GetInstance().Context;
			}
		}
				
		public EFDaoBase()
		{
			_dbSet = Context.Set<TEntity>();
		}

		public void Insert(TEntity entity)
		{
			_dbSet.Add(entity);
		}

		public void Delete(TEntity entity)
		{
			if (Context.Entry(entity).State == EntityState.Detached)
				_dbSet.Attach(entity);

			_dbSet.Remove(entity);
		}

		public void Update(TEntity entity)
		{
			if (Context.Entry(entity).State == EntityState.Detached)
				_dbSet.Attach(entity);
		}

		public IList<TEntity> GetAll()
		{
			return _dbSet.ToList();
		}

		public int Save()
		{
			return Context.SaveChanges();
		}
	}
}
