using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO.Rules;

namespace BO
{
	/// <summary>
	/// Classe abstrata para as entidades
	/// </summary>
	public abstract class EntityBase
	{
		public int ID { get; set; }
		//Lista de validadores
		private List<Validator> _validators = new List<Validator>();

		//Lista de erros
		private List<string> _validationErrors = new List<string>();

		public List<string> ValidationErrors
		{
			get { return _validationErrors; }
		}

		/// <summary>
		/// Adiciona validadores à entidade
		/// </summary>
		/// <param name="rule"></param>
		protected void AddValidator(Validator rule)
		{
			_validators.Add(rule);
		}

		/// <summary>
		/// Valida a entidade.
		/// </summary>
		/// <returns></returns>
		public bool Validate()
		{
			bool isValid = true;

			_validationErrors.Clear();

			foreach (Validator validator in _validators)
			{
				if (!validator.Validate(this))
				{
					isValid = false;
					_validationErrors.Add(validator.ErrorMessage);
				}
			}
			return isValid;
		}
	}
}
