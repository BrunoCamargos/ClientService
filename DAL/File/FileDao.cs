using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace DAL.File
{
	public abstract class FileDao<TEntity> : IDao<TEntity> where TEntity : EntityBase, new()
	{
		// Dicionario contendo o nome da propriedade e o tamanho que irá ocupar no arquivo
		private readonly Dictionary<string, int> _propertiesLength = new Dictionary<string, int>();
		// Tamanho do espaço entre cada propriedade
		private readonly int _separatorLength = 2;
		// Classe responsável por acessar o arquivo
		private FileAdapter _fileAdapter;
		protected FileAdapter FileAdapter
		{
			get
			{
				return _fileAdapter;
			}
		}

		/// <summary>
		/// Instancia a classe de acesso ao arquivo.
		/// </summary>
		/// <param name="fileName"></param>
		protected void CreateFileAdapter(string fileName)
		{
			// Adiciona 2 espaços entre cada propriedade
			long recordLength = _propertiesLength.Sum(x => x.Value + _separatorLength);

			// Remove o último espaço
			recordLength -= _separatorLength;

			if (_fileAdapter == null)
				_fileAdapter = new FileAdapter(recordLength, fileName);
		}

		protected void AddPropertyLength(string key, int value)
		{
			_propertiesLength.Add(key, value);
		}

		public void Insert(TEntity entity)
		{
			try
			{
				FileAdapter.OpenFile();
				FileAdapter.Insert(GetData(entity));
			}
			catch (Exception ex)
			{
				FileAdapter.CloseFile(false);
				throw ex;
			}
		}

		public IList<TEntity> GetAll()
		{
			try
			{
				FileAdapter.OpenFile();
				string[] recordArray = FileAdapter.GetRecords();

				List<TEntity> ClientList = new List<TEntity>(recordArray.Length);

				int id = 1;
				TEntity client;
				foreach (string data in recordArray)
				{
					client = GetClient(data);
					client.ID = id;

					ClientList.Add(client);
					id++;
				}

				return ClientList;
			}
			catch (Exception ex)
			{
				FileAdapter.CloseFile(false);
				throw ex;
			}
		}

		public void Delete(TEntity entity)
		{
			try
			{
				FileAdapter.OpenFile();
				FileAdapter.Delete(entity.ID);
			}
			catch (Exception ex)
			{
				FileAdapter.CloseFile(false);
				throw ex;
			}
		}

		public void Update(TEntity entity)
		{
			try
			{
				FileAdapter.OpenFile();
				FileAdapter.Update(entity.ID, GetData(entity));
			}
			catch (Exception ex)
			{
				FileAdapter.CloseFile(false);
				throw ex;
			}
		}

		public int Save()
		{
			return FileAdapter.CloseFile(true);
		}

		/// <summary>
		/// Transforma a entidade em uma string representando um registro
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		protected string GetData(TEntity entity)
		{
			string data = string.Empty;
			object value;
			foreach (KeyValuePair<string, int> keyValue in _propertiesLength)
			{
				value = entity.GetType().GetProperty(keyValue.Key).GetValue(entity, null);
				data += (value != null ? value.ToString().PadRight(keyValue.Value).Substring(0, keyValue.Value) : string.Empty.PadRight(keyValue.Value)) + string.Empty.PadRight(_separatorLength);
			}

			// Remove o último separador
			data = data.Substring(0, data.Length - _separatorLength);

			return data;
		}

		/// <summary>
		/// Popula e retorna a entidade
		/// </summary>
		/// <param name="data">Registro contendo os valores da entidade</param>
		/// <returns></returns>
		protected TEntity GetClient(string data)
		{
			TEntity client = new TEntity();
			object value;
			foreach (KeyValuePair<string, int> keyValue in _propertiesLength)
			{
				value = data.Substring(0, keyValue.Value).Trim();
				data = data.Remove(0, keyValue.Value + _separatorLength);

				PropertyInfo propertyInfo = client.GetType().GetProperty(keyValue.Key);
				propertyInfo.SetValue(client, Convert.ChangeType(value, propertyInfo.PropertyType), null);
			}

			return client;
		}
	}
}
