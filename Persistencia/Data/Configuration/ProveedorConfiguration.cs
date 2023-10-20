
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
{
    public void Configure(EntityTypeBuilder<Proveedor> builder)
    {

        builder.ToTable("proveedor");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
        .IsRequired();
        
        
        builder.Property(p => p.NitProveedor)
        .HasColumnName("nitProveedor")
        .HasColumnType("varchar")
        .HasMaxLength(150)
        .IsRequired();

        
        builder.Property(p => p.Nombre)
        .HasColumnName("nombre")
        .HasColumnType("varchar")
        .HasMaxLength(150)
        .IsRequired();

        builder.HasOne(p => p.TipoPersona)
        .WithMany(p => p.Proveedores)
        .HasForeignKey(p => p.IdTipoPersona);

        builder.HasOne(p => p.Municipio)
        .WithMany(p => p.Proveedores)
        .HasForeignKey(p => p.IdMunicipio);



    }
}
