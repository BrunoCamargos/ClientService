using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Service.DTOs
{
	[DataContract(Name = "Response")]
	public class ResponseContract
	{
		[DataMember]
		public bool HasError { get; set; }

		[DataMember]
		public string ErrorMessage
		{
			get
			{
				return errorMessage;
			}
			set
			{
				HasError = true;
				errorMessage = value;
			}
		}	private string errorMessage;
	}
}