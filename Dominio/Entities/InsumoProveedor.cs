
namespace Dominio.Entities;

public class InsumoProveedor : BaseEntity
{
    public int IdInsumo { get; set; }
    public Insumo Insumo { get; set; }
    public int IdProveedor { get; set; }
    public Proveedor Proveedor { get; set; }
}
