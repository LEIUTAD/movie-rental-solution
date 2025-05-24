using Microsoft.EntityFrameworkCore;
using MovieRental.Models;

namespace MovieRental.Data
{
    public class MovieRentalDbContext : DbContext
	{
		public DbSet<Movie> Movies { get; set; }
		public DbSet<Rental> Rentals { get; set; }
        public DbSet<Customer> Customers { get; set; }

        private string DbPath { get; }

		public MovieRentalDbContext()
		{
			var folder = Environment.SpecialFolder.LocalApplicationData;
			var path = Environment.GetFolderPath(folder);
			DbPath = System.IO.Path.Join(path, "movierental.db");
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlite($"Data Source={DbPath}");
	}
}
