
namespace API.Dtos;

public class OrdenDto
{
    public int Id { get; set; }
    public DateOnly Fecha { get; set; }
    public int IdEmpleado { get; set; }
    public int IdCliente { get; set; }
    public int IdEstado { get; set; }
}
