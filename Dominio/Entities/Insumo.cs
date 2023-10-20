
namespace Dominio.Entities;

public class Insumo : BaseEntity
{
    public string Nombre { get; set; }
    public double ValorUnitario { get; set; }
    public int StrocMin { get; set; }
    public int StrocMax { get; set; }
    public ICollection<InsumoProveedor> InsumoProveedores {get;set;}
    public ICollection<InsumoPrenda> InsumoPrendas {get;set;}
}
