
namespace Dominio.Entities;

public class Empleado : BaseEntity
{
    public string IdentificacionEmpleado { get; set; }
    public string Nombre { get; set; }
    public int IdCargo { get; set; }
    public Cargo Cargo { get; set; }
    public DateOnly FechaIngreso { get; set; }
    public int IdMunicipio { get; set; }
    public Municipio Municipio { get; set; }
    public ICollection<Venta> Ventas { get; set; }
    public ICollection<Orden> Ordenes { get; set; }
}
