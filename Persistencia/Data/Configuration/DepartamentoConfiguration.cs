
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {

        builder.ToTable("departamento");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
        .IsRequired();

        builder.Property(p => p.Nombre)
        .HasColumnName("nombre")
        .HasColumnType("varchar")
        .HasMaxLength(150)
        .IsRequired();

        builder.HasOne(p => p.Pais)
        .WithMany(p => p.Departamentos)
        .HasForeignKey(p => p.IdPais);

    }
}

