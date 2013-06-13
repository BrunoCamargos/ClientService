using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityFramework
{
	sealed public class ContextManager
	{
		private static readonly ContextManager _instance = new ContextManager();

		private ContextManager() { }

		public static ContextManager GetInstance()
		{
			return _instance;
		}

		private static readonly DbContext context = new Contexto();
		public DbContext Context { get { return context; } }
	}
}
