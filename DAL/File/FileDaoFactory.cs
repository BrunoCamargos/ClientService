using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.File
{
	public class FileDaoFactory : IDaoFactory
	{
		public IClientDao GetClientDao()
		{
			return new FileClientDao();
		}
	}
}
