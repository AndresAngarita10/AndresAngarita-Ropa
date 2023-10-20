
namespace Dominio.Entities;

public class Estado : BaseEntity
{
    public string Descripcion { get; set; }
    public int IdTipoEstado { get; set; }
    public TipoEstado TipoEstado { get; set;}
    public ICollection<Orden> Ordenes { get; set; }
    public ICollection<DetalleOrden> DetalleOrdenes {get;set;}
}
