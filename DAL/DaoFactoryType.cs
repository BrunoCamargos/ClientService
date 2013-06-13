using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	/// <summary>
	/// Tipo de persistência utilizado para gerar objetos DAO
	/// </summary>
	public enum DaoFactoryType
	{
		EntityFramework = 2,
		File = 4
	}
}
