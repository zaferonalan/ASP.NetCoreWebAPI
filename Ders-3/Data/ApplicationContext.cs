using Ders_3.Models;

namespace Ders_3.Data
{
	public static class ApplicationContext
	{
		public static List<Book> Books { get; set; }

        static ApplicationContext()
        {
            Books = new List<Book>()
            {
                new Book() { Id = 1, Title = "Hacıvat Ve Karagöz", Price = 100  },
                new Book() { Id = 2, Title = "Mesnevi", Price = 75 },
                new Book() { Id = 3, Title = "Dede Korkut", Price = 75}
            };
        }


    }
}
