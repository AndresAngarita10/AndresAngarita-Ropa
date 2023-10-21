
namespace API.Dtos;

public class ProveedorDto
{
    public int Id { get; set; }
    public string NitProveedor { get; set; } // unico
    public string Nombre { get; set; }
    public int IdTipoPersona { get; set; }
    public int IdMunicipio { get; set; }
}
