
namespace API.Dtos;

public class ClienteDto
{
    public string IdentificacionCliente { get; set; }
    public string Nombre { get; set; }
    public int IdTipoPersona { get; set; }
    public DateOnly FechaRegistro { get; set; }
    public int IdMunicipio { get; set; }
}
