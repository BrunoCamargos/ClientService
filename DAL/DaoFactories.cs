using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class DaoFactories
	{
		/// <summary>
		/// Retorna o factory desejado
		/// </summary>
		/// <param name="daoFactoryType"></param>
		/// <returns>DAO Factory</returns>
		public static IDaoFactory GetFactory(DaoFactoryType daoFactoryType)
		{
			switch (daoFactoryType)
			{
				case DaoFactoryType.EntityFramework: return new DAL.EntityFramework.EFDaoFactory();
				case DaoFactoryType.File: return new DAL.File.FileDaoFactory();

				default: return new DAL.EntityFramework.EFDaoFactory();
			}
		}
	}
}
