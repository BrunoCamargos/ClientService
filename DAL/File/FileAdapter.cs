using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.File
{
	public class FileAdapter : IDisposable
	{
		#region Variaveis Internas

		private FileStream _file = null;
		private string _fileName;
		// Tamanho do registro (linha)
		private long _recordLength;
		private int _recordsCount;
		private int _affectedRecords;

		#endregion

		#region Construtor da Classe

		/// <summary>
		/// Instanciar objeto de manipulacao de arquivos texto planos com tamanho fixo por registro     
		/// </summary>
		/// <param name="recordLength">Tamanho do registro em bytes</param>
		/// <param name="fileName">Nome do arquivo</param>
		public FileAdapter(long recordLength, string fileName)
		{
			// Incluído 2 bytes do Environment.NewLine
			_recordLength = recordLength + Environment.NewLine.Length;
			_recordsCount = 0;
			this._fileName = fileName;
		}

		#endregion

		#region Metodos

		/// <summary>
		/// Abre o arquivo
		/// </summary>
		/// <returns>true se bem sucedido, false se ocorreu erro</returns>
		public bool OpenFile()
		{
			try
			{
				if (_file == null)
				{
					_file = new FileStream(_fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

					if (_file.Length > 0)
					{
						_recordsCount = (int)(_file.Length / _recordLength);
					}
					else
					{
						_recordsCount = 0;
					}
				}

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// Efetuar a leitura de um registro do arquivo
		/// </summary>
		/// <param name="recordID">Numero do registro a ser lido (1 a N)</param>
		/// <returns></returns>
		public string GetRecord(int recordID)
		{
			string temp = "";
			byte[] buffer = new byte[_recordLength];
			int count = 0;

			if (recordID > 0)
				_file.Position = (recordID - 1) * _recordLength;
			else
				_file.Position = 0;

			count = _file.Read(buffer, 0, buffer.Length);
			temp = System.Text.UTF8Encoding.Default.GetString(buffer, 0, count);

			return temp;
		}

		/// <summary>
		/// Efetuar a leitura de um registro do arquivo
		/// </summary>
		/// <returns></returns>
		public string[] GetRecords()
		{
			string[] records;
			if (_recordsCount > 0)
				records = new string[_recordsCount];
			else
				return new string[0];

			byte[] buffer = new byte[_recordLength];
			int count = 0;
			_file.Position = 0;

			while (_file.Position < _file.Length)
			{
				records[count] = System.Text.UTF8Encoding.Default.GetString(buffer, 0, _file.Read(buffer, 0, buffer.Length));
				count++;
			}

			return records;
		}

		/// <summary>
		/// Alterar o conteudo de um arquivo com registros de tamanho fixo em disco.    
		/// </summary>
		/// <param name="recordID">Numero do registro a ser alterado (1 ate N)</param>
		/// <param name="data">Conteudo a escrever no arquivo</param>
		/// <returns></returns>
		public bool Update(int recordID, string data)
		{
			byte[] temp = null;

			if (recordID > 0)
				_file.Position = (recordID - 1) * _recordLength;
			else
				_file.Position = 0;

			temp = System.Text.UTF8Encoding.Default.GetBytes(data);
			_file.Write(temp, 0, temp.Length);

			_affectedRecords++;

			return true;
		}

		/// <summary>
		/// Exclui o registro de um arquivo com registros de tamanho fixo em disco.    
		/// </summary>
		/// <param name="recordID">Numero do registro a ser alterado (1 ate N)</param>
		/// <returns></returns>
		public bool Delete(int recordID)
		{
			if (recordID > 0)
				_file.Position = (recordID - 1) * _recordLength;
			else
				_file.Position = 0;

			byte[] firstBlock = new byte[_file.Position];
			_file.Position = 0;
			_file.Read(firstBlock, 0, firstBlock.Length);

			// O segundo bloco será todo o documento restante - o primeiro bloco e - o tamanho do registro a excluir
			byte[] secondBlock = new byte[_file.Length - _recordLength - firstBlock.Length];
			_file.Position += _recordLength;
			_file.Read(secondBlock, 0, secondBlock.Length);

			_file.Position = 0;
			_file.SetLength(firstBlock.Length + secondBlock.Length);
			_file.Write(firstBlock, 0, firstBlock.Length);
			_file.Write(secondBlock, 0, secondBlock.Length);

			_recordsCount--;
			_affectedRecords++;

			return true;
		}

		/// <summary>
		/// Insere um novo registro no arquivo.
		/// </summary>
		/// <param name="position">Posicao do registro a ser gravado, informe -1 para
		/// inserir uma linha no final do arquivo
		/// </param>
		/// <param name="data">Informacoes a serem gravadas</param>
		/// <returns></returns>
		public bool Insert(string data)
		{
			return Insert(-1, data);
		}

		/// <summary>
		/// Insere um novo registro no arquivo.
		/// </summary>
		/// <param name="position">Posicao do registro a ser gravado, informe -1 para
		/// inserir uma linha no final do arquivo
		/// </param>
		/// <param name="data">Informacoes a serem gravadas</param>
		/// <returns></returns>
		public bool Insert(int position, string data)
		{
			byte[] temp = null;
			string buffer = "";

			if (data.Length < _recordLength)
			{
				buffer = data.PadRight((int)_recordLength - 2, ' ');
				buffer = buffer + Environment.NewLine;
			}
			else
			{
				buffer = data.Substring(0, (int)_recordLength - 2);
				buffer = buffer + Environment.NewLine;
			}

			if (position == 0)
				position = 1;

			if (position == -1)
				_file.Position = _file.Length;
			else
				_file.Position = (position - 1) * _recordLength;

			temp = System.Text.UTF8Encoding.Default.GetBytes(buffer);
			_file.Write(temp, 0, temp.Length);
			_affectedRecords++;
			_recordsCount++;

			return true;
		}

		/// <summary>
		/// Fecha o arquivo e opcionalmente efetua flush no mesmo
		/// </summary>
		public int CloseFile(bool flush)
		{
			int affectedRecords = _affectedRecords;
			_affectedRecords = 0;

			if (flush)
			{
				_file.Flush();
				return affectedRecords;
			}

			if (_file != null)
			{
				_file.Close();
			}

			return 0;
		}

		#endregion

		#region IDisposable Members

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposing) return;

			if (_file != null)
			{
				CloseFile(true);
				_file.Dispose();
				_file = null;
			}
		}

		#endregion
	}
}
