using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookStore.DataAccess
{
	public class BookStoreDbContext : DbContext
	{
		public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
		: base(options)
		{
		}
		public DbSet<BookEntity> Books { get; set; }
		public DbSet<UserEntity> Users { get; set; }

	}
}
