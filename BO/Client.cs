using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO.Rules;

namespace BO
{
	public class Client : EntityBase
	{
		public Client()
		{
			this.AddValidator(new ValidateEmail("Email", "O E-mail informado não é válido."));
			this.AddValidator(new ValidateDate("DataNascimento", "A Data de Nascimento não é válida."));
		}

		public Client(string nome, string email, string dataNascimento, string telefoneCelular, string telefoneResidencial)
			: this()
		{
			this.Nome = nome;
			this.Email = email;
			this.DataNascimento = dataNascimento;
			this.TelefoneCelular = telefoneCelular;
			this.TelefoneResidencial = telefoneResidencial;
		}

		public string Nome { get; set; }
		public string Email { get; set; }
		public string DataNascimento { get; set; }
		public string TelefoneCelular { get; set; }
		public string TelefoneResidencial { get; set; }
	}
}
