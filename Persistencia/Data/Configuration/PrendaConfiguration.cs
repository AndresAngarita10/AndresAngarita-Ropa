
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class PrendaConfiguration : IEntityTypeConfiguration<Prenda>
{
    public void Configure(EntityTypeBuilder<Prenda> builder)
    {

        builder.ToTable("prenda");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
        .IsRequired();
        
        
        builder.Property(p => p.IdentificacionPrenda)
        .HasColumnName("identificacionPrenda")
        .HasColumnType("varchar")
        .HasMaxLength(150)
        .IsRequired();

        
        builder.Property(p => p.Nombre)
        .HasColumnName("nombre")
        .HasColumnType("varchar")
        .HasMaxLength(150)
        .IsRequired();


        builder.Property(e => e.ValorUnitatioCop)
        .HasColumnName("valorUnitatioCop")
        .HasColumnType("double")
        .IsRequired();

        
        builder.Property(e => e.ValorUnitarioUsd)
        .HasColumnName("valorUnitarioUsd")
        .HasColumnType("double")
        .IsRequired();

        builder.HasOne(p => p.Estado)
        .WithMany(p => p.Prendas)
        .HasForeignKey(p => p.IdEstado);

        builder.HasOne(p => p.TipoProteccion)
        .WithMany(p => p.Prendas)
        .HasForeignKey(p => p.IdTipoProteccion);
        
        builder.HasOne(p => p.Genero)
        .WithMany(p => p.Prendas)
        .HasForeignKey(p => p.IdGenero);



    }
}
