
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class DetalleOrdenConfiguration : IEntityTypeConfiguration<DetalleOrden>
{
    public void Configure(EntityTypeBuilder<DetalleOrden> builder)
    {

        builder.ToTable("detalleOrden");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
        .IsRequired();

        builder.Property(e => e.CantidadProducir)
        .HasColumnName("cantidadProducir")
        .HasColumnType("int")
        .HasMaxLength(3)
        .IsRequired();
        
        builder.Property(e => e.CantidadProducida)
        .HasColumnName("cantidadProducida")
        .HasColumnType("int")
        .HasMaxLength(3)
        .IsRequired();

        builder.HasOne(p => p.Orden)
        .WithMany(p => p.DetalleOrdenes)
        .HasForeignKey(p => p.IdOrden);

        builder.HasOne(p => p.Prenda)
        .WithMany(p => p.DetalleOrdenes)
        .HasForeignKey(p => p.IdPrenda);
        
        builder.HasOne(p => p.Color)
        .WithMany(p => p.DetalleOrdenes)
        .HasForeignKey(p => p.IdColor);

        builder.HasOne(p => p.Estado)
        .WithMany(p => p.DetalleOrdenes)
        .HasForeignKey(p => p.IdEstado);

    }
}

