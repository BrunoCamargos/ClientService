using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace Service.DTOs
{
	public interface IMapper<TDTO, TEntity>
		where TDTO : IDTO<TEntity>
		where TEntity : EntityBase, new()
	{
		TEntity MapTo(TDTO dto);

		void MapFrom(TEntity entity, TDTO dto);
	}
}
