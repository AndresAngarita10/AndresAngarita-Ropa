
namespace API.Dtos;

public class VentaDto
{
    public int Id { get; set; }
    public DateOnly Fecha { get; set; }
    public int IdEmpleado { get; set; }
    public int IdCliente { get; set; }
    public int IdFormaPago { get; set; }
}
