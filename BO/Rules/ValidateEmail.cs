using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BO.Rules
{
	/// <summary>
	/// Email validation rule.
	/// </summary>
	public class ValidateEmail : Validator
	{
		protected readonly string Pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

		public ValidateEmail(string propertyName) :
			base(propertyName, propertyName + " não é um e-mail válido")
		{
		}

		public ValidateEmail(string propertyName, string errorMessage) :
			base(propertyName, errorMessage)
		{
		}

		public override bool Validate(EntityBase entityBase)
		{
			return Regex.Match(GetPropertyValue(entityBase).ToString(), Pattern).Success;
		}
	}
}
