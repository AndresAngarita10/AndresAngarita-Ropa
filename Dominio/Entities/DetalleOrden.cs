
namespace Dominio.Entities;

public class DetalleOrden : BaseEntity
{
    public int CantidadProducir { get; set; }
    public int CantidadProducida { get; set; }
    public int IdOrden { get; set; }
    public Orden Orden { get; set; }
    public int IdPrenda { get; set; }
    public Prenda Prenda { get; set; }
    public int IdColor { get; set; }
    public Color Color { get; set; }
    public int IdEstado { get; set; }
    public Estado Estado { get; set; }

}
