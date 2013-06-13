using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BO;


namespace DAL.EntityFramework
{
	public class Contexto : DbContext
	{
		public DbSet<Client> Clients { get; set; }
	}
}
