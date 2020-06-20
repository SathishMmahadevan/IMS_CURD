using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace IMS_CURD.Data
{
    public class InventoryContext : DbContext
	{
		public InventoryContext(DbContextOptions<InventoryContext> options)
			: base(options) { }
		public InventoryContext() { }
		public DbSet<Inventory> InventoryMaster { get; set; }
	}
}
