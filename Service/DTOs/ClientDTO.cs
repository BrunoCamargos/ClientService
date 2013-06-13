using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using BO;

namespace Service.DTOs
{
	[DataContract(Name = "Client")]
	public class ClientDTO : IDTO<Client>
	//public class ClientDTO : DTO<Client>
	{
		[DataMember]
		public string Nome { get; set; }

		[DataMember]
		public string Email { get; set; }

		[DataMember]
		public string DataNascimento { get; set; }

		[DataMember]
		public string TelefoneCelular { get; set; }

		[DataMember]
		public string TelefoneResidencial { get; set; }

		public Client MapTo()
		{
			Client entity = new Client()
			{
				Nome = this.Nome,
				Email = this.Email,
				DataNascimento = this.DataNascimento,
				TelefoneCelular = this.TelefoneCelular,
				TelefoneResidencial = this.TelefoneResidencial
			};

			return entity;
		}

		public void MapFrom(Client entity)
		{
			this.Nome = entity.Nome;
			this.Email = entity.Email;
			this.DataNascimento = entity.DataNascimento;
			this.TelefoneCelular = entity.TelefoneCelular;
			this.TelefoneResidencial = entity.TelefoneResidencial;
		}
	}


}