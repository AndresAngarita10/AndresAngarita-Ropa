
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class VentaConfiguration : IEntityTypeConfiguration<Venta>
{
    public void Configure(EntityTypeBuilder<Venta> builder)
    {

        builder.ToTable("venta");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
        .IsRequired();

        
        builder.Property(p => p.Fecha)
        .HasColumnName("fecha")
        .HasColumnType("date")
        .IsRequired();

        builder.HasOne(p => p.Empleado)
        .WithMany(p => p.Ventas)
        .HasForeignKey(p => p.IdEmpleado);

        builder.HasOne(p => p.Cliente)
        .WithMany(p => p.Ventas)
        .HasForeignKey(p => p.IdCliente);

        builder.HasOne(p => p.FormaPago)
        .WithMany(p => p.Ventas)
        .HasForeignKey(p => p.IdFormaPago);
    }
}
