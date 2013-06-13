using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace Service.DTOs
{
	public interface IDTO<TEntity>
		where TEntity : EntityBase, new()
	{
		TEntity MapTo();

		void MapFrom(TEntity entity);
	}
}
