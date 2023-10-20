
namespace Dominio.Entities;

public class Inventario : BaseEntity
{
    public string CodigoInventario { get; set; } //unico
    public double ValorVentaCop { get; set; }
    public double ValorVentaUsd { get; set; }
    public int IdPrenda { get; set; }
    public Prenda Prenda { get; set; }
    public ICollection<InventarioTalla> InventarioTallas { get; set; }
    public ICollection<DetalleVenta> DetalleVentas { get; set; }
}
