using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Rules
{
	public class ValidateDate : Validator
	{
		public ValidateDate(string propertyName) :
			base(propertyName, propertyName + " não é uma data válida.")
		{
		}

		public ValidateDate(string propertyName, string errorMessage) :
			base(propertyName, errorMessage)
		{
		}

		public override bool Validate(EntityBase entityBase)
		{
			try
			{
				DateTime dtNacimento = DateTime.Parse(GetPropertyValue(entityBase).ToString());
				return dtNacimento < DateTime.Now && dtNacimento > DateTime.Now.AddYears(-120);
			}
			catch 
			{ 
				return false; 
			}
		}
	}
}
