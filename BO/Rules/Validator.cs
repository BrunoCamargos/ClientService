using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Rules
{
	/// <summary>
	/// Classe abstrata para as validações.
	/// </summary>
	public abstract class Validator
	{
		public string PropertyName { get; set; }
		public string ErrorMessage { get; set; }

		/// <summary>
		/// Construtor
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="errorMessage"></param>
		public Validator(string propertyName, string errorMessage)
		{
			PropertyName = propertyName;
			ErrorMessage = errorMessage;
		}

		/// <summary>
		/// Metodo de validação que deverá ser implementado nas classes especializadas
		/// </summary>
		/// <param name="businessObject"></param>
		/// <returns></returns>
		public abstract bool Validate(EntityBase entityBase);

		/// <summary>
		/// Pega o valor da propriedade da entidade usando reflection
		/// </summary>
		/// <param name="entityBase"></param>
		/// <returns></returns>
		protected object GetPropertyValue(EntityBase entityBase)
		{
			return entityBase.GetType().GetProperty(PropertyName).GetValue(entityBase, null);
		}
	}
}
