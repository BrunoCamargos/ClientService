using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BO;

namespace BLL
{
	public class ClientManager
	{
		private readonly IDaoFactory daoFactory;
		IClientDao clientDao;

		public ClientManager(IDaoFactory daoFactory)
		{
			this.daoFactory = daoFactory;
			clientDao = daoFactory.GetClientDao();
		}

		public int InsertClient(Client client)
		{
			clientDao.Insert(client);
			return clientDao.Save();
		}

		public int DeleteClient(int id)
		{
			clientDao.Delete(id);
			return clientDao.Save();
		}

		public int DeleteClient(string nome)
		{
			clientDao.Delete(nome);
			return clientDao.Save();
		}
	}
}
