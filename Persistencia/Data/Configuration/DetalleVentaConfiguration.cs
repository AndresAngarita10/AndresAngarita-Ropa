
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
{
    public void Configure(EntityTypeBuilder<DetalleVenta> builder)
    {

        builder.ToTable("detalleVenta");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
        .IsRequired();

        builder.Property(e => e.Cantidad)
        .HasColumnName("cantidad")
        .HasColumnType("int")
        .HasMaxLength(3)
        .IsRequired();
        
        builder.Property(e => e.ValorUnitario)
        .HasColumnName("valorUnitario")
        .HasColumnType("double")
        .IsRequired();
        
        builder.HasOne(p => p.Venta)
        .WithMany(p => p.DetalleVentas)
        .HasForeignKey(p => p.IdVenta);

        builder.HasOne(p => p.Producto)
        .WithMany(p => p.DetalleVentas)
        .HasForeignKey(p => p.IdProducto);

        builder.HasOne(p => p.Talla)
        .WithMany(p => p.DetalleVentas)
        .HasForeignKey(p => p.IdTalla);

    }
}
