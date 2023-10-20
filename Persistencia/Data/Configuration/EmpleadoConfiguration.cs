
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {

        builder.ToTable("empleado");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
        .IsRequired();
        
        builder.Property(p => p.IdentificacionEmpleado)
        .HasColumnName("identificacionEmpleado")
        .HasColumnType("varchar")
        .HasMaxLength(150)
        .IsRequired();

        builder.Property(p => p.Nombre)
        .HasColumnName("nombre")
        .HasColumnType("varchar")
        .HasMaxLength(150)
        .IsRequired();

        builder.Property(p => p.FechaIngreso)
        .HasColumnName("fechaIngreso")
        .HasColumnType("date")
        .IsRequired();

        builder.HasOne(p => p.Cargo)
        .WithMany(p => p.Empleados)
        .HasForeignKey(p => p.IdCargo);

        builder.HasOne(p => p.Municipio)
        .WithMany(p => p.Empleados)
        .HasForeignKey(p => p.IdMunicipio);



    }
}

