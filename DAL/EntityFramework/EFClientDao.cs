using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace DAL.EntityFramework
{
	public class EFClientDao : EFDaoBase<Client>, IClientDao
	{
		public void Delete(int id)
		{
			Client client = _dbSet.Find(id);

			if (client != null)
				this.Delete(client);
		}

		public void Delete(string nome)
		{
			var clients = _dbSet.Where(x => x.Nome == nome);

			foreach (Client client in clients)
				this.Delete(client);
		}
	}
}
