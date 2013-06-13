using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace DAL
{
	public interface IClientDao : IDao<Client>
	{
		void Delete(int id);
		void Delete(string nome);
	}
}
