using Ders_4_EfCore.Models;
using Ders_4_EfCore.Repositories.Config;
using Microsoft.EntityFrameworkCore;

namespace Ders_4_EfCore.Repositories
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
