using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public interface IDao<TEntity>
	{
		void Insert(TEntity entity);
		void Delete(TEntity entity);
		void Update(TEntity entity);
		IList<TEntity> GetAll();
		int Save();
	}
}
