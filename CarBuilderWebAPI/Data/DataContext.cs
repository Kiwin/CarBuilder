using CarBuilderWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarBuilderWebAPI.Data
{
	public class DataContext : DbContext
	{
		public DbSet<CarPart> CarParts { get; set; }
		public DbSet<CarPartCategory> CarPartCategories { get; set; }

		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}
	}
}
