using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace DAL.File
{
	public class FileClientDao : FileDao<Client>, IClientDao
	{
		public FileClientDao()
		{
			AddPropertyLength("Nome", 80);
			AddPropertyLength("Email", 50);
			AddPropertyLength("DataNascimento", 10);
			AddPropertyLength("TelefoneCelular", 12);
			AddPropertyLength("TelefoneResidencial", 12);
			// App_Data diretório
			string appDataDiretorio = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
			this.CreateFileAdapter(appDataDiretorio + "\\" + "ClientFile.txt");
		}

		public void Delete(int id)
		{
			try
			{
				FileAdapter.OpenFile();
				FileAdapter.Delete(id);
			}
			catch (Exception ex)
			{
				FileAdapter.CloseFile(false);
				throw ex;
			}
		}

		public void Delete(string nome)
		{
			foreach (var item in this.GetAll().Where(x => x.Nome == nome))
			{
				this.Delete(item);
			}
		}
	}
}
