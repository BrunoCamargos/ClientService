using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityFramework
{
	public class EFDaoFactory : IDaoFactory
	{
		public IClientDao GetClientDao()
		{
			return new EFClientDao();
		}
	}
}
