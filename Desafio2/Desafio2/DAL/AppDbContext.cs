using Desafio2.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio2.DAL
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
	   : base(options)
		{
		}
		public virtual DbSet<ToDoList> Tarefas { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ToDoList>(entity =>
			{
				entity.Property(x => x.Titulo).IsUnicode(false);
				entity.Property(x => x.Descricao).IsUnicode(false);
			});
		}
	}
}
