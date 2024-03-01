using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MilesCar.Dominio;
using MilesCar.Infraestructura.Datos.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCar.Infraestructura.Datos.Contextos
{
    public class MyDbContext : DbContext
    {
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<Sede> Sedes { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set;}
        public DbSet<VehiculosXSede> VehiculosXSedes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog = MilesCar;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new LocalidadConfig());
            modelBuilder.ApplyConfiguration(new SedeConfig());
            modelBuilder.ApplyConfiguration(new VehiculoConfig());
            modelBuilder.ApplyConfiguration(new VehiculoXSedeConfig());

        }
    }
}
