
namespace Dominio.Entities;

public class Proveedor : BaseEntity
{
    public string NitProveedor { get; set; } // unico
    public string Nombre { get; set; }
    public int IdTipoPersona { get; set; }
    public TipoPersona TipoPersona { get; set; }
    public int IdMunicipio { get; set; }
    public Municipio Municipio { get; set; }
    public ICollection<InsumoProveedor> InsumoProveedores {get;set;}
}
