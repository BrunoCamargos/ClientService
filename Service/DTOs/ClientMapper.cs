using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BO;

namespace Service.DTOs
{
	public class ClientMapper : IMapper<ClientDTO, Client>
	{
		public Client MapTo(ClientDTO dto)
		{
			Client entity = new Client()
			{
				Nome = dto.Nome,
				Email = dto.Email,
				DataNascimento = dto.DataNascimento,
				TelefoneCelular = dto.TelefoneCelular,
				TelefoneResidencial = dto.TelefoneResidencial
			};

			return entity;
		}

		public void MapFrom(Client entity, ClientDTO dto)
		{
			dto.Nome = entity.Nome;
			dto.Email = entity.Email;
			dto.DataNascimento = entity.DataNascimento;
			dto.TelefoneCelular = entity.TelefoneCelular;
			dto.TelefoneResidencial = entity.TelefoneResidencial;
		}
	}
}