
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {

        builder.ToTable("estado");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
        .IsRequired();
        
        builder.Property(p => p.Descripcion)
        .HasColumnName("descripcion")
        .HasColumnType("varchar")
        .HasMaxLength(150)
        .IsRequired();

        builder.HasOne(p => p.TipoEstado)
        .WithMany(p => p.Estados)
        .HasForeignKey(p => p.IdTipoEstado);
    }
}


