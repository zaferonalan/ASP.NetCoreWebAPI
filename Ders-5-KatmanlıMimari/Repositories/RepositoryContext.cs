using Ders_5_KatmanlıMimari.Models;
using Ders_5_KatmanlıMimari.Repositories.Config;
using Microsoft.EntityFrameworkCore;

namespace Ders_5_KatmanlıMimari.Repositories
{
	public class RepositoryContext : DbContext
	{
		public RepositoryContext(DbContextOptions options): base(options) 
		{
			
		}

		public DbSet<Book> Books { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new BookConfig());
		}

	}
}
