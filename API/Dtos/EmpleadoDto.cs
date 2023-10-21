
namespace API.Dtos;

public class EmpleadoDto
{
    public int Id { get; set; }
    public string IdentificacionEmpleado { get; set; } // unico
    public string Nombre { get; set; }
    public DateOnly FechaIngreso { get; set; }
    public int IdCargo { get; set; }
    public int IdMunicipio { get; set; }
}
