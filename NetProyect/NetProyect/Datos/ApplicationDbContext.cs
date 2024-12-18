using System;
using NetProyect.Models;
using Microsoft.EntityFrameworkCore;

namespace NetProyect.Datos
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
		}

		//Aqui agregar los modelos de la bd, (tablas)
		public DbSet<Contacto> Contacto { get; set; }



	}
}

