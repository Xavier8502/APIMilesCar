using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MilesCar.Dominio;

namespace MilesCar.Infraestructura.Datos.Configs
{
    class LocalidadConfig : IEntityTypeConfiguration<Localidad>
    {
        public void Configure(EntityTypeBuilder<Localidad> builder)
        {
            builder.ToTable(nameof(Localidad));
            builder.HasKey(c => c.id);


        }
    }
}
