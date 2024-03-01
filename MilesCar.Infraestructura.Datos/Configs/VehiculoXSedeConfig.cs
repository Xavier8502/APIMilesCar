using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MilesCar.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MilesCar.Infraestructura.Datos.Configs
{
    internal class VehiculoXSedeConfig : IEntityTypeConfiguration<VehiculosXSede>
    {
           public void Configure(EntityTypeBuilder<VehiculosXSede> builder)
        {
            builder.ToTable(nameof(VehiculosXSede));
            builder.HasKey(c => new { c.vehiculoId, c.sedeId });

          
        }
    }
}
