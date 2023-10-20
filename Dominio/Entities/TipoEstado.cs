
namespace Dominio.Entities;

public class TipoEstado : BaseEntity
{
    public string Descipcion { get; set; }
    public ICollection<Estado> Estados { get; set; }
}
