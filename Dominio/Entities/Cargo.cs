
namespace Dominio.Entities;

public class Cargo : BaseEntity
{
    public string Descripcion { get; set; }
    public double SueldoBase { get; set; }
    public ICollection<Empleado> Empleados { get; set; }
}
