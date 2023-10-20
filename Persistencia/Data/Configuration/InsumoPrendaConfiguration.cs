
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class InsumoPrendaConfiguration : IEntityTypeConfiguration<InsumoPrenda>
{
    public void Configure(EntityTypeBuilder<InsumoPrenda> builder)
    {

        builder.ToTable("insumoPrenda");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
        .IsRequired();
        
        builder.Property(e => e.Cantidad)
        .HasColumnName("Cantidad")
        .HasColumnType("int")
        .HasMaxLength(3)
        .IsRequired();

        builder.HasOne(p => p.Insumo)
        .WithMany(p => p.InsumoPrendas)
        .HasForeignKey(p => p.IdInsumo);

        builder.HasOne(p => p.Prenda)
        .WithMany(p => p.InsumoPrendas)
        .HasForeignKey(p => p.IdPrenda);
        
        
        
    }
}
