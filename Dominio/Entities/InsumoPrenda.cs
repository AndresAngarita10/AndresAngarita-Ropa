
namespace Dominio.Entities;

public class InsumoPrenda : BaseEntity
{
    public int IdInsumo { get; set; }
    public Insumo Insumo { get; set; }
    public int IdPrenda { get; set; }
    public Prenda Prenda { get; set; }
}
