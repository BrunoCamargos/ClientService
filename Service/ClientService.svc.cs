using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using BLL;
using BO;
using Service.DTOs;

namespace Service
{
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	public class ClientService : IClientService
	{
		public ResponseContract RegisterClient(ClientDTO client)
		{
			ResponseContract response = new ResponseContract();

			try
			{
				Client newClient = client.MapTo();
				ClientBusiness clientBLL = new ClientBusiness();

				string error = clientBLL.RegisterClient(newClient);

				if (!string.IsNullOrWhiteSpace(error))
					response.ErrorMessage = error;
			}
			catch (Exception ex)
			{
				response.ErrorMessage = ex.Message;
			}

			return response;
		}
	}
}
