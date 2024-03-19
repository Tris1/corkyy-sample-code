using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Entities;

namespace ToDoListAPI.Context
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<ToDoNoteEntity> ToDoNotes { get; set; }
	}
}
