
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class InsumoProveedorConfiguration : IEntityTypeConfiguration<InsumoProveedor>
{
    public void Configure(EntityTypeBuilder<InsumoProveedor> builder)
    {

        builder.ToTable("insumoProveedor");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
        .IsRequired();
        
        builder.HasOne(p => p.Insumo)
        .WithMany(p => p.InsumoProveedores)
        .HasForeignKey(p => p.IdInsumo);

        builder.HasOne(p => p.Proveedor)
        .WithMany(p => p.InsumoProveedores)
        .HasForeignKey(p => p.IdProveedor);
        

        
    }
}
