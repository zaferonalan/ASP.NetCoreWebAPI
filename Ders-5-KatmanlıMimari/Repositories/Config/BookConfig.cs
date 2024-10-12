using Ders_5_KatmanlıMimari.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ders_5_KatmanlıMimari.Repositories.Config
{
	public class BookConfig : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder.HasData(
				new Book { Id = 1, Title = "Karagöz Ve Hacıvat", Price = 75 },
				new Book { Id = 2, Title = "Mesnevi", Price = 175 },
				new Book { Id = 3, Title = "Devlet", Price = 375 });
		}
	}
}
