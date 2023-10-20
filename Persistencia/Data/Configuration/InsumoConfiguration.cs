
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class InsumoConfiguration : IEntityTypeConfiguration<Insumo>
{
    public void Configure(EntityTypeBuilder<Insumo> builder)
    {

        builder.ToTable("insumo");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
        .IsRequired();
        
        builder.Property(p => p.Nombre)
        .HasColumnName("nombre")
        .HasColumnType("varchar")
        .HasMaxLength(150)
        .IsRequired();

        builder.Property(p => p.ValorUnitario)
        .HasColumnName("valorUnitario")
        .HasColumnType("double")
        .IsRequired();

        
        builder.Property(e => e.StrocMin)
        .HasColumnName("strocMin")
        .HasColumnType("int")
        .HasMaxLength(3)
        .IsRequired();

        builder.Property(e => e.StrocMax)
        .HasColumnName("strocMax")
        .HasColumnType("int")
        .HasMaxLength(3)
        .IsRequired();
    }
}
