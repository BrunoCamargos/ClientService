using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BO;

namespace BLL
{
	public class ClientBusiness
	{
		public string RegisterClient(Client client)
		{
			RegisterClient(client, DaoFactoryType.EntityFramework | DaoFactoryType.File);

			return GetErros(client);
		}

		private void RegisterClient(Client client, DaoFactoryType factoryType)
		{
			IDaoFactory daoFactory;
			ClientManager manager;

			if (factoryType.HasFlag(DaoFactoryType.EntityFramework))
			{
				daoFactory = DaoFactories.GetFactory(DaoFactoryType.EntityFramework);
				manager = new ClientManager(daoFactory);

				manager.InsertClient(client);
			}

			if (factoryType.HasFlag(DaoFactoryType.File))
			{
				daoFactory = DaoFactories.GetFactory(DaoFactoryType.File);
				manager = new ClientManager(daoFactory);

				manager.InsertClient(client);
			}
		}

		private string GetErros(EntityBase entity)
		{
			string errors = string.Empty;

			if (!entity.Validate())
			{
				foreach (string error in entity.ValidationErrors)
					errors += error + Environment.NewLine;
			}

			return errors;
		}
	}
}
