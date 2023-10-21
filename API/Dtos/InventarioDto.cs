
namespace API.Dtos;

public class InventarioDto
{
    public int Id { get; set; }
    public string CodigoInventario { get; set; } //unico
    public double ValorVentaCop { get; set; }
    public double ValorVentaUsd { get; set; }
    public int IdPrenda { get; set; }
}
