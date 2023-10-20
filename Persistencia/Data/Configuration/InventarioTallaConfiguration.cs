
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class InventarioTallaConfiguration : IEntityTypeConfiguration<InventarioTalla>
{
    public void Configure(EntityTypeBuilder<InventarioTalla> builder)
    {

        builder.ToTable("InventarioTalla");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
        .IsRequired();

        builder.Property(e => e.Cantidad)
        .HasColumnName("cantidad")
        .HasColumnType("int")
        .HasMaxLength(3)
        .IsRequired();
        
        builder.HasOne(p => p.Inventario)
        .WithMany(p => p.InventarioTallas)
        .HasForeignKey(p => p.IdInventario);

        builder.HasOne(p => p.Talla)
        .WithMany(p => p.InventarioTallas)
        .HasForeignKey(p => p.IdTalla);

    }
}
