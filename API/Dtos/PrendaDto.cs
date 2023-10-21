
namespace API.Dtos;

public class PrendaDto
{
    public int Id { get; set; }
    public string IdentificacionPrenda { get; set; } //unico
    public string Nombre { get; set; }
    public double ValorUnitatioCop { get; set; }
    public double ValorUnitarioUsd { get; set; }
    public int IdEstado { get; set; }
    public int IdTipoProteccion { get; set; }
    public int IdGenero { get; set; }
}
