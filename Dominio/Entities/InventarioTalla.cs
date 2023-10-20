
namespace Dominio.Entities;

public class InventarioTalla : BaseEntity
{
    public int Cantidad { get; set; }
    public int IdInventario { get; set; }
    public Inventario Inventario { get; set; }
    public int IdTalla { get; set; }
    public Talla Talla { get; set; }
}
